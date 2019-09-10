 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPowerupSpawning : MonoBehaviour
{

    public float PowerupCounterIncreaseDelay = 5;

    public int amountOfPowerups = 2;
    public int powerupLimit = 5;

    int previousTimerAmount = 0;

    public GameObject[] powerupPrefab;

    public Transform player;
    private Player playerObj;
    //[HideInInspector]
    public static List<GameObject> powerups = new List<GameObject>();
    public float maxPowerupDist = 50;

    // Start is called before the first frame update
    void Start()
    {
        //powerups = new List<GameObject>();
        //playerObj = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (powerups.Count < amountOfPowerups)
        //{

           // GameObject newPowerup = spawnNewObject(powerupPrefab[Random.Range(0, powerupPrefab.Length)]);
           // powerups.Add(newPowerup);

            //newPowerup.GetComponent<Powerup>();


        //}

        //foreach (GameObject powerup in powerups)
        //{
            //if (Vector3.Distance(player.transform.position, powerup.transform.position) > maxPowerupDist)
            //{
            ///    respawn(powerup, player.gameObject);
            //}
        //}

        //if (Mathf.RoundToInt(GameInfo.timer) % PowerupCounterIncreaseDelay == 0 && Mathf.RoundToInt(GameInfo.timer) != previousTimerAmount && powerups.Count < powerupLimit)
        //{
           // //print(amountOfPowerups + " " + GameInfo.powerups.Count);
           // amountOfPowerups += 1;
           // previousTimerAmount = Mathf.RoundToInt(GameInfo.timer);
       // }

    }

    //GameObject spawnNewObject(GameObject obj)
    //{

        //float[] x = createRadiusRange(10, 15, playerObj);

        //float[] y = createRadiusRange(6, 11, playerObj);

        //Vector3 spawnPosition = new Vector3(player.position.x + x[Random.Range(0, 2)], player.position.y + y[Random.Range(0, 2)]);

        //GameObject newObject = Instantiate(obj, spawnPosition, Quaternion.identity);

        //return newObject;
    //}

    //public static float[] createRadiusRange(float min, float max, Player playerObj)
    //{
        //float MaxDist = max * Mathf.Abs(1 - playerObj.movingVector.normalized.x);
        //float MinDist = min * Mathf.Abs(1 - playerObj.movingVector.normalized.x);

        //float[] x = new float[2];

        //if (MaxDist < max)
        //{
        //    MaxDist = max;
        //}
        //if (MinDist < min)
        //{
        //    MinDist = min;
        //}

        //x[0] = Random.Range(MinDist, MaxDist);
        //x[1] = Random.Range(-MaxDist, -MinDist);

        //return x;
    //}

    //public static void respawn(GameObject obj, GameObject player)
    //{
        //Player playerObj = player.GetComponent<Player>();
        //Powerup powerup = obj.GetComponent<Powerup>();

        //float[] x = createRadiusRange(10, 15, playerObj);

        //float[] y = createRadiusRange(6, 11, playerObj);

        //Vector3 spawnPosition = new Vector3(player.transform.position.x + x[Random.Range(0, 2)], player.transform.position.y + y[Random.Range(0, 2)]);

        //obj.transform.position = spawnPosition;
        //// if (obj.GetComponent<Intelligent_Behaviour>())
        ////{
        ////    powerup.scaleSpeed();
        ////}
        ////else
        ////{
        ////    powerup.randomSpeed();
        ////}
    //}
}