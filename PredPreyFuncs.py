# -*- coding: utf-8 -*-
"""
Created on Fri Apr 17 22:36:40 2020

@author: miles 

dPrey/dt = bPrey - h * Prey * Pred 
dPred/dt =  eh * Pred * Prey -  dPrey 

prey and predators 
prams 

b = prey birth rate   
h = prey/pred interaction rate 
e = rate if prey population desnity to pred population density
d = predator death rate 
"""
import numpy as np
import matplotlib.pyplot as plt

def dxydt(xy, b, h, e, d):
    x, y = xy
    dx = b * x - h * x * y
    dy = e * h * x * y - d * y
    return np.array([dx, dy])

b = 0.1
h = 0.06
e = 0.8
d = 1
steps = 20000
xy = np.zeros((2, steps))
xy[:,0] = 50, 10
dt = 0.001

for t in range(1, steps):
    xy[:,t] = xy[:, t-1] + dxydt( xy[:, t-1], b, h, e, d) * dt
x = xy[0, :]
y = xy[1, :]

t = np.arange(0, dt*steps, dt)

plt.plot( t,x, label='prey')
plt.plot(t, y, label='predator')
plt.xlabel('Time')
plt.ylabel('Count')
plt.legend();
plt.savefig("Unstablepred.png")
p = 1
for t in range(0,10):
    print("curr p val " + str(p))
    p = p + 1  