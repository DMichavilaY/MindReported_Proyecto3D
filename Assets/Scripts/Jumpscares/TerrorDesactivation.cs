using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrorDesactivation : MonoBehaviour
{
    public GameObject objetoParaDesactivar;
    public AudioClip sonidoDesactivacion;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Desactivar el objeto
            if (objetoParaDesactivar != null)
            {
                objetoParaDesactivar.SetActive(false);
            }

            // Detener el sonido si se está reproduciendo
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}