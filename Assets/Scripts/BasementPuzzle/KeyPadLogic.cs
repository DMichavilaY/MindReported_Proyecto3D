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

    private string answer = "09876";
    private Collider keypadCollider;


    private void Start()
    {
        keypadCollider = GetComponent<Collider>();
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
        Cursor.visible = true;
        text.text = "";
    }


    public void Number(int number)
    {
        text.text += number.ToString();
        //button.Play();
    }

    public void Execute()
    {
        if(text.text == answer)
        {
            //correct.Play();
            text.text = "Correcto";
            StartCoroutine(Correct());
        }
        else
        {
            //wrong.Play();
            text.text = "Incorrecto";
            StartCoroutine(DeleteText());
        }
    }

    public void Delete()
    {
        text.text = "";
        //button.Play();
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

        yield return new WaitForSeconds(1);

        keypadCollider.enabled = false;

    }
}
