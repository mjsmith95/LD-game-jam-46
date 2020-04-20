using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisasterSimulator : MonoBehaviour
{
    public TextMeshProUGUI ticker;
    public Simulator simulator;
    public FaunaSpawna faunaSpawna;

    public int prevWholeSecond;
    public int secBetweenDisasterChance;
    
    
    // Start is called before the first frame update
    void Start()
    {
        changeTicker("");
        prevWholeSecond = faunaSpawna.currentWholeSecond;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(prevWholeSecond + secBetweenDisasterChance == faunaSpawna.currentWholeSecond)
        {
            int randomEvent = Random.Range(0, 10);
            simulator.resetToDefault();
            if(randomEvent < 7)
            {
                Stable();
            }
            else
            {
                randomEvent = Random.Range(0, 3);
                if(randomEvent == 0)
                {
                    Pollution();
                }else if (randomEvent == 1)
                {
                    OverFishing();
                }
                else if (randomEvent == 2)
                {
                    CoralBleaching();
                }
            }
            prevWholeSecond = faunaSpawna.currentWholeSecond;
        }
    }

    public void changeTicker(string newText)
    {
        ticker.text = newText;
    }

    void Stable()
    {
        changeTicker("");
    }

    void Pollution()
    {
        changeTicker("Pollution: Predator death rate increase");
        simulator.ChanngePredDeathRate(0.8f);
    }

    void OverFishing()
    {
        changeTicker("Over Fishing: Fish birthrate decrease");
        simulator.ChanngePreyBirthRate(0.2f);
    }

    void CoralBleaching()
    {
        changeTicker("Coral Bleaching: 20% Population dies");
        simulator.predPreyPop[0] =(int)((float)simulator.predPreyPop[0] * 0.8);
        simulator.predPreyPop[1] = (int)((float)simulator.predPreyPop[1] * 0.8);
        simulator.Simulate(simulator.predPreyPop);
    }
}
