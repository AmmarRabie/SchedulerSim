import numpy as np
import matplotlib.pyplot as plt
from collections import deque
from sys import argv, stderr, stdout

class Process:
    def __init__ (self,PN, arrivalTime, burstTime, priority):
        self.ID, self.arrivalTime, self.burstTime, self.priority = PN, arrivalTime, burstTime, priority
        self.startWorkingTime = -1
        self.totalBurstTime = self.burstTime
        self.finishTime = 0

    @classmethod
    def fromlist(cls, dataList):
        return cls(int(dataList[0]), float(dataList[1]), float(dataList[2]), int(dataList[3]))

class Scheduler:
    def __init__(self):
        self.TimeList = []
        self.Time = 0
        self.finishedList = []



def solve_fcfs(processes, switchingtime):
    #print("fcfs")
    s = Scheduler()
    processesQueue = deque(processes)
    s.Time = 0 # float(processes[0][ARRIVAL_TIME]) # min arrival time
    while(len(processesQueue) >= 1):
        currentWorkingProcess = processesQueue.popleft()
        if s.Time < currentWorkingProcess.arrivalTime:
            s.TimeList.append((-1, currentWorkingProcess.arrivalTime - s.Time))
            s.Time = currentWorkingProcess.arrivalTime
        else:
            s.Time += switchingtime
            s.TimeList.append((0,switchingtime))
        currentWorkingProcess.startWorkingTime = s.Time

        s.Time += currentWorkingProcess.burstTime
        currentWorkingProcess.finishTime = s.Time
        s.finishedList.append(currentWorkingProcess)
        s.TimeList.append((currentWorkingProcess.ID,currentWorkingProcess.burstTime))
    return s


def addCommingProcess(allProcess, currentProcessList,count,time):
    # move on comming processes appending all new processes w.r.t s.Time (current time slot)
    currentProcess = allProcess[count]
    time = np.round(time,decimals=1)
    while (currentProcess.arrivalTime <= time) and count <len(allProcess):
        currentProcessList.append(currentProcess)
        count += 1
        if count < len(allProcess):
            currentProcess = allProcess[count]
    return currentProcessList,count


NOPTime = 0.1

def HDFProcessOne(s,listProcess,switchingTime):
    runingProcess = listProcess.pop(0)
    if runingProcess.startWorkingTime == -1:
        runingProcess.startWorkingTime = s.Time
    s.TimeList.append((runingProcess.ID,runingProcess.burstTime))
    s.Time += runingProcess.burstTime
    runingProcess.finishTime = s.Time
    
    s.TimeList.append((0,switchingTime))
    s.Time += switchingTime
    
    s.finishedList.append(runingProcess)

    
def HPF(processes, switchingTime):
    #print("hpf")
    s = Scheduler()
    listProcess = []
    i = 0
    while i <len(processes):
        listProcess, i = addCommingProcess(processes,listProcess,i,s.Time)

        if len(listProcess):
            listProcess.sort(key=lambda x: x.priority, reverse=True)
            HDFProcessOne(s,listProcess,switchingTime)
        else:
            s.TimeList.append((-1,NOPTime))
            s.Time += NOPTime

    if len(listProcess):
        listProcess.sort(key=lambda x: x.priority, reverse=True)
        for i in range(len(listProcess)):
            HDFProcessOne(s,listProcess,switchingTime)
    return s

def RRProcessOne(s,listProcess,quantumTime,switchingTime):
    if RRProcessOne.check:
        s.TimeList.append((0,switchingTime))
        s.Time += switchingTime
        
    RRProcessOne.check = True

    runingProcess = listProcess.pop(0)
    if runingProcess.startWorkingTime == -1:
        runingProcess.startWorkingTime = s.Time

    runingTime = quantumTime if (quantumTime <= runingProcess.burstTime ) else runingProcess.burstTime

    s.TimeList.append((runingProcess.ID,runingTime))
    s.Time += runingTime
    runingProcess.burstTime -= runingTime

    if runingProcess.burstTime > 0:
        toAppend = [runingProcess]
    else:
        runingProcess.finishTime = s.Time
        s.finishedList.append(runingProcess)
        toAppend = []

    return toAppend

    
def RR(processes,switchingTime,q):
    RRProcessOne.check = False
    #print("RR")
    s = Scheduler()
    listProcess = []
    i = 0
    toAppend = []
    while i <len(processes):
        listProcess, i = addCommingProcess(processes,listProcess,i,s.Time)

        listProcess.extend(toAppend)

        if len(listProcess):
            toAppend = RRProcessOne(s,listProcess,q,switchingTime)
        else:
            s.TimeList.append((-1,NOPTime))
            s.Time += NOPTime

    listProcess.extend(toAppend)
    while len(listProcess):
        toAppend = RRProcessOne(s,listProcess,q,switchingTime)
        listProcess.extend(toAppend)
        
            
    return s

def SRTNProcessOne(s,listProcess,lastProcessID,switchingTime,timeCheck = 0.1):
    listProcess.sort(key=lambda x: x.burstTime)
    
    runingProcess = listProcess[0]
    if runingProcess.startWorkingTime == -1:
        runingProcess.startWorkingTime = s.Time

    
    if (not runingProcess.ID == lastProcessID) and (not lastProcessID == -1):
        s.TimeList.append((0,switchingTime))
        s.Time += switchingTime
        return runingProcess.ID

    # runingTime = quantumTime if (quantumTime <= runingProcess.burstTime ) else runingProcess.burstTime
    lastProcessID = runingProcess.ID
    s.TimeList.append((runingProcess.ID,timeCheck))
    s.Time += timeCheck
    runingProcess.burstTime -= timeCheck

    if runingProcess.burstTime <= 0:
        runingProcess = listProcess.pop(0)
        runingProcess.finishTime = s.Time
        s.finishedList.append(runingProcess)

    return lastProcessID
    
