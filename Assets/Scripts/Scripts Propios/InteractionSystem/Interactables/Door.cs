using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    private Animator doorAnimation;
    private bool doorOpen = false;
    void Start()
    {
        doorAnimation = GetComponent<Animator>();
    }

    protected override void Interact()
    {
        if (doorOpen == false) 
        {
            doorAnimation.PlayInFixedTime("Open");
            doorOpen = true;
        
        } else if (doorOpen == true)
        {
            doorAnimation.PlayInFixedTime("Close");
            doorOpen = false;
        }

    }
}
