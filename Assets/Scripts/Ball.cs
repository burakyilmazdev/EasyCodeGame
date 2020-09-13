using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameObject t;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "water")
        {
            t = GameObject.FindGameObjectWithTag("ball");
            Destroy(t);

        }
    }
}
