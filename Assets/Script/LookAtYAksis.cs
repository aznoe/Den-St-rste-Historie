using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtYAksis : MonoBehaviour
{
    Camera target;

    // Start is called before the first frame update
    void Start()
    {
        //find the target camera 
        target = Camera.main; ;
        TurnToCamera();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void TurnToCamera()
    {

        //if the object is not tagged Gobble the object will rotate to lookAt the object without rotating in the y axis.
        if(!gameObject.CompareTag("Gobble"))
        {
           
            Vector3 cameraPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            transform.LookAt(cameraPosition);
        }
        



    }
}
