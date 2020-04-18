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

    public bool hunting;

    public Object huntingTarget;


    


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
    void FixedUpdate()
    {

        
        //points towards target
        prey.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(target.position - prey.position), turnSpeed * Time.deltaTime);

        //stops within distance
        if (Vector3.Distance(prey.position, target.position) > stoppingDistance) { 
            prey.position += prey.forward * Time.deltaTime * moveSpeed;
            
        }
        else
        {
            if (hunting)
            {
                Destroy(huntingTarget);
                hunting = false;
            }
            RandomTarget();
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
            while (Vector3.Distance(collision.gameObject.transform.position, target.position) < avoidanceDistance)
            {
                RandomTarget();
            }
        }
        else
        {
            if (!hunting)
            {
                hunting = true;
                target = collision.gameObject.transform;
                huntingTarget = collision.gameObject;
                Debug.Log("i am hunting");
            }
        }
        
    }

    private void OnCollisionEnter(Collision col)
    {
        
    }

 

}
