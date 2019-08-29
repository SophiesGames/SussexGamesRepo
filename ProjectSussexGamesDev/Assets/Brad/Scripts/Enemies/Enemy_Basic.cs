using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Basic : MonoBehaviour
{
    [HideInInspector]
    public float size = 50;

    [SerializeField]
    private float maxSpeed = 10;
    [SerializeField]
    private float minSpeed = 1;

    [HideInInspector]
    public float speed = 5;
    [HideInInspector]
    public Vector3 dir;
    [HideInInspector]
    public bool freeze = false;

    float timer = 0;
    float changeTime = 0;




	// Start is called before the first frame update
	void Start()
    {
        //setSize(Random.Range(5, 50));
        changeTime = Random.Range(0, 3);
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (freeze == false)
        {
            //Every X amount of time the direction is changed
            if (timer >= changeTime) {
                dir = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)).normalized;
                changeTime = Random.Range(0, 3);
                timer = 0;
            } else {
                timer += Time.deltaTime;
            }
            //Moving the enemy
            transform.position = Vector3.Slerp(transform.position, transform.position + dir, speed / 100);
            transform.localScale = new Vector3((size / 50) * 2, (size / 50) * 2, (size / 50) * 2);
            //print("enemy" + size);
        }
        else
        {
            timer += Time.deltaTime;
        }
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);

    }



	public void setSize(float targetSize)
    {
        size = targetSize;
        transform.localScale = new Vector3((size / 50) * 2, (size / 50) * 2, (size / 50) * 2);
    }

    public void randomSpeed()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }





}
