using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsSoundLogic : MonoBehaviour
{
    [SerializeField] private GameObject footsteps;
    void Awake()
    {
        footsteps.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            StartFootsteps();
        }

        if (Input.GetButton("Vertical"))
        {
            StartFootsteps();
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            StopFootsteps();
        }

        if (Input.GetButtonUp("Vertical"))
        {
            StopFootsteps();
        }
    }


    private void StartFootsteps()
    {
        footsteps.SetActive(true);
    }

    private void StopFootsteps()
    {
        footsteps.SetActive(false);
    }
}
