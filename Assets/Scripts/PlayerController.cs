using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    [SerializeField] public float speed = 300;
    [SerializeField] public float jumpForce = 600;
    [SerializeField] public float checkRadius = 0.001f;
    public bool isGrounded;
    public float input;
    [SerializeField] private Transform groundCheck;
    private bool isFacingright = true;


    [SerializeField] public LayerMask GroundLayerMask;

    private Animator anim;
    private Rigidbody2D rbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rbody2D.gravityScale = 2.7f;

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, GroundLayerMask);
        input = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate()
    {
       
        rbody2D.velocity = new Vector2(input * speed * Time.deltaTime, rbody2D.velocity.y);
        anim.SetFloat("xVelocity", Mathf.Abs(rbody2D.velocity.x));

        Jump();
        
       
        
        if (isFacingright && rbody2D.velocity.x < 0)
        {
            flip();
        }
        else if (!isFacingright && rbody2D.velocity.x > 0)
        {
            flip();
        }
    }

    void flip()
    {

        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
        isFacingright = !isFacingright;
    }

    void Jump()
    {
        if (isGrounded && Input.GetKey(KeyCode.Space))

        {
            rbody2D.velocity = Vector2.up * jumpForce * Time.deltaTime;
            anim.SetBool("isJumping", true);

        }

        

    }






    
}
