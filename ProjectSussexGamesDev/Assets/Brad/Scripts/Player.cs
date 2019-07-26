using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float smoothRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            //Vector3 newPlayerPos = Vector3.Slerp(transform.position, mousePos, smoothRate);
            //newPlayerPos.z = 0;
            transform.position += -(transform.position - mousePos)/10;
        }
        
    }
}
