using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Basic : MonoBehaviour
{

    public float size = 0;
    [Range(0, 10)]
    public float speed = 5;

    Vector3 dir;
    float timer = 0;
    float changeTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        size = Random.Range(1, 50);
        transform.localScale = new Vector3((size / 50) * 2, (size / 50) * 2, (size / 50) * 2);
        changeTime = Random.Range(0, 3);
        speed = Random.Range(0.5f, 10);
    }

    // Update is called once per frame
    void Update()
    {
        //Every X amount of time the direction is changed
        if(timer >= changeTime){
            dir = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)).normalized;
            changeTime = Random.Range(0, 3);
            timer = 0;
        } else{
            timer += Time.deltaTime;
        }
        //Moving the enemy
        transform.position = Vector3.Slerp(transform.position, transform.position + dir, speed/100);
    }
}
