using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


    [CustomEditor(typeof (camera_follow))]
public class camera_follow_editor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        camera_follow ef = (camera_follow)target;
        if (GUILayout.Button("Set Min Cam Positon"))
        {
            ef.SetMinCamPosition();
        }

        if (GUILayout.Button("Set Max Cam Positon"))
        {
            ef.SetMaxCamPostion();
        }

    }
}

