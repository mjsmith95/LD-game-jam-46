using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaunaSpawna : MonoBehaviour
{
    public GameObject predator;
    public GameObject prey;
    public GameObject prey2;

    // list vals to use with simulator script 
    public int numPredators;
    public int numPrey;

    public List<GameObject> preyList;
    public List<GameObject> predatorList;

    public bool hunting;

    public int huntingPredatorIndex;
    public int huntedPreyIndex;

    public GameObject targetPredator;
    public GameObject targetPrey;
    // simulatation vals
    public Simulator simulation;
    public float totalTime; // how much in game time we want for a simulation run 
    private int sampleRatio; // the rate at which we sample the population timeline
    private float currentTime; // current in game time, ALWAYS ADD f AT THE END OF A FLOAT VAL
    private int currentWholeSecond;
    private int prevWholeSecond; 

    //set up sim
    private void Awake()
    {
        currentWholeSecond = 0;
        prevWholeSecond = 0;
        currentTime = 0f;
        sampleRatio = Mathf.FloorToInt(((float)simulation.epoch) / totalTime);    
    }
    // Start is called before the first frame update
    void Start()
    {
        preyList = new List<GameObject>();
        predatorList = new List<GameObject>();
        hunting = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (numPredators < 0) numPredators = 0;
        if (numPrey < 0) numPredators = 0;

        if(preyList.Count < numPrey)
        {
            spawnPrey();
        }else if(preyList.Count > numPrey)
        {
            huntPrey();
        }

        if (predatorList.Count < numPredators)
        {
            spawnPredator();
        }
        else if (predatorList.Count > numPredators)
        {
            huntPredator();
        }
        // simulation and timer code 
        currentTime += Time.deltaTime;
        currentWholeSecond = Mathf.FloorToInt(currentTime) % ((int)totalTime);
        if (prevWholeSecond != currentWholeSecond)
        {
            UpdatePredPreyPopulation(currentWholeSecond);
            //Debug.Log("Is the timner working: " + currentWholeSecond); 
        }
        prevWholeSecond = currentWholeSecond; 

    }

    void spawnPredator()
    {
        if (predatorList.Count == 0)
        {
            predatorList.Add(Instantiate<GameObject>(predator, new Vector3(0, 0, 0), new Quaternion()));
        }
        else
        {
            predatorList.Add(Instantiate<GameObject>(predator));
            
        }
    }

    void spawnPrey()
    {
        if (preyList.Count == 0)
        {
            preyList.Add(Instantiate<GameObject>(prey, new Vector3(0, 0, 0), new Quaternion()));
        }
        else
        {
            if (Random.Range(0,5) < 3) {
                preyList.Add(Instantiate<GameObject>(prey));
            }
            else
            {
                preyList.Add(Instantiate<GameObject>(prey2));
            }
        }
    }

    void huntPrey()
    {
        int tempIndex = Random.Range(0, preyList.Count);
        GameObject temp = preyList[tempIndex];
        preyList.Remove(preyList[tempIndex]);
        Destroy(temp);
    }

    void huntPredator()
    {
        int tempIndex = Random.Range(0, predatorList.Count);
        GameObject temp = predatorList[tempIndex];
        predatorList.Remove(predatorList[tempIndex]);
        Destroy(temp);
    }

    void setPredatorTarget()
    {
        huntedPreyIndex = Random.Range(0, preyList.Count);
        huntingPredatorIndex = Random.Range(0, predatorList.Count);
        targetPredator = predatorList[huntingPredatorIndex];
        targetPrey = predatorList[huntedPreyIndex];
        hunting = true;
    }

    void UpdatePredPreyPopulation(int currentTime)
    {
        int val = Mathf.FloorToInt((float)simulation.preyTimeline[sampleRatio * currentWholeSecond]);
        Debug.Log("current prey pop at time " + currentTime + " is " + val);
    }


}
