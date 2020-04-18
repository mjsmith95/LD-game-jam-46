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

    //current target and position
    public Transform prey;
    public Transform target;


    //random to be used
    public Random rand;


    // Start is called before the first frame update
    void Start()
    {

        xMin = -10;
        xMax = 10;
        zMin = -10;
        zMax = 10;

        target.position = new Vector3(Random.Range(xMin, xMax), 0, Random.Range(zMin, zMax));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //prey.Rotate(new Vector3(0, turnSpeed*Time.deltaTime, 0));

        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - prey.position;

        // The step size is equal to speed times frame time.
        float singleStep = turnSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(prey.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(prey.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        prey.rotation = Quaternion.LookRotation(newDirection);


        prey.position += prey.forward * Time.deltaTime * moveSpeed;
    }

    void RandomTarget()
    {
        //target = new Vector3(Random.Range(xMin,xMax), 0, Random.Range(zMin, zMax));

    }
}
