using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 2f;
    [SerializeField] private LayerMask mask;
    private InteractivePlayerUI playerUI;

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<InteractableObject>() != null && Input.GetButtonDown("Interact")) 
            {
                InteractableObject interactable = hitInfo.collider.GetComponent<InteractableObject>();
                interactable.BaseInteract();
            }

            if (hitInfo.collider.GetComponent<InteractableObject>() != null && hitInfo.collider.tag == "Light")
            {
                playerUI.UpdateText(hitInfo.collider.GetComponent<InteractableObject>().promptMessage);
            }
        }
    }
}
