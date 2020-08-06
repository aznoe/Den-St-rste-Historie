using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InteractiveObjects : BaseInteractive
{
    public bool isClicked = false;
    public float clickIsDisabledTime = 2f;
    private Camera mainCamera;

    private void Start()
    {

        mainCamera = Camera.main;

    }
    public override void OnClicked()

    
    {
        
            if (isClicked == false) {
        
                //set isClicked to true to make sure you can't trigger the effects on the object again
                //before clcikIsDisabled has been run
                isClicked = !isClicked;
                

                //Checks for all the different components and runs them if they are avalible 
                if (gameObject.GetComponent<Animator>())
                {
                    gameObject.GetComponent<Animator>().SetTrigger("Play");
                }

                if (gameObject.GetComponent<SpawnParticles>())
                {
                    gameObject.GetComponent<SpawnParticles>().Spawn();
                }

                if (gameObject.GetComponent<SpawnObject>())
                {
                        gameObject.GetComponent<SpawnObject>().Spawn();
                }
                if (gameObject.GetComponent<PlayableDirector>())
                {
                    Debug.Log("PlayableDirector");
                    gameObject.GetComponent<PlayableDirector>().Play();
                }
                
                if (gameObject.CompareTag("Sealife"))
                {
            //mainCamera.GetComponent<ObjectToCamera>().ToCamera();
                mainCamera.GetComponent<BazierCurveInterpilation>().ToCamera();
                }
                if (gameObject.GetComponent<SceneLoader>())
                {
                    gameObject.GetComponent<SceneLoader>().LoadLastScene();
                }
            
                    //time before clicking on the object does something again
                    Invoke("clickIsDisabled", clickIsDisabledTime);
            }

        if (gameObject.GetComponent<AudioSource>())
            {
                gameObject.GetComponent<AudioSource>().Play();

            }
}

    void clickIsDisabled()
    {
        isClicked = !isClicked;
    }

}

