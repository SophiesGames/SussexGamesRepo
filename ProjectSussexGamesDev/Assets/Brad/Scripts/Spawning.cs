using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    public float spawnDelay = 5;
    public float reduceDelay = 10;

    int previousTimerAmount = 0;

    public GameObject enemy;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(Mathf.RoundToInt(GameInfo.timer) + " " + reduceDelay + " " + previousTimerAmount);
        if(Mathf.RoundToInt(GameInfo.timer)%spawnDelay == 0 && Mathf.RoundToInt(GameInfo.timer) != previousTimerAmount){
            print(Mathf.RoundToInt(GameInfo.timer));
            print("Spawning");

            float[] x = new float[3];

            x[0] = Random.Range(10, 15);
            x[1] = Random.Range(-15, -10);
            x[2] = 0;

            float[] y = new float[3];

            y[0] = Random.Range(6, 11);
            y[1] = Random.Range(-11, -6);
            y[2] = 0;
            Vector3 spawnPosition = new Vector3(player.position.x + x[Random.Range(0, 3)], player.position.y + y[Random.Range(0, 3)]);

            GameObject newEnemy = Instantiate(enemy);
            newEnemy.transform.position = spawnPosition;
            GameInfo.enemies.Add(newEnemy);

            if(Mathf.RoundToInt(GameInfo.timer)%reduceDelay == 0)
            {
                print("Reduce");
                if(spawnDelay > 1){
                    spawnDelay -= 1;
                }
            }

            previousTimerAmount = Mathf.RoundToInt(GameInfo.timer);
        }
        
    }
}
