using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformerController : MonoBehaviour {
    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;


    private bool grounded = false;
    //private Animator anim; //this lets me to control the environment for example -> rotation etc
    private Rigidbody2D rb2d; // this lets the player to be affected by gravity (physical affection)

    private static Vector3 lastPos;
    const int coliderWidth = 1;


    // Use this for initialization
    void Awake()
    {
     //   anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // checking if component hit a line (landed, on the ground)

        InputManager();
        
    }

    float counter = 0;
    void InputManager()
    {
        if (Input.GetKey(KeyCode.Space)&& counter>0.5f)//&& grounded)
        {
            jump = true;
            counter = 0;
        }
        if(Input.GetKey(KeyCode.V))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/map_scene");
        }

        counter += Time.deltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "GrassGround" || collision.gameObject.tag == "StoneGround")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GrassGround" || collision.gameObject.tag == "StoneGround")
        {
            grounded = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GrassGround" || collision.gameObject.tag == "StoneGround")
        {
            grounded = true;
        }
    }


    /** Function is in charge on player's movement
    */
    void FixedUpdate()
    {
        // gets player acceleration value can be from 1 to -1. 
        float h = Input.GetAxis("Horizontal");

        //anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        // if we passed max speed then we will stay at max speed in x (while y stays the same)
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
        
        if (rb2d.position.x <= 0 || rb2d.position.x >= World.width - coliderWidth)
        {
            Debug.Log(rb2d.position);
            Debug.Log("HERE");
            rb2d.velocity = new Vector2(0, 0);
            lastPos.x = (rb2d.position.x <= 0) ? 0 : World.width - coliderWidth;
            rb2d.position = lastPos;
        }
        if (jump)
        {
            Debug.Log("grounded: " + grounded.ToString());
            //anim.SetTrigger("Jump");
            if(grounded)
                rb2d.AddForce(new Vector2(0f, jumpForce));

            jump = false;
        }
        lastPos = transform.position;
    }


    /** 
     * Function flips the player horizontally (x axis) 
     * ya thats basically it.
     */
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
