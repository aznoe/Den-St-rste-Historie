using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIsClicked : BaseInteractive
{


    public bool isClicked = false;

    //the camera in the scene with the script OnClickController
    public GameObject clickController;
    public float invokeDelayDuration = 2f;

    void Start()
    {

        if (Camera.main.GetComponent<OnClickController>())
        {
            clickController = Camera.main.gameObject;
        }
        else
        {
            GameObject pointController = GameObject.FindGameObjectWithTag("Pointer").gameObject;
            clickController = pointController;
        }

    }

    internal bool CheckIfIsClicked()
    {
        if (isClicked)
        {   //return true to timelineRewind scripts making it continue in the timeline and not rewind to the marker
            return true;
        }
        else
        {   //return false to the timelineRewind scripts making it rewinding to the marker in the timeline. 
            return false;
        }
    }


    //method from the inhereted class baseInteractive
    public override void OnClicked()
    {
        if(isClicked == false)
        {
            
            //toggle the isClicked from true to false
            isClicked = !isClicked;
            //sending the bool
            CheckIfIsClicked();

            //set the isClicked = false.
            Invoke("DisableIsClicked", invokeDelayDuration);
        
        }


    }

    //changes the isClicked variable, with the purpos of changing it back to false so the timeline can be replayed when the timeline is reset.
    void DisableIsClicked()
    {
        isClicked = !isClicked;

    }

}
