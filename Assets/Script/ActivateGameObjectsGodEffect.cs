using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObjectsGodEffect : MonoBehaviour
{

   
    public GameObject[] sceneObjectStones;
    public GameObject[] sceneObjectPlants;
    public GameObject[] sceneObjectSealife;
    [HideInInspector]
    public GameObject currentSceneObjToSpawn;

    [Range(0f,0.2f)]
    public float duration;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    IEnumerator ActivateStones()
    {

        for (int i = 0; i < sceneObjectStones.Length; i++)
        {
            float currentDuration = duration;
            currentSceneObjToSpawn = sceneObjectStones[i];
            Debug.Log("Current Scene Object to spawn " + currentSceneObjToSpawn.name);
            currentSceneObjToSpawn.SetActive(true);
            float decreaceTimeWith = Random.Range(0.01f,0.09f);

            currentDuration -= decreaceTimeWith;
            Debug.Log("Duration " + currentDuration);





            yield return new WaitForSeconds(currentDuration);


        }
    }

    IEnumerator ActivatePlants()
    {

        for (int i = 0; i < sceneObjectPlants.Length; i++)
        {
            float currentDuration = duration;
            currentSceneObjToSpawn = sceneObjectPlants[i];
            Debug.Log("Current Scene Object to spawn " + currentSceneObjToSpawn.name);
            currentSceneObjToSpawn.SetActive(true);
            float decreaceTimeWith = Random.Range(0.01f, 0.09f);

            currentDuration -= decreaceTimeWith;
            Debug.Log("Duration " + currentDuration);





            yield return new WaitForSeconds(currentDuration);


        }
    }
    IEnumerator ActivateSealife()
    {

        for (int i = 0; i < sceneObjectSealife.Length; i++)
        {
            float currentDuration = duration;
            currentSceneObjToSpawn = sceneObjectSealife[i];
            Debug.Log("Current Scene Object to spawn " + currentSceneObjToSpawn.name);
            currentSceneObjToSpawn.SetActive(true);
            float decreaceTimeWith = Random.Range(0.01f, 0.09f);

            currentDuration -= decreaceTimeWith;
            Debug.Log("Duration " + currentDuration);





            yield return new WaitForSeconds(currentDuration);


        }
    }
    public void StartSpawningStones()
    {
        StartCoroutine(ActivateStones());
    }

    public void StartSpawningPlants()
    {
        StartCoroutine(ActivatePlants());
    }

    public void StartSpawningSealife()
    {
        StartCoroutine(ActivateSealife());
    }
}
