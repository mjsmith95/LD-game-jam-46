using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public Vector3 newPostion;
    public Quaternion newRotation; 
    public float Speed = 2.0f;
    public void ChangePostion()
    {
        transform.position = Vector3.Lerp(transform.position, newPostion, Speed * Time.deltaTime);
    }
    public void ChangeRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.0f * Time.deltaTime);
    }
    private void Update()
    {
        if (Input.anyKey)
        {
            ChangePostion();
            if (transform.position == newPostion)
            {
                ChangeRotation();
            }
        }
    }
}
