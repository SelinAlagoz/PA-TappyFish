using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static Vector2 bottomleft;
    // Start is called before the first frame update

    private void Awake()
    {
        bottomleft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
