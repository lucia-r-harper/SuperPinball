using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class Pull : MonoBehaviour
{
    [SerializeField]
    private string pullButton;

    private Animator animator;
    private AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateAnimation();
        UpdateSoundEffect();
	}

    private void UpdateSoundEffect()
    {
        //if (Input.GetButtonUp(pullButton))
        //{
        //    audioSource.Play();
        //}

        if (Input.GetKey(KeyCode.DownArrow))
        {
            audioSource.Play();
        }
    }

    private void UpdateAnimation()
    {
        //if (Input.GetButton(pullButton))
        //{
        //    animator.SetBool("BeingPulled", true);
        //}
        //else
        //{
        //    animator.SetBool("BeingPulled", false);
        //}

        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("BeingPulled", true);
        }
        else
        {
            animator.SetBool("BeingPulled", false);
        }

    }
}
