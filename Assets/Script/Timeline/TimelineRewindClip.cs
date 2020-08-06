using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class TimelineRewindClip : PlayableAsset, ITimelineClipAsset
{
    [HideInInspector]
    public TimelineRewindBehavior template = new TimelineRewindBehavior();

    public TimelineRewindBehavior.TimelineRewindAction action;
    public TimelineRewindBehavior.Condition condition;
    public string markerToJumpTo = "", markerLabel = "";
    public float timeToJumpTo = 0f;


    public ExposedReference<ObjectIsClicked> objClicked;

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }


    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<TimelineRewindBehavior>.Create(graph, template);
        TimelineRewindBehavior clone = playable.GetBehaviour();
        clone.objClicked = objClicked.Resolve(graph.GetResolver());

        clone.markerToJumpTo = markerToJumpTo;
        clone.action = action;
        clone.condition = condition;
        clone.markerLabel = markerLabel;
        clone.timeToJumpTo = timeToJumpTo;


        return playable;
    }
}
