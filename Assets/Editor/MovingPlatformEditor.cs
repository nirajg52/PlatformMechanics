using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MovingPlatform))]
public class MovingPlatformEditor : Editor
    {

    public override void OnInspectorGUI()

    {


         MovingPlatform controller = (MovingPlatform)target;

         controller.waypointObject = (GameObject)EditorGUILayout.ObjectField("Waypoint Object",controller.waypointObject, typeof(GameObject),false);

         controller.speed = EditorGUILayout.FloatField("Speed",controller.speed);
         EditorGUILayout.LabelField("Waypoints", EditorStyles.boldLabel);

        if (controller.waypoints != null && controller.waypoints.Count != 0) {
            for(int i = 0; i < controller.waypoints.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                controller.waypoints[i].gameObject.name = EditorGUILayout.TextField(controller.waypoints[i].gameObject.name);
                controller.waypoints[i].position = EditorGUILayout.Vector2Field("", controller.waypoints[i].position);
                if (GUILayout.Button("Delete?"))
                {
                    controller.RemoveWaypoints(i);
                }
                EditorGUILayout.EndHorizontal();
            }
        }

        if(GUILayout.Button("Add Waypoints"))
        {
            controller.AddNewWaypoints();
        }

        if (GUILayout.Button("Clear waypoints")) {
            controller.ClearWayPoints();
        }

    }

}
