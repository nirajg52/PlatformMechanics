using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject waypointObject;
    
    public List<Transform> waypoints;
    
    public float speed;
    private int currentIndex = 0;


    private void Awake()
    {
        waypoints = new List<Transform>();
        foreach (Transform t in transform.parent.GetChild(0))
        {
            waypoints.Add(t);
            if (waypoints.Count > 0)
            {
                transform.position = waypoints[0].position;
            }
        }
    }

    void Update()
    {
        if (waypoints.Count > 1) {

            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentIndex].position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, waypoints[currentIndex].position) < 0.01f)
            {
                currentIndex = (currentIndex + 1) % waypoints.Count;
            }
        }
        
    }

    public void AddNewWaypoints()
    {
        GameObject obj = Instantiate(waypointObject, Vector2.zero, Quaternion.identity);
        obj.transform.SetParent(transform.parent.GetChild(0));
        obj.name = "Waypoint" + waypoints.Count;
        waypoints.Add(obj.transform);
        


    }

    public void RemoveWaypoints(int index)
    {
        waypoints.RemoveAt(index);
        DestroyImmediate(transform.parent.GetChild(1).GetChild(index).gameObject);
    }

    public void ClearWayPoints()
    {

        for ( int i = 0; i < waypoints.Count; i++)
        {
            DestroyImmediate(waypoints[i].gameObject);

        }
        waypoints.Clear();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(gameObject.transform, true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.parent = null;
    }

}
