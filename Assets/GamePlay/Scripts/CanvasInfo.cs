using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInfo : MonoBehaviour
{
    private static CanvasInfo _instance; 

    [SerializeField] private Text m_Text;

    private void Start()
    {
        _instance = this;
    }

    public static void SetText(string text)
    {
        _instance.m_Text.text = text;
    }
}
