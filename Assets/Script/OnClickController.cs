using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickController : MonoBehaviour
{
    //check if the object is clickable.
    public bool isClickable { get; set; } = true;

    public GameObject lastClickedObject;

    public bool timelineActive;

    private bool tempPhysics;

    private RaycastHit hit;

    private Ray ray;

    // Update is called once per frame
    void Update()
    {
        //if the object is clickable and the mouse is clicked/touched
        if (isClickable && Input.GetMouseButtonDown(0))
        {
            //using raycast to determin if the object hit
            //RaycastHit hit;
            //cast a ray from the camera in the direction where there is a click/touch
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (timelineActive){
                if (Physics.Raycast(ray, out hit, 3))
                {
                    //Debug.Log("FIN");
                    if(hit.transform != null)
                    {
                        //since we are using sprites we use a box colider to aim for.
                        BoxCollider rb;
                        if(rb = hit.transform.GetComponent<BoxCollider>())
                        {
                            lastClickedObject = hit.transform.gameObject;

                            
                            ClickOnGameObject(hit.transform.gameObject);
                                    
                        }
                    }
                }
            } 

            else
            
            {
                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.Log("INF");
                    if(hit.transform != null)
                    {
                        //since we are using sprites we use a box colider to aim for.
                        BoxCollider rb;
                        if(rb = hit.transform.GetComponent<BoxCollider>())
                        {
                            lastClickedObject = hit.transform.gameObject;

                            
                            ClickOnGameObject(hit.transform.gameObject);
                                    
                        }
                    }
                }
                
            }
        }
    }


    //method that sends you to the abstract class and then to the object with the OnClick() function.
    void ClickOnGameObject(GameObject g)
    {
        //check if the object has the OnClick() function with the "?"
        g.GetComponent<BaseInteractive>()?.OnClicked();
        
    }


  
 



   
}
