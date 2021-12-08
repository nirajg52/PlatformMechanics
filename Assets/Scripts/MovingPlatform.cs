using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    
    public List<Vector2> waypoints;
    
    public float speed;
    private int currentIndex;
    

    void Start()
    {
        currentIndex = 0;
        
    }

    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentIndex], speed * Time.deltaTime);

        if(Vector2.Distance(transform.position,waypoints[currentIndex]) < 0.01f)
        {
            currentIndex = (currentIndex + 1) % waypoints.Count; 
        }
     
        
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
