using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (FieldOfHearing))]
public class FieldOfHearingEditor : Editor {

    void OnSceneGUI() {
        FieldOfHearing foh = (FieldOfHearing)target;
        Handles.color = Color.red;
        Handles.DrawWireArc (foh.transform.position, Vector3.up, Vector3.forward, 360, foh.viewRadius);
        Vector3 viewAngleA = foh.DirFromAngle (-foh.viewAngle / 2, false);
        Vector3 viewAngleB = foh.DirFromAngle (foh.viewAngle / 2, false);

        Handles.DrawLine (foh.transform.position, foh.transform.position + viewAngleA * foh.viewRadius);
        Handles.DrawLine (foh.transform.position, foh.transform.position + viewAngleB * foh.viewRadius);

        Handles.color = Color.red;
        foreach (Transform noisyTarget in foh.noisyTargets) {
            Handles.DrawLine (foh.transform.position, noisyTarget.position);
        }
    }

}