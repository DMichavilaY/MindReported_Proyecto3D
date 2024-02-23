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

            if (hitInfo.collider.GetComponent<InteractableObject>() != null) 
            {
                crosshair.color = Color.red;

                if (Input.GetButtonDown("Interact"))
                {
                    InteractableObject interactable = hitInfo.collider.GetComponent<InteractableObject>();
                    interactable.BaseInteract();
                }

            }
            else
            {
                crosshair.color = Color.white;
            }

            if (hitInfo.collider.tag == "Light")
            {
                crosshair.color = Color.red;
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
        }
        else
        {
            crosshair.color = Color.white;
        }

        if (Input.GetButtonDown("Flashlight") && canToggleFlashlight)
        {
            lightFPS.SetActive(!lightFPS.activeSelf);
        }

        //if (Input.GetButtonDown("Flashlight") && flashlightActive) // Toggle flashlight only if it's active
        //{
        //    ToggleFlashlight();
        //}
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
}
