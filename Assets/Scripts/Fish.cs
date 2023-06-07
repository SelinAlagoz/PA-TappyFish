using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D _rb;
    [SerializeField] //We use this structure to access and change private variables through the editor.
    private float _speed; //this underscore reminds you that it is private as a typing convention.
    int angle;
    [SerializeField] 
    int maxAngle = 20;
    [SerializeField] 
    int minAngle = -60;
    public Score score;
    bool touchGround;
    public GameManager gameManager;
    public Sprite fishDied;
    public Bubbles bubbles;
    SpriteRenderer sp;
    Animator anim;
    public ObstacleSpawner obstaclespawner;
    [SerializeField] private AudioSource swim, hit, point;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // we transferred our component to the variable we defined.In short,we gave its value.
         sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        _rb.gravityScale = 0; //Since we defined the rigidbody above, we wrote the gravityscale function below it. To stop the fish at the start of the game.
        // now we can access the "Rigidbody2D" variables in unity from here.
       
       
    }

    // Update is called once per frame
    void Update()
    {
      FishSwim();
      
    
    }
    private void FixedUpdate() {
        FishHeadRotation();
    }

    void FishSwim()
    { //function
        if(Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {   swim.Play();
            if(GameManager.gameStarted == false)
            {
                _rb.gravityScale = 2f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
                obstaclespawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else 
            {
              _rb.velocity = Vector2.zero; //Every time we press the left mouse button, we reset our speed before pressing it so that our speed does not change.
              _rb.velocity = new Vector2(_rb.velocity.x,_speed);//We defined the velocity variable as vector2 because; We wonnt have a job on the x-axis.Our fish will move up and down the y-axis.We left the x-axis as is, and we initially launched the y-axis as a float with a power of 9 units.
            }
        }
    }

    void FishHeadRotation(){
                    /*We want the fish to make a movement as it goes up and down.
                  The velocity moves upwards if it is a positive direction and downwards if it is a negative sign. We will check this.
                  For this, we want it to move at a certain angle when going up and at a certain angle when going down. */
        if(_rb.velocity.y > 0) //The y value is important for us as we will look at the up and down position.
        {
            if(angle <= maxAngle)
            {
                angle = angle + 4;
            }
        } 
        else if (_rb.velocity.y < -2.5f)
        {
            if(angle > minAngle)
            {
                angle = angle -2;
            }
        } 
        if(touchGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle); // for angular rotation.
        }
        
    }
   private void OnTriggerEnter2D(Collider2D collision) 
   {
       if(collision.CompareTag("Obstacle"))
       {
           score.Scored();
           point.Play();
           //Debug.Log("Scored!...");
       }
       else if(collision.CompareTag("Column") && GameManager.gameOver == false)
       {
           //game over
           FishDieEffect();
           gameManager.GameOver();
           GameOver();
       }
       else if(collision.CompareTag("Hook") && GameManager.gameOver == false)
       {
           FishDieEffect();
           gameManager.GameOver();
           GameOver();
       }
        
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            if(GameManager.gameOver == false)
            {
                FishDieEffect();
                gameManager.GameOver();
                GameOver();
            }
            
        }
        
    }
    void FishDieEffect()
    {
        hit.Play();
    }
    void GameOver()
    {
        touchGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        anim.enabled = false;
        bubbles.stopBubbles();
    }
    }

