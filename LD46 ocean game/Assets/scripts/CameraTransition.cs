using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public GameObject firstUI;
    public GameObject secondUI;
    public void ChangePostion()
    {
        transform.position = new Vector3(13.74f + -11.73999f, 5.514928f + 9.485072f, -12.88122f + 0.6612151f);
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
