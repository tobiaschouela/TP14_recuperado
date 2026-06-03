using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    [Header("Referencias UI - Textos")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    [Header("Paneles de Fin de Juego")]
    public GameObject panelWin;
    public GameObject panelGameOver;

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateTimer(float timer)
    {
        float timerClamped = Mathf.Max(0f, timer);
        timerText.text = "Time: " + timerClamped.ToString("F1");
    }

    public void MostrarPantallaWin()
    {
        panelWin.SetActive(true);
    }

    public void MostrarPantallaGameOver()
    {
        panelGameOver.SetActive(true);
    }
}