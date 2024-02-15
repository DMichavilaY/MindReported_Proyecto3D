using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : InteractableObject
{
    private Animator doorAnimation;
    private bool doorOpen = false;
    private float animationTime;
    void Awake()
    {
        doorAnimation = GetComponent<Animator>();
    }

    protected override void Interact()
    {
       animationTime = doorAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime;
       if (animationTime >= 1)
        {
            if (doorOpen == false)
            {
                doorAnimation.PlayInFixedTime("Open");
                doorOpen = true;

            }
            else if (doorOpen == true)
            {
                doorAnimation.PlayInFixedTime("Close");
                doorOpen = false;
            }
        }

    }
}
