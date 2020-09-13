using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectible : MonoBehaviour
{
    RaycastHit nesne;
    private GameObject mainTarget;
    public Controller control;
    Camera cam;
    AudioSource audioSource;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        audioSource = GetComponent<AudioSource>();
        mainTarget = GameObject.FindWithTag("Car1").gameObject;

    }
    
    
    private void OnMouseDown()
    {
       

        
        Ray isik_yolla =cam.ScreenPointToRay(Input.mousePosition);
        Vector3 main = mainTarget.transform.position;
        
        
        if (Physics.Raycast(isik_yolla, out nesne))
        {
                if (nesne.collider.gameObject.tag == "Car1")
                {
                mainTarget = nesne.transform.gameObject;                
                audioSource.Play();
                
                } 

                else if (nesne.collider.gameObject.tag == "plane")
                {

                mainTarget.transform.position = GameObject.FindWithTag("plane").transform.position;
                GameObject.FindWithTag("plane").transform.position = main;
                mainTarget = nesne.transform.gameObject;
                audioSource.Play();
               
                }
                else if (nesne.collider.gameObject.tag == "truck")
                {
                mainTarget.transform.position = GameObject.FindWithTag("truck").transform.position;
                GameObject.FindWithTag("truck").transform.position = main;
                mainTarget = nesne.transform.gameObject;
                audioSource.Play();


            }

            
        }
            
            control.mainTarget = mainTarget;
           
    }
   
}





