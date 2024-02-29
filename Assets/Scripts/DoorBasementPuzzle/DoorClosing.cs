using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorClosing : MonoBehaviour
{
    private string objectTag = "Player";
    [SerializeField] private Animator doorAnimation;
    [SerializeField] private Collider doorCollider;
    private AudioSource doorClose;

    private void Start()
    {
        doorClose = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(objectTag))
        {
            doorAnimation.PlayInFixedTime("Close");
            doorClose.Play();
            doorCollider.enabled = false;
            StartCoroutine(DisableAnimation());
        }
    }

    IEnumerator DisableAnimation()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        
    }
}
