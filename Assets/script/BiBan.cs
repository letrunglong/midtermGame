using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiBan : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Buttlet")
        {
            Destroy(gameObject);
        }
    }
}
