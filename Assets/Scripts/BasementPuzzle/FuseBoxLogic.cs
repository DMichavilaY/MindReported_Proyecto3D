using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FuseBoxLogic : MonoBehaviour
{
    [SerializeField] private Collider basementDoor;
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private AudioSource doorClosing;
    [SerializeField] private GameObject lights;

    private Collider fuseBox;

    private void Start()
    {
        fuseBox = GetComponent<Collider>();
    }

    public void UseFuseBox()
    {
        doorAnimator.Play("Close");
        basementDoor.enabled = false;
        doorClosing.Play();
        StartCoroutine(DisableScript());
    }

    IEnumerator DisableScript()
    {
        yield return new WaitForSeconds(1);
        lights.SetActive(true);
        yield return new WaitForSeconds(1);
        fuseBox.enabled = false;
       
    }
}
