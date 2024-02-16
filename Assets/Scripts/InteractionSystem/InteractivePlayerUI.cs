using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractivePlayerUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI promptText;
    void Awake()
    {
        UpdateText(string.Empty);
    }

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }
}
