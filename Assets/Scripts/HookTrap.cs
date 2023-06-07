using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookTrap : MonoBehaviour
{
     public GameObject upHookPrefab;
     public GameObject downHookPrefab;
    public UpHook upHook;
    public float spawnDistance = 4f;
   // public float firstspawnYerX = -0.88f;
   // public float secondspawnYerX = -2.33f;
    public float minSpawnX = -4f;
    public float maxSpawnX = 4f;
   public Vector2 spawnPosition;
   public Vector2 opSpawnPosition;
   public Transform downSpawnPoint ;

    private float Timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        if (GameManager.gameOver == false && GameManager.gameStarted == true)
        {
              
              Timer += Time.deltaTime;

           if (Timer >= spawnDistance)
           {
           
           InstantiateHook();

            Timer = 0f;
           }
       }
   }
   public void InstantiateHook()
   {   
            float spawnX = Random.Range(-4f, 4f);
            float spawnXx = Random.Range(-4f, 4f);
            GameObject upHook = Instantiate(upHookPrefab,new Vector2(spawnX,spawnPosition.y),Quaternion.identity);
            GameObject downHook = Instantiate(downHookPrefab, new Vector2(spawnXx,opSpawnPosition.y), Quaternion.Euler(0, 0, -180f));
   }
}