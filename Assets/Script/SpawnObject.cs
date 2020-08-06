using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpawnObject : MonoBehaviour
{    
    [SerializeField]
    public GameObject[] Animals;

    public GameObject[] TimelineArray;
    public static int AnimalNumber = 0;

    public Transform[] endPosistion;

    public Transform[] canvas;

    [SerializeField]
    [Range(0f,1f)]
    public float transition = 0f;

    //Parrent bliver brugt som startPosistion
    public GameObject parrent;

    public Transform child;

    public Color temp;
    
   void Start()
   {
       AnimalNumber = 0;
   }
   
    private void Update()
    {
        if(parrent != null)
        {
                 if(transition > 0)
                     {Lerp();}
             }
    }



        public void Spawn()
    {
        parrent = Instantiate(Animals[AnimalNumber], transform.position, transform.rotation) as GameObject;
        child = parrent.transform.GetChild(0);
        TimelineArray[AnimalNumber].GetComponent<PlayableDirector>().Play();
        AnimalNumber++;

        //hides the cell the player clicked on
        temp.a = 0f; //This line could be moved up to an awake or start void as it is just a constant value
        gameObject.GetComponent<SpriteRenderer>().color = temp;
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = temp;



    }

    public void Lerp()
    {
        parrent.transform.position = Vector3.Lerp(gameObject.transform.position, endPosistion[AnimalNumber-1].position, transition);
        parrent.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, endPosistion[AnimalNumber-1].rotation, transition);
        //child.transform.localScale = Vector3.Lerp(parrent.transform.localScale, new Vector3(canvas[AnimalNumber-1].transform.localScale.x * endPosistion[AnimalNumber-1].transform.localScale.x, canvas[AnimalNumber-1].transform.localScale.y * endPosistion[AnimalNumber-1].transform.localScale.y, canvas[AnimalNumber-1].transform.localScale.z * endPosistion[AnimalNumber-1].transform.localScale.z), transition);
        parrent.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(canvas[AnimalNumber-1].transform.localScale.x * endPosistion[AnimalNumber-1].transform.localScale.x, canvas[AnimalNumber-1].transform.localScale.y * endPosistion[AnimalNumber-1].transform.localScale.y, canvas[AnimalNumber-1].transform.localScale.z * endPosistion[AnimalNumber-1].transform.localScale.z), transition);

    }

    public void Delete()
    {
        if(parrent != null)
        {
            //changes the childs sorting layer to 1 so it's hidden by the canvas
            child.GetComponent<SpriteRenderer>().sortingOrder = 1;
            //Destroys the cell with this script on it
            gameObject.SetActive(false);
        }
    }



    
}
