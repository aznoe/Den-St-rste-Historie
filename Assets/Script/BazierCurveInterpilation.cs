using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazierCurveInterpilation : MonoBehaviour
{
    private GameObject container;

    private GameObject ClickedObject;

    public Transform endPosistion;

    public Transform canvas;

    [SerializeField]
    [Range(0f, 1f)]
    public float t;
    public GameObject waypoint;



    private void Start()
    {

    }




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

        waypoint = new GameObject("waypoint");
        waypoint.transform.position = Vector3.Lerp(ClickedObject.transform.position, new Vector3(endPosistion.transform.position.x, endPosistion.transform.position.y, endPosistion.transform.position.z), 0.5f);
        waypoint.transform.localScale = ClickedObject.transform.localScale;
    }

    private void Update()
    {
        if (t > 0 || t < 1)
        {
            LERP();
            Debug.Log("LERP");
        }
    }

    public void LERP()
    {
        //ClickedObject.transform.position = Vector3.Lerp(container.transform.position, endPosistion.position, transition);


        // Three points point1-3
        Vector3 AB = Vector3.Lerp(container.transform.position, waypoint.transform.position, t);
        Vector3 BC = Vector3.Lerp(waypoint.transform.position, endPosistion.transform.position, t);
        ClickedObject.transform.position = Vector3.Lerp(AB, BC, t);





        ClickedObject.transform.rotation = Quaternion.Lerp(container.transform.rotation, endPosistion.rotation, t);
        Vector3 ABS = Vector3.Lerp(container.transform.localScale, waypoint.transform.localScale, t);
        Vector3 BCS = Vector3.Lerp(waypoint.transform.localScale, new Vector3(canvas.transform.localScale.x * endPosistion.transform.localScale.x, canvas.transform.localScale.y * endPosistion.transform.localScale.y, canvas.transform.localScale.z * endPosistion.transform.localScale.z), t);
        ClickedObject.transform.localScale = Vector3.Lerp(ABS , BCS, t);


    }

    public void Destroy()
    {
        //Destroys container and waypoint with 0 seconds of delay
        Destroy(container, 0);
        Destroy(waypoint, 0);

    }


}
