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

            if (hitObject.CompareTag("Flashlight"))
            {
                ToggleFlashlight();  // Activa/Desactiva el objeto de la linterna
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
        GameObject[] flashlights = GameObject.FindGameObjectsWithTag("Flashlight");

        if (flashlights.Length > 0)
        {
            foreach (GameObject flashlight in flashlights)
            {
                flashlight.SetActive(false);  // Desactiva el objeto con el tag "Flashlight"
            }

            flashlightActive = false;
        }
    }

    void ToggleFlashlight2()
    {
        GameObject[] flashlights2 = GameObject.FindGameObjectsWithTag("Flashlight2");

        if (flashlights2.Length > 0)
        {
            foreach (GameObject flashlight2 in flashlights2)
            {
                flashlight2.SetActive(true);  // Activa el objeto con el tag "Flashlight2"

                // Activa el Mesh Renderer si existe
                MeshRenderer meshRenderer = flashlight2.GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                {
                    meshRenderer.enabled = true;
                }
            }

            flashlightActive = true;
        }
    }
}
