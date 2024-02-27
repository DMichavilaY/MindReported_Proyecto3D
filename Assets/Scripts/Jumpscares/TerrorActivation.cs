using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrorActivation : MonoBehaviour
{
    public GameObject objetoParaActivar;
    public AudioClip sonidoActivacion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activar el objeto
            if (objetoParaActivar != null)
            {
                objetoParaActivar.SetActive(true);
            }

            // Reproducir el sonido
            if (sonidoActivacion != null)
            {
                AudioSource.PlayClipAtPoint(sonidoActivacion, transform.position);
            }

            // Desactivar el collider para evitar activaciones múltiples
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}