using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyScript : MonoBehaviour
{
    //ymin and max for the random targets
    public int zMax;
    public int zMin;


    //xmin and max for the random targets
    public int xMax;
    public int xMin;

    //vertical range ymin max
    public int yMin;
    public int yMax;


    //move and turn speed stats
    public float moveSpeed;
    public float turnSpeed;
    public float stoppingDistance;

    //current target and position
    public Transform prey;
    public Transform target;

    

    public int avoidanceDistance;

    public double timeColliding;

    public int maxTimeEscape;

    public bool isPredator;

    public FaunaSpawna spawner;





    


    // Start is called before the first frame update
    void Start()
    {

        xMin = -10;
        xMax = 10;
        zMin = -10;
        zMax = 10;

        stoppingDistance = 1;

        RandomTarget();

        

    }

    // Update is called once per frame
    void Update()
    {

        if (!spawner.hunting || !isPredator)
        {
            //points towards target
            prey.rotation = Quaternion.RotateTowards(prey.rotation, Quaternion.LookRotation(target.position - prey.position), turnSpeed * Time.deltaTime);

            //stops within distance
            if (Vector3.Distance(prey.position, target.position) > stoppingDistance)
            {
                prey.position += prey.forward * Time.deltaTime * moveSpeed;

            }
            else
            {
                RandomTarget();
            }
        }
        else
        {
            Debug.Log("here");
            if(spawner.targetPredator.Equals(gameObject))
            {
                target = spawner.targetPrey.transform;
            }
            if (Vector3.Distance(prey.position, target.position) > stoppingDistance)
            {
                prey.position += prey.forward * Time.deltaTime * moveSpeed;

            }
            else
            {
                RandomTarget();
            }
        }
    }

    void RandomTarget()
    {
        target.position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));

    }

    void OnTriggerEnter(Collider collision)
    {
        if (!isPredator)
        {
            target.position = new Vector3(Random.Range(xMin, xMax), 1, Random.Range(zMin, zMax));
            timeColliding = 0;
            RandomTarget();
            while (Vector3.Distance(collision.gameObject.transform.position, target.position) < avoidanceDistance)
            {
                RandomTarget();
            }
        }
        
    }

    public void setHuntingTarget(Transform t)
    {
        target = t;
    }





 

}
