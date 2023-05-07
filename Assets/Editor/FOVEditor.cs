using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyBehavior))]
public class FOVEditor : Editor
{


    private void OnSceneGUI()
    {
        EnemyBehavior fov = (EnemyBehavior)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);

        Vector3 viewAngleLeft = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.viewAngle / 2);
        Vector3 viewAngleRight = DirectionFromAngle(fov.transform.eulerAngles.y, fov.viewAngle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleLeft * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleRight * fov.viewRadius);

        if (fov.canSeePlayer)
        {
            Handles.color = Color.red;
            Handles.DrawLine(fov.transform.position, fov.targetRef.transform.position);
        }

    }

    private Vector3 DirectionFromAngle(float eulerY, float angleDegrees)
    {
        angleDegrees += eulerY;
        return new Vector3(Mathf.Sin(angleDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleDegrees * Mathf.Deg2Rad));
    }
}