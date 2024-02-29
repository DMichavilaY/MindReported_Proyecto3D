using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    [SerializeField] private SimplePlayerController controller;
    [SerializeField] private GameObject panelBackground;
    [SerializeField] private GameObject interactiveNote;
    private AudioSource paperSound;
    private bool isOpen = false;

    private void Start()
    {
        paperSound = GetComponent<AudioSource>();
        interactiveNote.SetActive(false);
    }
    public void ShowNote()
    {
        interactiveNote.SetActive(true);
        controller.enabled = false;
        isOpen = true;
        panelBackground.SetActive(true);
        paperSound.Play();
        
    }

    void DisableNote()
    {
        interactiveNote.SetActive(false);
        controller.enabled = true;
        isOpen = false;
        panelBackground.SetActive(false);
        paperSound.Play();
    }

    private void Update()
    {
        if (isOpen == true) 
        {
            if (Input.GetButtonDown("Exit"))
            {
                DisableNote();
            }
        }
    }
}
