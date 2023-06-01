using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle; //Since the object we will create is an existing obstacle, we created a variable that we can access from an editor with the GameObject command.
    // Start is called before the first frame update
    public float maxTime; /*If we do the continuous object creation in the Start function, it will create it once.
                            If we do it in the Update function; creates continuously.
                           So we need to create a Timer.
                            We have defined the maxTimer variable that we will control over the editor.*/
    float timer;
    public float maxY; //maximum rise rate obstacle
    public float minY; //minumum increase rate obstacle
    float randomY;
    void Start()
    {
        InstantiateObstacle(); 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;//We added time.Deltatime so that our timer works properly.
        if(timer >= maxTime)
        {
            randomY = Random.Range(minY,maxY);
            InstantiateObstacle();
            timer = 0;
        }
    }

    public void InstantiateObstacle() //our function to create new objects.
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, randomY);
    }
}
