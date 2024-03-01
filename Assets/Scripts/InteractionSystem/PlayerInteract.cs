using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 2f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private InteractivePlayerUI playerUI;
    [SerializeField] private Image crosshair;

    [SerializeField] private AudioSource flashlightSound;
    [SerializeField] private AudioClip flashlightClip;

    private NoteController noteController;
    private KeyLogic keyLogic;
    private FuseBoxLogic fuseBoxLogic;
    private KeyPadLogic keyPadLogic;

    private bool flashlightActive = false;
    private GameObject[] flashlights2;
    [SerializeField] private GameObject lightFPS;
    private bool canToggleFlashlight = false;
    void Start()
    {
        flashlights2 = GameObject.FindGameObjectsWithTag("Flashlight2");
        SetFlashlights2Active(false);  // Desactiva los objetos con el tag "Flashlight2" al inicio
        lightFPS.SetActive(false);
    }
    void Update()
    {
        playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            CrosshairColor(true);

            //Interactuar con notas
            if (hitInfo.collider.GetComponent<NoteController>() != null)
            {
                noteController = hitInfo.collider.GetComponent<NoteController>();
                if (Input.GetButtonDown("Interact"))
                {
                    noteController.ShowNote();
                }
            }

            //Interactuar con tu entorno
            if (hitInfo.collider.GetComponent<InteractableObject>() != null) 
            {
                if (Input.GetButtonDown("Interact"))
                {
                    InteractableObject interactable = hitInfo.collider.GetComponent<InteractableObject>();
                    interactable.BaseInteract();
                }

            }

            //Interactuar con la linterna
            if (hitInfo.collider.tag == "Light")
            {
                playerUI.UpdateText("Aprieta la E para interactuar con tu entorno");

                if (Input.GetButtonDown("Interact"))
                {
                    hitInfo.collider.gameObject.SetActive(false);
                    SetFlashlights2Active(true);
                    lightFPS.SetActive(true);
                    canToggleFlashlight = true;
                    lightFPS.SetActive(true);
                }
            }

            //Interactuar con la llave
            if (hitInfo.collider.GetComponent<KeyLogic>() != null)
            {
                keyLogic = hitInfo.collider.GetComponent<KeyLogic>();

                if (Input.GetButtonDown("Interact"))
                {
                    keyLogic.GetKey();
                }
            }

            //Interactuar con la caja de fusibles
            if(hitInfo.collider.GetComponent<FuseBoxLogic>() != null)
            {
                fuseBoxLogic = hitInfo.collider.GetComponent<FuseBoxLogic>();
                
                if (Input.GetButtonDown("Interact"))
                {
                    fuseBoxLogic.UseFuseBox();
                }
            }

            //Interactuar con el KeyPad
            if(hitInfo.collider.GetComponent<KeyPadLogic>() != null)
            {
                keyPadLogic = hitInfo.collider.GetComponent<KeyPadLogic>();

                if (Input.GetButtonDown("Interact"))
                {
                    keyPadLogic.UseKeyPad();
                }
            }
        }
        else
        {
            CrosshairColor(false);
        }


        if (Input.GetButtonDown("Flashlight") && canToggleFlashlight)
        {
            lightFPS.SetActive(!lightFPS.activeSelf);
        }


        if(flashlightActive == true) 
        {
            if (Input.GetButtonDown("Flashlight"))
            {
                flashlightSound.PlayOneShot(flashlightClip);
            }
        }
    }

    void ToggleFlashlight()
    {
        GameObject[] flashlights = GameObject.FindGameObjectsWithTag("Light");

        if (flashlights.Length > 0)
        {
            foreach (GameObject flashlight in flashlights)
            {
                flashlight.SetActive(!flashlight.activeSelf);  // Invierte el estado de la linterna
            }

            flashlightActive = !flashlights[0].activeSelf;
        }
    }

    void ToggleFlashlight2()
    {
        // Esta función se encargará de manejar la lógica específica de activar/desactivar objetos con el tag "Flashlight2"
        // Puedes personalizarla según tus necesidades.
    }

    void SetFlashlights2Active(bool active)
    {
        foreach (GameObject flashlight2 in flashlights2)
        {
            flashlight2.SetActive(active);  // Activa o desactiva los objetos con el tag "Flashlight2"
        }

        flashlightActive = active;
    }

    void CrosshairColor(bool on)
    {
        if (on)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.grey;
        }
    }
}
