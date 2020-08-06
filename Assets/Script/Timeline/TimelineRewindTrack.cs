using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.7366781f, 0.3261246f, 0.8529412f)]
[TrackClipType(typeof(TimelineRewindClip))]
public class TimelineRewindTrack : TrackAsset
{

    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        var scriptPlayable = ScriptPlayable<TimelineRewindMixerBehavior>.Create(graph, inputCount);


        TimelineRewindMixerBehavior b = scriptPlayable.GetBehaviour();
        b.markerClips = new System.Collections.Generic.Dictionary<string, double>();


        //This foreach will rename clips based on what they do, and collect the markers and put them into a dictionary
        //Since this happens when you enter Preview or Play mode, the object holding the Timeline must be enabled or you won't see any change in names
        foreach(var c in GetClips())
        {
            TimelineRewindClip clip = (TimelineRewindClip)c.asset;
            string clipName = c.displayName;

            switch (clip.action)
            {
                case TimelineRewindBehavior.TimelineRewindAction.Pause:
                    clipName = "||";
                    break;

                case TimelineRewindBehavior.TimelineRewindAction.Marker:
                    clipName = "● " + clip.markerLabel.ToString();

                    //Insert the marker clip into the Dictionary of markers
                    if (!b.markerClips.ContainsKey(clip.markerLabel)) //happens when you duplicate a clip and it has the same markerLabel
                    {
                        b.markerClips.Add(clip.markerLabel, (double)c.start);
                    }
                    break;


                case TimelineRewindBehavior.TimelineRewindAction.JumpToMarker:
                    clipName = "↩︎  " + clip.markerToJumpTo.ToString();
                    break;

                case TimelineRewindBehavior.TimelineRewindAction.JumpToTime:
                    clipName = "↩︎  " + clip.timeToJumpTo.ToString();
                    break;
            }

            c.displayName = clipName;

        }

        return scriptPlayable;
    }


}
