using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BackgroundCharge : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        string levelToCharge = LoadSceneManager.nextLevel;
        StartCoroutine(LoadAsync(levelToCharge));
    }

    IEnumerator LoadAsync(string level)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(level);
        asyncOperation.allowSceneActivation = false;

        yield return new WaitForSecondsRealtime(6f);

        while (!asyncOperation.isDone) 
        {
            if (asyncOperation.progress >= 0.9f)
            {
                text.text = "Presiona una tecla para continuar";

                if (Input.anyKey)
                {
                    asyncOperation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}
