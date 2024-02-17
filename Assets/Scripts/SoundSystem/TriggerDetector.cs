using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    private string objectTag = "Player";
    public SoundController soundController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(objectTag))
        {
            soundController.PlaySound();
            StartCoroutine(Desactive());
        }
    }

    IEnumerator Desactive()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
