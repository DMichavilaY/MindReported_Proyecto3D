using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour

{
    public GameObject ObjetoMenuPausa;
    public bool Pausa = false;

    void Start()
    {
        // Aqu� puedes inicializar variables si es necesario
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa== false)
            {
            ObjetoMenuPausa.SetActive(true);
            Pausa = true;

            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            }
           
        }

  
    }

    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false);
        Pausa = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}