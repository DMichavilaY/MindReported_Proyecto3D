using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLogic : MonoBehaviour
{
    [SerializeField] private Collider doorCollider;

    public void GetKey()
    {
        doorCollider.enabled = true;
        gameObject.SetActive(false);
    }
}
