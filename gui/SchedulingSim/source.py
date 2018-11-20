import numpy as np
import sys


def getImplFromName(algoName):
    return {'RR': solve_rr, 'HPF': solve_hpf, 'FCFS': solve_fcfs, 'SRTN': solve_srtn}.get(algoName)

def solve_rr(inputPath, switchingtime,q):
    print('rr')

def solve_hpf(inputPath, switchingtime):
    print('hpf')

def solve_fcfs(inputPath, switchingtime):
    print('fcfs')

def solve_srtn(inputPath, switchingtime):
    print('srtn')


def main():
    algoName = sys.argv[1]
    inputPath = sys.argv[2]
    switchingtime = sys.argv[3]
    q = None
    if(len(sys.argv) >= 4):
        q = sys.argv[4]
    impl = getImplFromName(algoName)
    result = None
    if(impl):
        impl(inputPath, switchingtime,q) if q else impl(inputPath, switchingtime)

    
if __name__ == "__main__":
    main()