using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    public float EnemyCounterIncreaseDelay = 5;

    public int amountOfEnemies = 10;

    [Range(0, 100)]
    public int percentOfSmallerEnemies = 30;

    int previousTimerAmount = 0;

    public GameObject enemyPrefab;

    public Transform player;
    private Player playerObj;
    [HideInInspector]
    public static List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        playerObj = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count < amountOfEnemies)
        {

            GameObject newEnemy = spawnNewObject(enemyPrefab);
            enemies.Add(newEnemy);
            float amountOfSmaller = 0;

            foreach (GameObject enemy in enemies)
            {
                Enemy_Basic eb = enemy.GetComponent<Enemy_Basic>();
                if (eb.size < playerObj.size)
                {
                    amountOfSmaller += 1;
                }
            }
            print(amountOfSmaller + " " + enemies.Count);
            float currentPercent = (amountOfSmaller / enemies.Count)*100;
            print(currentPercent+"%");
            if (currentPercent <= percentOfSmallerEnemies)
            {
                print("Changing size");
                newEnemy.GetComponent<Enemy_Basic>().setSize(Random.Range(1, playerObj.size));
                print("Size: " + newEnemy.GetComponent<Enemy_Basic>().size);
            }
            else
            {
                newEnemy.GetComponent<Enemy_Basic>().setSize(Random.Range(1, 50));
            }

            
        }

        if (Mathf.RoundToInt(GameInfo.timer) % EnemyCounterIncreaseDelay == 0 && Mathf.RoundToInt(GameInfo.timer) != previousTimerAmount)
        {
            //print(amountOfEnemies + " " + GameInfo.enemies.Count);
            amountOfEnemies += 1;
            previousTimerAmount = Mathf.RoundToInt(GameInfo.timer);
        }
            
    }

    GameObject spawnNewObject(GameObject obj)
    {

        float[] x = createRadiusRange(10, 15, playerObj);

        float[] y = createRadiusRange(6, 11, playerObj);

        Vector3 spawnPosition = new Vector3(player.position.x + x[Random.Range(0, 2)], player.position.y + y[Random.Range(0, 2)]);

        GameObject newObject = Instantiate(obj, spawnPosition, Quaternion.identity);

        return newObject;
    }

    public static float[] createRadiusRange(float min, float max, Player playerObj)
    {
        float MaxDist = max * Mathf.Abs(1 - playerObj.movingVector.normalized.x);
        float MinDist = min * Mathf.Abs(1 - playerObj.movingVector.normalized.x);

        float[] x = new float[2];

        if (MaxDist < max)
        {
            MaxDist = max;
        }
        if (MinDist < min)
        {
            MinDist = min;
        }

        x[0] = Random.Range(MinDist, MaxDist);
        x[1] = Random.Range(-MaxDist, -MinDist);

        return x;
    }
}
