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
    public int epoch;
    public double step;
    public double timeRaito;
    public double preyDeathRatio;
    public double predDeathRatio;

    public double[] preyTimeline;
    public double[] predTimeline;

    // calc 2 time baby 
    private double[] PredPreyDiffEq(double[] ppPop, double pBr, double ppIt, double conversionRate, double pDR)
    {
        double[] changeInPredPrey = new double[2];
        // first index is change in prey pop, dx = b * x - h * x * y
        changeInPredPrey[0] = pBr * ppPop[0] - ppIt * ppPop[0] * ppPop[1];
        // second is change in pred , dy = e * h * x * y - d * y
        changeInPredPrey[1] = conversionRate * ppIt * ppPop[0] * ppPop[1] - predDR*ppPop[1];
        // return vector with both 
        return changeInPredPrey;
    }

    private void IntegratationStep(int steps,double[] currentPop, double deltaTime)
    {
        //get current pred and prey pops 
        Debug.Log("number of steps " + steps);
        double[] predPreyPop = currentPop;
        Debug.Log("this list size is " + preyTimeline.Count());
        //loop through the range of integration 
        for (int t = 0; t < steps; t++)
        {
            //summation for population values multiplied by change in time (step size)
            // if change in time is zero dont change the population 
            if (t == 0)
            {
                preyTimeline[t] = predPreyPop[0];
                predTimeline[t] = predPreyPop[1];
            }
            //otherwise the current population in time equla the last + diffeq * deltaT 
            else
            {
                double[] prevPops = { preyTimeline[t - 1], predTimeline[t - 1] };
                double[] dpdt = PredPreyDiffEq(prevPops, preyBR, predPreyIt, predPreyConv, predDR);

                preyTimeline[t] = preyTimeline[t-1] + dpdt[0] * deltaTime;
                predTimeline[t] = predTimeline[t - 1] + dpdt[1] * deltaTime;
            }
        }
    }

    public void Simulate(int[] popVector)
    {
        // get the current populations and cast to prep for integration 
        double[] currentPop = new double[2];
        currentPop[0] = (double)popVector[0];
        currentPop[1] = (double)popVector[1];
        Debug.Log("********************************");
        Debug.Log("current prey pop is: " + currentPop[0]);
        Debug.Log("current pred pop is: " + currentPop[1]);
        Debug.Log("testy pop" + predTimeline[1]);
        IntegratationStep(epoch, currentPop, step);
        Debug.Log("The current prey population is: " + popVector[0]);
        Debug.Log("The current pred population is: " + popVector[1]);
        //Debug.Log("The tragert prey population is: " + targetPredPreyPop[0]);
        //Debug.Log("The targert pred population is: " + targetPredPreyPop[1]);
        Debug.Log("The epoch was: " + epoch);
        Debug.Log("The epoch to time ratio is 20000 to 20 or 1000 steps to one second");
        Debug.Log("The population exchange rate is 1 in game animal to 10 simulated");
    }
    /* epochs last 2 min  
     * 2 min 
     * assume some number of steps in simu  lation is equal to some amount of in game time 
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
    void Awake()
    {
        preyTimeline = new double[epoch];
        predTimeline = new double[epoch];
        Debug.Log("current array size please for the love of god work so I can find all the shit worng in my code: " + predTimeline.Count());
    }
    void Start()
    {
        // need to fix tomorrow 
        Simulate(predPreyPop);
        //set up time
    }
}
