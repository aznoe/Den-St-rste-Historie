using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        Debug.Log("LoadNextScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLastScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

}
