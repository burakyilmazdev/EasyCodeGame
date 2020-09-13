using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallPathCollision : MonoBehaviour
{
    private GameObject top;
    int i=0;
    private void Start()
    {
        top = GameObject.FindGameObjectWithTag("ball");
        TextMeshProUGUI code = GameObject.Find("Canvas/Code/Text").GetComponent<TextMeshProUGUI>();

    }

    

    private void OnCollisionEnter(Collision collision)
    {   

        if (collision.gameObject.tag == "Car1" || collision.gameObject.tag == "plane" || collision.gameObject.tag == "truck")
        {
            TextMeshProUGUI code = GameObject.Find("Canvas/Code/Text").GetComponent<TextMeshProUGUI>();
            GameObject.FindGameObjectWithTag("Ballway").SetActive(false);
            Rigidbody body = collision.rigidbody;
            
            Vector3 target = top.transform.position;
            target.x = target.x - 1000;
            LeanTween.moveX(top, target.x, 800);
            code.text = "while(collision.tag != water){\n" +
                "ball.x = ball.x-1;\n" +
                "}";

            

        }


    }
}
