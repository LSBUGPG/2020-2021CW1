using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (FieldOfVision))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfVision fov = (FieldOfVision)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.visionRadius);
        Vector3 viewingAngleA = fov.DirFromAngle(-fov.visionAngle / 2, false);
        Vector3 viewingAngleB = fov.DirFromAngle(fov.visionAngle / 2, false);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewingAngleA * fov.visionRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewingAngleB * fov.visionRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTargets in fov.visibleTargets)
        {
            Handles.DrawLine(fov.transform.position, visibleTargets.position);
        }
    }
}
