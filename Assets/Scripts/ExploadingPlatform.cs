using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploadingPlatform : MonoBehaviour
{

    public GameObject Platform1, Platform2, player;
    private Animator anim1, anim2;
    public float fieldImpact;
    public float force;
    public LayerMask layerToHit;
    public Rigidbody2D rbody2D;

    // Start is called before the first frame update
    void Start()
    {
        anim1 = Platform1.GetComponent<Animator>();
        anim2 = Platform2.GetComponent<Animator>();   
        rbody2D = player.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("collide");
            Explode();
            anim1.SetBool("isExploading", true);
            anim2.SetBool("isExploading", true);
            Destroy(this.gameObject, 1f);

            
        }
    }

    void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldImpact, layerToHit);

        
            Vector2 direction = new Vector2(4f,4f);
           // Debug.Log(direction);

            rbody2D.AddForce(direction*force);
        

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,fieldImpact);

    }
}
