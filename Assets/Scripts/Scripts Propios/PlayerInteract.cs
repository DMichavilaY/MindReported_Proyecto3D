using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject mainCamera;
    private GameObject objectClicked;
    public GameObject flashlight;
    public KeyCode OpenClose;
    public KeyCode Flashlight;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(OpenClose)) // Open and close action
        {
            RaycastCheck();
        }

        if (Input.GetKeyDown(Flashlight)) // Toggle flashlight
        {
            if (flashlight.activeSelf)
                flashlight.SetActive(false);
            else
                flashlight.SetActive(true);
        }
    }

    void RaycastCheck()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, 2.3f))
        {
            if (hit.collider.TryGetComponent(out IInteractive interactive))
            {
                // Debug.Log("Object with SimpleOpenClose script found");
                interactive.Use();
            }

            else
            {
                // Debug.Log("Object doesn't have script SimpleOpenClose attached");

            }
            // Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            // Debug.Log("Did Hit");
        }
        else
        {
            // Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //   Debug.Log("Did not Hit");


        }

    }
}
