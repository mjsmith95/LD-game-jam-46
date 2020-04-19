using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : MonoBehaviour
{
    /*Prams
    preyBR = preyBirthRate
    predPreyIt = pred prey interaction rate 
    predPreyConv = rate for conversion from prey to pred 
    predDR = pred death rate 
    */

    // these prams can be changed / accessed py player and scripted events 

    public double preyBR;
    public double predPreyIt;
    public double predPreyConv;
    public double predDR;
    //store the current population
    public int[] predPreyPop;
    // store the simulated population 
    public int[] targetPredPreyPop;

    // these parms are for the integration step, timing and changing in populations 
    public double epoch;
    public double step;
    // calc 2 time baby 
    private double[] PredPreyDiffEq(double[] ppPop, double pBr, double ppIt, double conversionRate, double pDR)
    {
        double[] changeInPredPrey = new double[2];
        // first index is change in prey pop 
        changeInPredPrey[0] = pBr * ppPop[0] - ppIt * ppPop[0] * ppPop[1];
        // second is change in pred 
        changeInPredPrey[1] = conversionRate * ppIt * ppPop[0] * ppPop[1] - predDR;
        // return vector with both 
        return changeInPredPrey;
    }

    public double[] IntegratationStep(int steps,double[] currentPop, double deltaTime)
    {
        //get current pred and prey pops 
        double[] predPreyPop = currentPop;


        //loop through the range of integration 
        for (int t = 0; t < steps; t++)
        {
            //summation for population values multiplied by change in time (step size)
            // if change in time is zero dont change the population 
            if (t == 0)
            {
                predPreyPop = predPreyPop;
            }
            //otherwise the current population in time equla the last + diffeq * deltaT 
            else
            {
                predPreyPop[0] = predPreyPop[0] + PredPreyDiffEq(predPreyPop, preyBR, predPreyIt, predPreyConv,predDR)[0] * deltaTime;
                predPreyPop[1] = predPreyPop[1] + PredPreyDiffEq(predPreyPop, preyBR, predPreyIt, predPreyConv, predDR)[1] * deltaTime;
            }
        }
        return predPreyPop;
    }
    /* epochs last 2 min  
     * 2 min 
     * assume some number of steps in simulation is equal to some amount of in game time 
     * assume 1 in game fish is eqaul to 10 - 100 simulated fish (pred and prey still need to figure out best scale) 
     * on simulation 
     * - integration happens 
     * - conversion rate to time and pop happens 
     * - send converted values to the faunaSpawna 
     * on event 
     * - player induced or otherwise 
     * - run on simulation 
     */
    //on start run a simulation for 5 min  


}
