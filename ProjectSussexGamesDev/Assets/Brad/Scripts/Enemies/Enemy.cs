using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [HideInInspector]
    public float size = 50;

    [SerializeField]
    private float maxSpeed = 10;
    [SerializeField]
    private float minSpeed = 1;

    [HideInInspector]
    public float speed = 5;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSize(float targetSize)
    {
        size = targetSize;
        transform.localScale = new Vector3((size / 50) * 2, (size / 50) * 2, (size / 50) * 2);
    }

    public void setPointingDirection(Vector3 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }

    public void randomSpeed()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    public void scaleSpeed()
    {

        float s = Mathf.Lerp(minSpeed, maxSpeed, GameInfo.timer/100);

        speed = s;
        print(speed);
    }
}
