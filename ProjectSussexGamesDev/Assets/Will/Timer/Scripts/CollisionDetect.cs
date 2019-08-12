using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
   
    private void onTriggerEnter(Collider2D other)
    {
        GameObject.Find("player").SendMessage("Finish");
    }
}
