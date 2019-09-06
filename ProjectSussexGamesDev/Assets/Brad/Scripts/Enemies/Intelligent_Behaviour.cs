using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intelligent_Behaviour : MonoBehaviour
{

    public float range = 5;

    Vector3 dir;

    Enemy enemy;

    GameObject player;
    Player playerObj;

    float timer = 0;
    float changeTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        changeTime = Random.Range(0, 3);
        player = GameObject.Find("player");
        playerObj = player.GetComponent<Player>();
        enemy = gameObject.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            enemy = gameObject.GetComponent<Enemy>();
        }
        //Every X amount of time the direction is changed
        if (Vector3.Distance(transform.position, player.transform.position) > range)
        {
            if (timer >= changeTime)
            {
                dir = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)).normalized;
                changeTime = Random.Range(0, 3);
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else
        {
            if (enemy.size > playerObj.size && timer >= changeTime)//move towards the player
            {
                dir = -(transform.position - player.transform.position).normalized;
                changeTime = Random.Range(0, 2);
                timer = 0;
            }
            else if(enemy.size <= playerObj.size && timer >= changeTime)//move away from the player
            {
                dir = (transform.position - player.transform.position).normalized;
                changeTime = Random.Range(0, 2);
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        
        //Moving the enemy
        transform.position = Vector3.Slerp(transform.position, transform.position + dir, enemy.speed / 100);
        //print("enemy" + size);

        enemy.setPointingDirection(dir);
    }
}
