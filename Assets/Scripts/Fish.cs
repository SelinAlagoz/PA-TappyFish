using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // we transferred our component to the variable we defined.In short,we gave its value.
        // now we can access the "Rigidbody2D" variables in unity from here.
        //rb.gravityScale = 0;
        rb.velocity = new Vector2(rb.velocity.x,9f);//We defined the velocity variable as vector2 because; We wonnt have a job on the x-axis.Our fish will move up and down the y-axis.We left the x-axis as is, and we initially launched the y-axis as a float with a power of 9 units.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
