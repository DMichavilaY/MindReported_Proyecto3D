using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadLogic : MonoBehaviour
{
    [SerializeField] private GameObject keypadCanvas;
    [SerializeField] private SimplePlayerController controller;
    [SerializeField] private Collider doorCollider;

    private Collider keypadCollider;

    private void Start()
    {
        keypadCollider = GetComponent<Collider>();
    }

    public void UseKeyPad()
    {
        keypadCanvas.SetActive(true);
        controller.enabled = false;
    }

    void DisableKeyPad()
    {
        if (Input.GetButtonDown("Exit"))
        {
            keypadCanvas.SetActive(false);
            controller.enabled = true;
        }
    }


    void Update()
    {
        
    }
}
