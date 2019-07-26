using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Basic : MonoBehaviour
{

    public float size = 0;

    Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        size = Random.Range(1, 50);
        transform.localScale = new Vector3((size / 50) * 2, (size / 50) * 2, (size / 50) * 2); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
