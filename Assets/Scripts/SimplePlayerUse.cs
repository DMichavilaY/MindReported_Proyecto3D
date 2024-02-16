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
        if (Input.GetKeyDown(OpenClose))
        {
            RaycastCheck();
        }

        if (Input.GetKeyDown(Flashlight) && flashlightActive)
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
                ToggleFlashlight2();
            }
            else if (hitObject.CompareTag("Flashlight"))
            {
                ToggleFlashlight();
            }
            else if (hitObject.CompareTag("Flashlight2"))
            {
                ToggleFlashlight2();
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
                flashlight.SetActive(!flashlight.activeSelf);
            }

            flashlightActive = !flashlights[0].activeSelf;
        }
    }

    void ToggleFlashlight2()
    {
        GameObject[] flashlights2 = GameObject.FindGameObjectsWithTag("Flashlight2");

        if (flashlights2.Length > 0)
        {
            foreach (GameObject flashlight2 in flashlights2)
            {
                flashlight2.SetActive(!flashlightActive);

                MeshRenderer meshRenderer = flashlight2.GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                {
                    meshRenderer.enabled = !flashlightActive;
                }
            }

            flashlightActive = !flashlights2[0].activeSelf;
        }
    }

    public bool AreFlashlights2Active()
    {
        GameObject[] flashlights2 = GameObject.FindGameObjectsWithTag("Flashlight2");
        return flashlights2.Length > 0 && flashlights2[0].activeSelf;
    }
}
