using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script handles all the movement and interactions made while exploring
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f; //sets player's movement speed
    private bool facingRight = true; //checks if player is facing right


    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    //Player movement
    void Move()
    {
        var movement = Input.GetAxis("Horizontal");
        if (movement == 0.0f)
        {
            //set idle animation
        }
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed;
        //set walk animation

        //If input is moving right but facing left
        if (movement > 0 && !facingRight)
        {
            Flip();
        }
        //If input is moving left but facing right
        else if (movement < 0 && facingRight)
        {
            Flip();
        }
    }

    //Flips the sprite when moving on the other direction
    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;


        //Debug.Log("Character flipped");
    }

    //Handles triggers
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            //TODO: changes game scene to the fight scene with the enemy gameobject telling us which enemies it is
            Debug.Log("Enemy encountered!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.tag == "TrapZone")
        {
            //TODO: gives the player the chance to disarm the trap, turns on UI to disarm trap
            Debug.Log("Trap available to be disarmed");
        }

        if (other.tag == "Trap")
        {
            //TODO: deals whatever value of damage the trap does
            Debug.Log("Trap activated");
        }

        if (other.tag == "Treasure")
        {
            //TODO: turns on UI to get treasure
            Debug.Log("Treasure nearby");
        }

    }
}
