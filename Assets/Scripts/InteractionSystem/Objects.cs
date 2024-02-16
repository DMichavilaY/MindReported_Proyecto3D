using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : InteractableObject
{
    private Animator Animation;
    private bool open;
    private float animationTime;

    [SerializeField] private AudioSource[] openCloseSound;
    [SerializeField] private AudioClip[] openCloseClip;
    void Awake()
    {
        Animation = GetComponent<Animator>();
        openCloseSound[0].playOnAwake = false;
        openCloseSound[1].playOnAwake = false;
    }

    protected override void Interact()
    {
       animationTime = Animation.GetCurrentAnimatorStateInfo(0).normalizedTime;
       if (animationTime >= 1)
        {
            if (open == false)
            {
                openCloseSound[0].PlayOneShot(openCloseClip[0]);
                Animation.PlayInFixedTime("Open");
                open = true;

            }
            else if (open == true)
            {
                Animation.PlayInFixedTime("Close");
                openCloseSound[1].PlayOneShot(openCloseClip[1]);
                open = false;
            }
        }

    }
}
