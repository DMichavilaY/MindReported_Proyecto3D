using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FuseBoxLogic : MonoBehaviour
{
    [SerializeField] private Collider basementDoor;
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private AudioSource doorClosing;

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
    }

    IEnumerator DisableScript()
    {
        yield return new WaitForSeconds(2);
        fuseBox.enabled = false;
       
    }
}
