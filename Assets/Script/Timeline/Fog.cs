using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class Fog : MonoBehaviour
{

    //for changing fog color
    [SerializeField]
    public Color FogColor;

    //for changing fog dencity
    [SerializeField]
    [Range(0f,1f)]
    public float FogDencity;

    //enables the user to change the fog settings in timeline via animation.
    private void Update()
    {
        
        RenderSettings.fogColor = FogColor;
        
        RenderSettings.fogDensity = FogDencity;

    }



}
