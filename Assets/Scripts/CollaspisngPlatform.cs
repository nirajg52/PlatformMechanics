using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollaspisngPlatform : MonoBehaviour
{

   
    private Animator anim;
    public float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetBool("isCollapsing", true);

            Destroy(this.gameObject, destroyTime);

            
            
            
        }
    }

    
}
