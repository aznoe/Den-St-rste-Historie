using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HoldDownButton : MonoBehaviour
{

    private float holdDownTimeStart;
    
    private bool buttonIsDown;

    public float waitTime;

    public Image fillImage;

    public bool timeLineIsRunning;

    void Awake()
    {
        fillImage.fillAmount = 0;
        timeLineIsRunning = false;
        
    }


    // Update is called once per frame
    void Update()
    {
       //Notes down the time of when the player pressed the button 
       if(timeLineIsRunning)
       {
            if(Input.GetButtonDown("Jump")||OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                holdDownTimeStart = Time.time;
                buttonIsDown = true;
                fillImage.fillAmount = 0;
            }

            //Runs while the button is still being held down and when the button has been down for more than waitTime skips the timeline
            if (buttonIsDown && Input.GetButton("Jump")||OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && buttonIsDown)
            {
                float holdDownTime = Time.time - holdDownTimeStart; 
                fillImage.fillAmount = holdDownTime / waitTime + 0.01f;

                //Runs when waitTime has been reached
                if (waitTime <= holdDownTime)
                {
                    //SKIP TIL SLUT TIMELINE HER
                    Debug.Log("Skip timeline");
                    buttonIsDown = false;
                    fillImage.fillAmount = 0;
                    ObjectIsClicked clicked = gameObject.GetComponent<ObjectIsClicked>();
                    clicked.OnClicked();
                }
            }

            //Hides the fill image when the player stop pressing the button
            if (Input.GetButtonUp("Jump")||OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                fillImage.fillAmount = 0;
                Debug.Log("UP");

            }
       }

        //Turns back the scene to Scene at index 0 when button 2 is held down
       if(OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad)||Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire 1 is down");
            holdDownTimeStart = Time.time;
            buttonIsDown = true;
            fillImage.fillAmount = 0;

        }
        if (buttonIsDown && Input.GetButton("Fire1")||OVRInput.Get(OVRInput.Button.PrimaryTouchpad) && buttonIsDown)
                {
                    
                    float holdDownTime = Time.time - holdDownTimeStart; 
                    fillImage.fillAmount = holdDownTime / waitTime + 0.01f;
                    Debug.Log(holdDownTime / waitTime);

                    //Runs when waitTime has been reached
                    if (waitTime <= holdDownTime)
                    {
                        SceneManager.LoadScene(0);
                    }
                }
            

            if (Input.GetButtonUp("Fire1")||OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
            {
                fillImage.fillAmount = 0;

            }
        
    }

    public void TimeLineIsRunning()
    {
        if(!timeLineIsRunning)
        {
            timeLineIsRunning = true;
            Debug.Log(timeLineIsRunning);
        }
        else
        {
            timeLineIsRunning = false;
            Debug.Log(timeLineIsRunning);
        }
        fillImage.fillAmount = 0;

    }
   
}
