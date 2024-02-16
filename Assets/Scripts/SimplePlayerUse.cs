using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerUse : MonoBehaviour
{
    public GameObject mainCamera;
    public KeyCode OpenClose;
    public KeyCode Flashlight;

    private GameObject objectClicked;
    private bool flashlightActive = false;

    private GameObject[] flashlights2;  // Almacena los objetos con el tag "Flashlight2"

    void Start()
    {
        flashlights2 = GameObject.FindGameObjectsWithTag("Flashlight2");
        SetFlashlights2Active(false);  // Desactiva los objetos con el tag "Flashlight2" al inicio
    }

    void Update()
    {
        if (Input.GetKeyDown(OpenClose)) // Open and close action
        {
            RaycastCheck();
        }

        if (Input.GetKeyDown(Flashlight) && flashlightActive) // Toggle flashlight only if it's active
        {
            ToggleFlashlight();
        }
    }

    void RaycastCheck()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, 2.3f))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("Light"))
            {
                hitObject.SetActive(false);  // Desactiva el objeto con el tag "Light"
                SetFlashlights2Active(true);  // Activa objetos con el tag "Flashlight2"
            }
            else if (hitObject.CompareTag("Flashlight2"))
            {
                ToggleFlashlight2();  // Activa/Desactiva el objeto con el tag "Flashlight2"
            }
            else if (hitObject.GetComponent<SimpleOpenClose>())
            {
                hitObject.BroadcastMessage("ObjectClicked");
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
}
