using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject Panel;
    AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OpenPanel()
    {
        if (Panel != null)
        {
            Animator animator = Panel.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("open");
                animator.SetBool("open", !isOpen);
                audioSource.Play();
            }
        }
    }
}
