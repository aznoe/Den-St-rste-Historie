using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroskop : MonoBehaviour
{

    private bool gyroEnable;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rot;

    private void Start()
	{
        //making the main camera a child in an empty object
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        //enabling gyro on the device
        gyroEnable = EnableGyro();
    }


    private bool EnableGyro()
    {
        //check if the device supports gyro
        if (SystemInfo.supportsGyroscope)
        {

            gyro = Input.gyro;
            gyro.enabled = true;

            //after enabling the camera rotate it to not have the scene be sideways
            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0);
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
	{
        //if gyro is on the device roatate the camera arcordingly to the rotation of the gyroscope on the device.
        if (gyroEnable)
        {
            transform.localRotation = gyro.attitude * rot;
        }

	}



}
