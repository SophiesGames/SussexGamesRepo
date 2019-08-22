using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{

    public static float timer = 0;

    //public static List<GameObject> enemies = new List<GameObject>();

    void Update()
    {
        timer += Time.deltaTime;
    }
}
