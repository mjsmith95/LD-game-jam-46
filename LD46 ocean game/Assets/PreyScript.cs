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


    //move and turn speed stats
    public float moveSpeed;
    public float turnSpeed;
    public float stoppingDistance;

    //current target and position
    public Transform prey;
    public Transform target;

    

    public int avoidanceDistance;


    


    // Start is called before the first frame update
    void Start()
    {

        xMin = -10;
        xMax = 10;
        zMin = -10;
        zMax = 10;

        stoppingDistance = 1;

        target.position = new Vector3(Random.Range(xMin, xMax), 1, Random.Range(zMin, zMax));

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
            target.position = new Vector3(Random.Range(xMin, xMax), 1, Random.Range(zMin, zMax));
        }
    }

    void RandomTarget()
    {
        //target = new Vector3(Random.Range(xMin,xMax), 0, Random.Range(zMin, zMax));

    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Scatter!");
        if (collision.name == "Predator")
        {
            
            while (Vector3.Distance(collision.gameObject.transform.position, target.position) < avoidanceDistance)
            {
                target.position = new Vector3(Random.Range(xMin, xMax), 1, Random.Range(zMin, zMax));
            }
        }
    }
}
