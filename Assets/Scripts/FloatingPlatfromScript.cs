using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatfromScript : MonoBehaviour
{

    public EdgeCollider2D collider;
    public GameObject player;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<EdgeCollider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > 10f)
        {
            collider.isTrigger = false;

        }
        else
        {
            collider.isTrigger = true;
        }


    }
}
