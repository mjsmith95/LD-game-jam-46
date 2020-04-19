using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaunaSpawna : MonoBehaviour
{
    public GameObject predator;
    public GameObject prey;

    public int numPredators;
    public int numPrey;

    public List<GameObject> preyList;
    public List<GameObject> predatorList;

    public bool hunting;

    public int huntingPredatorIndex;
    public int huntedPreyIndex;

    public GameObject targetPredator;
    public GameObject targetPrey;


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
            preyList.Add(Instantiate<GameObject>(prey));
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
}
