using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] public float speed;
    [SerializeField] public float jumpForce;
    [SerializeField] public float checkRadius;
    public GameObject spawnpoint; 
    public bool isGrounded;
    public float inputHorizontal;
    public float inputVertical;
    [SerializeField] private Transform groundCheck;
    private bool isFacingright = true;


    [SerializeField] public LayerMask GroundLayerMask;

    private Animator anim;
    private Rigidbody2D rbody2D;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnpoint.transform.position;
        rbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, GroundLayerMask);
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Jump");
    }
    void FixedUpdate()
    {
        rbody2D.velocity = new Vector2(inputHorizontal * speed * Time.deltaTime, rbody2D.velocity.y);
        
       // anim.SetFloat("yVelocity", rbody2D.velocity.y);
        if (isGrounded && inputVertical == 1)

        {
            rbody2D.velocity = Vector2.up * jumpForce * Time.deltaTime;
            



        }
        anim.SetFloat("xVelocity", Mathf.Abs(rbody2D.velocity.x));
        anim.SetFloat("yVelocity", rbody2D.velocity.y);
        anim.SetBool("isNotJumping", isGrounded);





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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            gameObject.transform.position = spawnpoint.transform.position;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        }
    }









}
