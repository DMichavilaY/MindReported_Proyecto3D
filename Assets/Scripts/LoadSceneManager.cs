using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoadSceneManager
{
    public static string nextLevel;

    public static void LoadLevel(string name)
    {
        nextLevel = name;
        SceneManager.LoadScene("ChargeScene");
    }
}
