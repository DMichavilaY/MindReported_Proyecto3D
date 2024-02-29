//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Audio;
//using UnityEngine.UI;

//public class MenuOpciones : MonoBehaviour
//{
//    public Dropdown resolutionDropdown;
//    Resolution[] resolutions;


//    public void SetVolume (float volume)
//    { }

//    public void SetQuality (int qualityIndex)
//    { QualitySettings.SetQualityLevel(qualityIndex); }

//    public void SetFullscreen(bool isFullscreen)
//    { Screen.fullScreen = isFullscreen; }



//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public AudioMixer audioMixer; // Referencia al mixer de audio para ajustar el volumen

    Resolution[] resolutions;

    private void Start()
    {
        Time.timeScale = 0;
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume); // Ajusta el parámetro "Volume" en el mixer de audio
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}

