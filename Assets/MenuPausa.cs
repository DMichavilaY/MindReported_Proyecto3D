using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour

{
    [SerializeField] private GameObject ObjetoMenuPausa;
    private bool Pausa = false;

    [SerializeField] private GameObject MenuSalir;

    [SerializeField] private AudioSource musicAtmosphere;
    void Start()
    {
        // Aquí puedes inicializar variables si es necesario
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa == false)
            {
                ObjetoMenuPausa.SetActive(true);
                Pausa = true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                musicAtmosphere.Pause();
                

            }

            else if (Pausa == true)
            {
                Resumir();
            }

        }


    }

    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false);
        MenuSalir.SetActive(false);
        Pausa = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        musicAtmosphere.UnPause();
    }

    public void IraAlMenu(string NombreMenu)
    {
        SceneManager.LoadScene(NombreMenu);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
















//public class MenuPausa : MonoBehaviour
//{
//    public GameObject ObjetoMenuPausa;
//    public bool Pausa = false;
//    public AudioSource musicaMenuPausa; // Agrega una referencia al AudioSource para la música del menú de pausa

//    void Start()
//    {
//        // Inicializa la música del menú de pausa
//        musicaMenuPausa.Play(); // Puedes reproducir la música automáticamente al iniciar el menú de pausa
//        musicaMenuPausa.Pause(); // Pausa la música inicialmente para que solo se reproduzca cuando se pausa el juego
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            if (!Pausa)
//            {
//                ObjetoMenuPausa.SetActive(true);
//                Pausa = true;

//                Time.timeScale = 0;
//                Cursor.visible = true;
//                Cursor.lockState = CursorLockMode.None;

//                AudioSource[] sonidos = FindObjectsOfType<AudioSource>();

//                for (int i = 0; i < sonidos.Length; i++)
//                {
//                    sonidos[i].Pause();
//                }
//            }
//            else
//            {
//                Resumir();
//            }
//        }
//    }

//    //public void Resumir()
//    //{
//    //    ObjetoMenuPausa.SetActive(false);
//    //    Pausa = false;
//    //    Time.timeScale = 1;
//    //    Cursor.visible = false;
//    //    Cursor.lockState = CursorLockMode.Locked;

//    //    AudioSource[] sonidos = FindObjectsOfType<AudioSource>();

//    //    for (int i = 0; i < sonidos.Length; i++)
//    //    {
//    //        // Reanudar todos los AudioSource que se pausaron durante la pausa del juego
//    //        sonidos[i].UnPause();

//    //        // Si el AudioSource es la música del menú de pausa, lo detiene solo si se sale del menú de pausa
//    //        if (sonidos[i] == musicaMenuPausa && !Pausa)
//    //        {
//    //            sonidos[i].Stop();
//    //        }
//    //        else // Si no es la música del menú de pausa o si aún estamos en el menú de pausa, reanuda la música
//    //        {
//    //            sonidos[i].Play();
//    //        }
//    //    }
//    //}


//    public void Resumir()
//    {
//        ObjetoMenuPausa.SetActive(false);
//        Pausa = false;
//        Time.timeScale = 1;
//        Cursor.visible = false;
//        Cursor.lockState = CursorLockMode.Locked;

//        AudioSource[] sonidos = FindObjectsOfType<AudioSource>();

//        for (int i = 0; i < sonidos.Length; i++)
//        {
//            sonidos[i].Play();
//        }
//    }

//    public void IraAlMenu(string NombreMenu)
//    {
//        SceneManager.LoadScene(NombreMenu);
//    }

//    public void SalirDelJuego()
//    {
//        Application.Quit();
//    }
//}