using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoopLogic : MonoBehaviour
{
    private string objectTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(objectTag))
        {
            LoadSceneManager.LoadLevel("MainScene");
        }
    }
}
