using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbSoundTransistion : MonoBehaviour

//This script keeps the gameobject it’s on from being destroyed when loading a new scene and deletes other instances of gameobjects with this script on it. 
//It’s supposed to be used on the gameobject with the ambient sound on it to prevent the music from stopping when the player transitions to a new scene. 
{
    public static AmbSoundTransistion instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
