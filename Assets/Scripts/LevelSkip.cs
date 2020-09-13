using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSkip : MonoBehaviour
{
    
    AudioSource audioSource;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car1" || collision.gameObject.tag == "plane"|| collision.gameObject.tag == "truck")
        {
            GameManager.instance.Win();
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            Invoke("Load", 3);
            
        }

        

    }
    void Load()
    {
        SceneManager.LoadScene(0);
    }
}
