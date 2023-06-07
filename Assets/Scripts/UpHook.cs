using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpHook : MonoBehaviour
{
    public float speedh = 5f;
    Rigidbody2D _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      _rigidbody = GetComponent<Rigidbody2D>();
      _rigidbody.velocity = Vector2.up * speedh;
      HookRotation();
    }
    public void HookRotation()
    {
          

        if (transform.position.y > Camera.main.transform.position.y + Camera.main.orthographicSize)
        {
             Destroy(gameObject);
        }
    }
}
