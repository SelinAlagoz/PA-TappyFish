using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed; //We need a speed for ground so we defined a speed variable.then we will call this variable regularly in update.
    // Start is called before the first frame update
    BoxCollider2D box; /*We will take the size of the outgoing ground object, assign it to a variable.
                         We want to access Box collider 2d , we get the box value from it.*/
    float groundWidth; 
    float obstacleWidth;
    void Start()
    {
        if(gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundWidth = box.size.x; //We take the value of x because we need the width.
        }
        else if(gameObject.CompareTag("Obstacle"))
        {
            obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
      if(GameManager.gameOver == false) //If the game is not finished, do this.
      {
        transform.position = new Vector2 (transform.position.x - speed * Time.deltaTime, transform.position.y);  //Since the update function can change according to the operating speed of our computer, we use time*deltatime. In this way, it always works in the same time interval.
          /*!!!My first mistake; I unconsciously wrote the transform.position code in the start function, which caused it to go 3 units to the left and leave it in a single frame,
           When I got the update, our place was constantly slipping from under our feet, as it was constantly running in every frame.!!! */
      }
      
      if(gameObject.CompareTag("Ground"))
      {
         if(transform.position.x <= -groundWidth) //if our current position is small and equal to the width of the ground
        {
        transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);
        /*After this variable reaches a certain point, we will make it go back to the beginnig.
          Thus,while two ground objectsj are moving, they will continue to complement each other when one reaches the boundary.
          The value "2" here is because we have two grounds.*/
        }     
      }
      else if (gameObject.CompareTag("Obstacle"))
      {
        if(transform.position.x < GameManager.bottomleft.x - obstacleWidth)
            {
                Destroy(gameObject);
            }
        }
      }
      
    }

