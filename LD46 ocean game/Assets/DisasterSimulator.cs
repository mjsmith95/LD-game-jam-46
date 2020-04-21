using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisasterSimulator : MonoBehaviour
{
    public GameObject restartButton;
    public TextMeshProUGUI ticker;
    public Simulator simulator;
    public FaunaSpawna faunaSpawna;

    public int prevWholeSecond;
    public int secBetweenDisasterChance;

    public bool disasterFreeMode;

    private void Awake()
    {
        restartButton.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        changeTicker("");
        prevWholeSecond = faunaSpawna.currentWholeSecond;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (simulator.predPreyPop[0]!= 0 || simulator.predPreyPop[1] != 0) {
            if (prevWholeSecond + secBetweenDisasterChance == faunaSpawna.currentWholeSecond)
            {
                int randomEvent = Random.Range(0, 10);
                //simulator.resetToDefault();
                if (randomEvent < 7 || disasterFreeMode)
                {
                    Stable();
                }
                else
                {
                    randomEvent = Random.Range(0, 3);
                    if (randomEvent == 0)
                    {
                        Pollution();
                    } else if (randomEvent == 1)
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
        else
        {
            changeTicker("Game Over: The ecosystem has crashed");
            faunaSpawna.numPrey = 0;
            faunaSpawna.numPredators = 0;
            simulator.predPreyPop[0] = 0;
            simulator.predPreyPop[1] = 0;
            simulator.Simulate(simulator.predPreyPop);
            faunaSpawna.numPrey = 0;
            BroadcastMessage("Restart");
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
    void Restart()
    {
        restartButton.SetActive(true);
    }
}
