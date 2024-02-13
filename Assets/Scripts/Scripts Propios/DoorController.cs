using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteractive
{
    private Animator animObject;
    private bool openObject;

    private void Start()
    {
        animObject= GetComponent<Animator>();
    }


    private void Open()
    {

    }

    public void Use()
    {
        Open();
    }

}

