using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : InteractableObject
{
    private Animator Animation;
    private bool open;
    private float animationTime;
    void Awake()
    {
        Animation = GetComponent<Animator>();
    }

    protected override void Interact()
    {
       animationTime = Animation.GetCurrentAnimatorStateInfo(0).normalizedTime;
       if (animationTime >= 1)
        {
            if (open == false)
            {
                Animation.PlayInFixedTime("Open");
                open = true;

            }
            else if (open == true)
            {
                Animation.PlayInFixedTime("Close");
                open = false;
            }
        }

    }
}
