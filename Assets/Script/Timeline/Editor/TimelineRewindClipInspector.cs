using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TimelineRewindClip))]
public class TimelineRewindClipInspector : Editor
{
    private SerializedProperty actionProp, conditionProp;

    private void OnEnable()
    {
        actionProp = serializedObject.FindProperty("action");
        conditionProp = serializedObject.FindProperty("condition");
    }

    public override void OnInspectorGUI()
    {
        bool isMarker = false; //if it's a marker we don't need to draw any Condition or parameters

        //Action
        EditorGUILayout.PropertyField(actionProp);

        //change the int into an enum
        int index = actionProp.enumValueIndex;
        TimelineRewindBehavior.TimelineRewindAction actionType = (TimelineRewindBehavior.TimelineRewindAction)index;

        switch (actionType)
        {
            case TimelineRewindBehavior.TimelineRewindAction.Marker:
                isMarker = true;
                EditorGUILayout.PropertyField(serializedObject.FindProperty("markerLabel"));
                break;

            case TimelineRewindBehavior.TimelineRewindAction.JumpToMarker:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("markerToJumpTo"));
                break;

            case TimelineRewindBehavior.TimelineRewindAction.JumpToTime:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("timeToJumpTo"));
                break;

            case TimelineRewindBehavior.TimelineRewindAction.Pause:
                break;
        }

        if (!isMarker)
        {
            //condition
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Logic", EditorStyles.boldLabel);

            //changes the int into a enum
            index = conditionProp.enumValueIndex;
            TimelineRewindBehavior.Condition conditionType = (TimelineRewindBehavior.Condition)index;

            //Draws only the appropriate information based on the Condition type
            switch (conditionType)
            {
                case TimelineRewindBehavior.Condition.Always:
                    EditorGUILayout.HelpBox("The above action will always be executed.", MessageType.Warning);
                    EditorGUILayout.PropertyField(conditionProp);
                    break;

                case TimelineRewindBehavior.Condition.Never:
                    EditorGUILayout.HelpBox("The above action will never be executed. Practically, it's as if clip was disabled.", MessageType.Warning);
                    EditorGUILayout.PropertyField(conditionProp);
                    break;

                case TimelineRewindBehavior.Condition.ObjectIsClicked:
                    EditorGUILayout.HelpBox("The above action will be executed if any Unit is Clicked when the playhead reaches this clip.", MessageType.Info);
                    EditorGUILayout.Space();
                    EditorGUILayout.PropertyField(conditionProp);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("objClicked"));
                    break;

                case TimelineRewindBehavior.Condition.JumpWhenClicked:
                    EditorGUILayout.HelpBox("the action will be executed if there is a click within the timeline", MessageType.Info);
                    EditorGUILayout.Space();
                    EditorGUILayout.PropertyField(conditionProp);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("objClicked"));
                    break;
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}