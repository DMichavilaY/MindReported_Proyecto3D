using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource menuMusic; // Variable para el sonido del menú principal

    private void Start()
    {
        // Reproducir el sonido del menú principal al iniciar
        if (menuMusic != null && !menuMusic.isPlaying)
        {
            menuMusic.Play();
        }
    }

    public void PlayGame()
    {
        // Detener la reproducción del sonido del menú principal antes de cargar el siguiente escenario
        if (menuMusic != null && menuMusic.isPlaying)
        {
            menuMusic.Stop();
        }

        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitLevel()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void ReplayGame()
    {
        // Detener la reproducción del sonido del menú principal antes de cargar el escenario actual
        if (menuMusic != null && menuMusic.isPlaying)
        {
            menuMusic.Stop();
        }

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenLevel1()
    {
        // Detener la reproducción del sonido del menú principal antes de cargar el siguiente escenario
        if (menuMusic != null && menuMusic.isPlaying)
        {
            menuMusic.Stop();
        }

        LoadSceneManager.LoadLevel("MainScene");
    }
}







