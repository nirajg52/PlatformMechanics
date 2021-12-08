using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatfromScript : MonoBehaviour
{

    public BoxCollider2D collider;
    public GameObject player;
    public GameObject facingWhere;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= facingWhere.transform.position.y )
        {
            collider.isTrigger = true;

        }
        else
        {
            collider.isTrigger = false;
        }


    }
}
