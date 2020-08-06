using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCamera : MonoBehaviour
{

    public float RotationSpeed = 2f;



    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

    }

    // Update is called once per frame
    void Update()
    {
		if (Application.isEditor)
		{

			moveWithArrowAndMouse();
		}
    }


    //Move with Keyboard Arrow
    void moveWithArrowAndMouse()
    {
        //Keyboard Arrow
        moveCamera(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), RotationSpeed);

        
    }

    //Move Parameters
    float KeyX;
    float KeyY;
    Quaternion localRotation;
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    void moveCamera(float horizontal, float verticle, float moveSpeed)
    {
        KeyX = horizontal;
        KeyY = -verticle;

        rotY += KeyX * moveSpeed;
        rotX += KeyY * moveSpeed;

        localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }

}
