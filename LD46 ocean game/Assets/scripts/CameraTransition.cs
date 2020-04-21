using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public GameObject firstUI;
    public GameObject secondUI;
    public Vector3 newPostion;
    public float Speed = 2.0f;
    public float rotationSpeed = 10f;
    public void ChangePostion()
    {
        transform.position = Vector3.Lerp(transform.position, newPostion, Speed);
        ChangeRotation();
    }
    public void ChangeRotation()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.x = 45;
        transform.eulerAngles = rotation;
    }
    public void DisableUI()
    {
        firstUI.SetActive(false);
        ChangePostion();
        EnableUI();
    }
    public void EnableUI()
    {
        secondUI.SetActive(true);
    }
    private void Awake()
    {
        secondUI.SetActive(false);
    }
    /* if (Input.anyKey)
     {
         ChangePostion();
         if (transform.position == newPostion)
         {
             Debug.Log("pos reached");
             ChangeRotation();
         }
     } */

}


/*  public float rotationSpeed = 10;
 
     void Update() {
         Vector3 rotation = transform.eulerAngles;
 
         rotation.x += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime; // Standart Left-/Right Arrows and A & D Keys
 
         transform.eulerAngles = rotation;
     }
 } */
