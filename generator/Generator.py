import numpy as np
from sys import argv

def generate(inFile = "generator.in", outFile = "process.in"):
    fIn = open(inFile)
    fOut = open(outFile,'w')
    lines = fIn.readlines()
    fIn.close()

    numProcess = int(lines[0][:-1])
    fOut.write(str(numProcess))
    
    arrivalM , arrivalS = lines[1].split(" ")
    arrivalM = float(arrivalM)
    arrivalS = float(arrivalS[:-1])
    arrivalList = np.around(np.sort(np.abs(np.random.normal(arrivalM, arrivalS, numProcess))), decimals=1)
    

    burstM, burstS = lines[2].split(" ")
    burstM = float(burstM)
    burstS = float(burstS[:-1])
    burstList = np.around(np.abs(np.random.normal(burstM, burstS, numProcess)), decimals=1)
    
    priorityL = float(lines[3][:-1])
    priorityList = np.abs(np.random.poisson(priorityL, numProcess))
    
    for i in range(numProcess):
        fOut.write("\n{} {} {} {}".format(i+1, arrivalList[i], burstList[i], priorityList[i]))

generate(argv[1], argv[2])
print(argv[2])
