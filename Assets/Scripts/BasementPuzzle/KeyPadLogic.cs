using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPadLogic : MonoBehaviour
{
    [SerializeField] private GameObject keypadCanvas;
    [SerializeField] private SimplePlayerController controller;
    [SerializeField] private Collider doorCollider;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private AudioSource button;
    [SerializeField] private AudioSource correct;
    [SerializeField] private AudioSource wrong;
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioSource doorOpen;

    private string answer = "73925";
    private Collider keypadCollider;


    private void Start()
    {
        keypadCollider = GetComponent<Collider>();
        keypadCanvas.SetActive(false);
    }

    public void UseKeyPad()
    {
        keypadCanvas.SetActive(true);
        controller.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void DisableKeyPad()
    {
        keypadCanvas.SetActive(false);
        controller.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        text.text = "";
    }


    public void Number(int number)
    {
        text.text += number.ToString();
        button.PlayOneShot(buttonClick);
    }

    public void Execute()
    {
        if(text.text == answer)
        {
            correct.Play();
            text.text = "Correcto";
            StartCoroutine(Correct());
        }
        else
        {
            wrong.Play();
            text.text = "Incorrecto";
            StartCoroutine(DeleteText());
        }
    }

    public void Delete()
    {
        text.text = "";
        button.PlayOneShot(buttonClick);
    }
    void Update()
    {
        if (Input.GetButtonDown("Exit"))
        {
            DisableKeyPad();
        }

        if(text.text == "Correcto")
        {
            doorCollider.enabled = true;
        }
    }

    IEnumerator DeleteText()
    {
        yield return new WaitForSeconds(1);

        text.text = "";
    }

    IEnumerator Correct()
    {
        yield return new WaitForSeconds(2);

        DisableKeyPad();
        doorAnimator.PlayInFixedTime("Open");
        doorOpen.Play();

        yield return new WaitForSeconds(1);

        keypadCollider.enabled = false;

    }
}
