using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) == true)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
