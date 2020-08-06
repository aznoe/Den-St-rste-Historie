using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToCamera : MonoBehaviour
{
    private GameObject container; 

    private GameObject ClickedObject;

    public Transform endPosistion;

    public Transform canvas;
    
    [SerializeField]
    [Range(0f,1f)]
    public float transition; 

    
    
public void ToCamera()
   {
       //Sets clickedObject to be the last clicked object
       ClickedObject = gameObject.GetComponent<OnClickController>().lastClickedObject;

       //Creats container for the object
       container = new GameObject("Container " + ClickedObject.name);
       Debug.Log(container.name);
       container.transform.position = ClickedObject.transform.position;
       container.transform.rotation = ClickedObject.transform.rotation;
       container.transform.localScale = ClickedObject.transform.localScale;
       

       
           }

    private void Update()
    {
        if(transition > 0 || transition < 1){
            LERP();
            Debug.Log("LERP");
        }
    }

    public void LERP()
    {
        ClickedObject.transform.position = Vector3.Lerp(container.transform.position, endPosistion.position, transition);
        ClickedObject.transform.rotation = Quaternion.Lerp(container.transform.rotation, endPosistion.rotation, transition);
        ClickedObject.transform.localScale = Vector3.Lerp(container.transform.localScale, new Vector3(canvas.transform.localScale.x * endPosistion.transform.localScale.x, canvas.transform.localScale.y * endPosistion.transform.localScale.y, canvas.transform.localScale.z * endPosistion.transform.localScale.z), transition);

        
    }
        

}
