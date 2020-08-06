using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectsWithTimeline : BaseInteractive
{
    [SerializeField]
    private PopUp show = default;

    public override void OnClicked()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Play");

        if (!gameObject.GetComponent<AudioSource>().isPlaying)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        show.Show();

    }
}
