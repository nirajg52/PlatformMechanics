using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    public PlayerController playerController;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerController.jumpForce = 900;
            anim.SetBool("trampolineOn", true);
            
        }
        

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerController.jumpForce = 600;
        anim.SetBool("trampolineOn", false);
    }

}
