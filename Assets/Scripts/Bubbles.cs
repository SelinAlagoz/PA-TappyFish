using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{
        public Animator bubbles;
        SpriteRenderer spbubbles;

        public Sprite FishDiedBubbles;
        public Fish fish;
    // Start is called before the first frame update
    void Start()
    {
        spbubbles = GetComponent<SpriteRenderer>();
        bubbles = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
       
    }
    public void stopBubbles()
    {
         if(GameManager.gameOver == true)
        {
            bubbles.enabled = false;
        }
      
    }
}