def SRTN(processes,switchingtime):
    #print("srtn")
    s = Scheduler()
    listProcess = []
    lastProcessID = 0
    i = 0
    
    while i <len(processes):
        listProcess, i = addCommingProcess(processes,listProcess,i,s.Time)

        if len(listProcess):
            lastProcessID = SRTNProcessOne(s,listProcess,lastProcessID,switchingtime)
        else:
            s.TimeList.append((-1,NOPTime))
            lastProcessID = -1
            s.Time += NOPTime

    while len(listProcess):
        lastProcessID = SRTNProcessOne(s,listProcess,lastProcessID,switchingtime)

    return s


# # Draw Graph
def drawGraph(s, show=False):
    '''
    draw a graph of a given scheduler, save the graph in png image returning the file name of saved image
    if show is passed True then the draw will open a window of the graph
    '''
    x = [0]
    y = [0]
    w = [0]
    s.TimeList.insert(0, (0,0))
    s.TimeList.append((0,0))
    # for one in s.TimeList:#[:40]:

    #     y.append(one[0])
    #     x.append(x[-1])
        
    #     x.append(x[-1]+one[1])
    #     y.append(y[-1])
    # plt.plot(np.round(np.array(x),decimals=1),np.round(np.array(y),decimals=1))
    accX = 0
    for one in s.TimeList:#[:40]:
        accX += one[1]
        if one[0] != -1:
            y.append(one[0])
            x.append(accX)
            w.append(-one[1])
    plt.bar(x, y, width= w, align='edge', color=np.random.randint(0,255,(len(w),3))/255.0)

    plt.savefig("image.png")
    plt.show() if show else None
    return "image.png"



def CalcStatistics(s):
    '''
    calculate statistics of given scheduler, writing all statistics in a file and returning this file name and average data
    '''
    sumTurnaroundTime = 0
    sumWeightedTurnaround = 0
    s.finishedList.sort(key= lambda x: x.ID)
    f = open('stat.txt', 'w')
    f.write('ID\t\twaitingTime\t\tTAT\t\tWTAT\n')
    for process in s.finishedList:
        turnaroundTime = process.finishTime - process.arrivalTime
        # waitingTime = process.startWorkingTime - process.arrivalTime
        waitingTime = turnaroundTime - process.totalBurstTime
        weightedTurnaround = turnaroundTime / process.totalBurstTime
        sumTurnaroundTime += turnaroundTime
        sumWeightedTurnaround += weightedTurnaround
        f.write("{0:0.0f}\t\t{1:0.1f}\t\t\t{2:0.1f}\t\t{3:0.1f}\n".format(process.ID, waitingTime, turnaroundTime, weightedTurnaround))

    averageTurnaround = np.round(sumTurnaroundTime / len(s.finishedList),decimals=1)
    averageWeighted = np.round(sumWeightedTurnaround / len(s.finishedList), decimals=1)
    f.write("average TAT: {}\naverage weighted: {}".format(averageTurnaround,averageWeighted))
    f.close()
    return f.name, averageTurnaround, averageWeighted


def getImplFromName(algoName):
    '''
    interface between implementation name and parameter name
    '''
    return {'RR': RR, 'HPF': HPF, 'FCFS': solve_fcfs, 'SRTN': SRTN}.get(algoName)


def readProcessesLines(filePath):
    '''
    read processes lines and check validation
    '''
    with open(filePath, "r") as file:
        c = int(file.readline())
        lines = file.read().splitlines()
        if(c != len(lines)):
            raise Exception("error while reading the input file, expected {} lines, found {} lines".format(c,len(lines)))
        return lines

def readArguments():
    argc = len(argv)
    if (argc != 4 and argc != 5):
        print('args is not correct, should be 3 or 4 -> found', argc - 1, argv)#, file=stderr)
        return
    algoName, inputPath, switchingtime= argv[1], argv[2], argv[3]
    q = None
    if(argc >= 5):
        q = float(argv[4])
    return algoName, inputPath, float(switchingtime), q

def parseLines(lines):
    '''
    convert text of processes to match our process class, so it sorts the data depending on arrival time retuning list of <class Process>
    '''
    processes = [Process.fromlist(i.split(' ')) for i in lines]
    processes.sort(key= lambda x: float(x.arrivalTime)) # handle the case of if two have coming in the same time slot put the first first
    return processes

def main():
    '''
    main entry of app
    '''
    algoName, inputPath, switchingtime, q = readArguments()
    impl = getImplFromName(algoName)
    if(not impl):
        print('there is no impl for specified args', argv)#, file=stderr)
        raise Exception("No such algo")

    lines = readProcessesLines(inputPath)
    processes = parseLines(lines)
    scheduler = impl(processes, switchingtime, q=q) if q else impl(processes,switchingtime)
    statFileName, avgTAT, avgWTAT = CalcStatistics(scheduler)
    imageFileName = drawGraph(scheduler)

    # send data to caller
    print(imageFileName, statFileName, avgTAT, avgWTAT)


main()