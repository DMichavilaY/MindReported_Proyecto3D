using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    [SerializeField] private SimplePlayerController controller;
    [SerializeField] private GameObject panelBackground;
    [SerializeField] private GameObject interactiveNote;
    private bool isOpen = false;

    public void ShowNote()
    {
        interactiveNote.SetActive(true);
        controller.enabled = false;
        isOpen = true;
        panelBackground.SetActive(true);
    }

    void DisableNote()
    {
        interactiveNote.SetActive(false);
        controller.enabled = true;
        isOpen = false;
        panelBackground.SetActive(false);
    }

    private void Update()
    {
        if (isOpen == true) 
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                DisableNote();
            }
        }
    }
}
