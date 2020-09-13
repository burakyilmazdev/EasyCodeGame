using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropToWater : MonoBehaviour
{

    private Rigidbody body { get { return GetComponent<Rigidbody>(); } }

    private void OnCollisionEnter(Collision collision)
    {
        
        TextMeshProUGUI code = GameObject.Find("Canvas/Code/Text").GetComponent<TextMeshProUGUI>();
        

        if (collision.gameObject.tag == "water")
        {
            code.text = "if(collision.tag == water){\n" +
                    "LoadScene();}";
            Invoke("LoadSceneMode", 2);
            
        }

        if (collision.gameObject.tag == "ball")
        {
            LoadSceneMode();
        }

        if (collision.gameObject.tag == "path")
        {
            body.isKinematic = true;
            if (transform.localScale.x > 50)
            {
                
                body.isKinematic = false;
                body.velocity = new Vector3(-50, 0, 0);
           

            }
            code.text = "if(car.scale.x>path.scale.x){\n" +
                    "makeitdown();\n" +
                    "}\n" +
                    "else{\n" +
                    "letitgo();}";
        }


    }



    private void LoadSceneMode()
    {
        SceneManager.LoadScene(0);
    }
}
