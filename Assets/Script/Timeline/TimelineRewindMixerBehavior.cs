using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineRewindMixerBehavior : PlayableBehaviour
{

    public Dictionary<string, double> markerClips;
    private PlayableDirector director;

    public override void OnPlayableCreate(Playable playable)
    {
        director = (playable.GetGraph().GetResolver() as PlayableDirector);
    }


    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (!Application.isPlaying)
        {
            return;
        }

        int inputCount = playable.GetInputCount();

        for(int i = 0; i< inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);

            ScriptPlayable<TimelineRewindBehavior> inputPlayable = (ScriptPlayable<TimelineRewindBehavior>)playable.GetInput(i);
            TimelineRewindBehavior input = inputPlayable.GetBehaviour();

            if(inputWeight > 0f)
            {
                if (!input.clipExecuted)
                {
                    switch (input.action)
                    {

                        //since we dont have a pause function we outcommented this function
                        //case TimelineRewindBehavior.TimelineRewindAction.Pause:
                        //  if (input.ConditionMet())
                        //  {
                        //      GameManager.Instance.PauseTimeline(director);
                        //      input.clipExecuted = true;
                        //  }
                        //  break;

                        case TimelineRewindBehavior.TimelineRewindAction.JumpToTime:
                        case TimelineRewindBehavior.TimelineRewindAction.JumpToMarker:
                            if (input.ConditionMet())
                            {
                                if(input.action == TimelineRewindBehavior.TimelineRewindAction.JumpToTime)
                                {
                                    //jump to time
                                    (playable.GetGraph().GetResolver() as PlayableDirector).time = (double)input.timeToJumpTo;
                                }
                                else
                                {
                                    double t = markerClips[input.markerToJumpTo];
                                    (playable.GetGraph().GetResolver() as PlayableDirector).time = t;
                                }

                                input.clipExecuted = false;

                            }
                            break; //we want to jump to happen again
                    }
                }
            }

        }
    }
}
