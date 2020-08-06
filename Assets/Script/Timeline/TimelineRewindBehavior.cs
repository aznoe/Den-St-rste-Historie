using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineRewindBehavior : PlayableBehaviour
{
    public TimelineRewindAction action;

    public Condition condition;

    public string markerToJumpTo, markerLabel;
    public float timeToJumpTo;
    [SerializeField]
    public ObjectIsClicked objClicked;

    [HideInInspector]
    public bool clipExecuted = false; // mixer executes this

    public bool ConditionMet()
    {
        switch (condition)
        {
            case Condition.Always:
                return true;

            case Condition.ObjectIsClicked:
                if (objClicked != null)
                {
                    return !objClicked.CheckIfIsClicked();
                }
                else
                {
                    return false;
                }

            case Condition.JumpWhenClicked:
                
                if(objClicked != null)
                {
                    return objClicked.CheckIfIsClicked();
                }
                else
                {
                    return true;
                }
                

            case Condition.Never:
            default:
                return false;

        }
    }


    public enum TimelineRewindAction
    {
        Marker,
        JumpToTime,
        JumpToMarker,
        Pause
    }

    public enum Condition
    {
        Always,
        Never,
        ObjectIsClicked,
        JumpWhenClicked
    }


}
