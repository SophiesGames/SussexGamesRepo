using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Basic_Behaviour : MonoBehaviour
{
    Vector3 dir;

    Enemy enemy;

    float timer = 0;
    float changeTime = 0;


	// Start is called before the first frame update
	void Start()
    {
        //setSize(Random.Range(5, 50));
        changeTime = Random.Range(0, 3);
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
        if (timer >= changeTime){
            dir = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)).normalized;
            changeTime = Random.Range(0, 3);
            timer = 0;
        } else{
            timer += Time.deltaTime;
        }
        //Moving the enemy
        transform.position = Vector3.Slerp(transform.position, transform.position + dir, enemy.speed / 100);
        //print("enemy" + size);

        enemy.setPointingDirection(dir);
    }
}
