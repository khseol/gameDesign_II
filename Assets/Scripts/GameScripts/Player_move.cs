using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    //allowing tests on appropriate speed and power
    [SerializeField] public int bunny_speed;
    [SerializeField] public int jumpPower;
    private float moveX;
    private Vector2 velocityMove;
    private Rigidbody2D rb;

    private bool facing_left = false;
    private int jumping = 0;
    bool hittingWall = false;
    public GameObject gameManagerObj;
    Manage_Game managerScript;

    public GameObject goalUI;
    public bool reachedGoal = false;
    public AudioSource jump_snd;
    public AudioClip jump_efx;

    // Start is called before the first frame update
    void Start()
    {
        bunny_speed = 6; //player speed will be at a default of 6
        jumpPower = 1000; //default jumping power is 1000
        rb = GetComponent<Rigidbody2D>();
        managerScript = gameManagerObj.GetComponent<Manage_Game>();
        
    }

    // Update is called once per frame
    //checks every second if the player has pressed the right or left, thus flipping the player accordingly.
    void Update() 
    {
        if (Input.GetButtonDown("Jump") && jumping <2)
        {
            jump();
            jumping++;
        }
       //if the player is moving in a positive value direction but the orientation is wrong, flip the player.
        if (Input.GetAxis("Horizontal") < 0 && facing_left == false)
        {
            flip();
        }
        if (Input.GetAxis("Horizontal") > 0 && facing_left == true)
        {
            flip();
        }
        move(hittingWall);

        if (transform.position.y < -10f)
        {
            managerScript.resetScene();
        }
    }

    void move(bool isHittingWall)
    {
        //this code below solves my earlier dilemma with the character spontaneously stopping and won't move further in the current direction it would be going.
        if (isHittingWall == false)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * bunny_speed;
            //Vector3 movePosition = transform.position + movement * Time.deltaTime * bunny_speed;
            //Vector3 smooth = Vector3.Lerp(transform.position, movePosition, bunny_speed * Time.deltaTime);
        }
        //var moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), transform.position.y, 0);
        //rb.MovePosition(new Vector2(transform.position.x + moveVector.x * bunny_speed* Time.deltaTime, transform.position.y));
    }

    void flip()
    {
        facing_left = !facing_left;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    void jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
        jump_snd.PlayOneShot(jump_efx);
    }

    //checking to see if a collision is registered when the player jumps on either ground or platform.
    //this will need to be modified so that it registers that a player can ONLY jump twice before touching the ground
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "grounded")
        {
            //Debug.Log("collided with 'grounded' tag object");
            jumping = 0; //moment player collides with an object is tagged as 'grounded' enable jump = 0
        }

        if (collision.gameObject.tag == "wall")
        {
            hittingWall = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        hittingWall = false;
    }

    void OnTriggerEnter2D(Collider2D star)
    {
        if (star.gameObject.tag == "Safe")
        {
            Debug.Log("REACHED THE END GOAL. display time and return to menu option.");
            goalUI.SetActive(true);
            reachedGoal = true;
        }
    }

    public bool getGoalStatus
    {
        get {
            return reachedGoal;
        }
    }
}
