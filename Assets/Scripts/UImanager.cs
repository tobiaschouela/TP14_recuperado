// UImanager.cs
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

    private void Start()
    {
        if (scoreText == null)
            Debug.LogError("scoreText no asignado en UImanager!");

        if (timerText == null)
            Debug.LogError("timerText no asignado en UImanager!");

        if (panelWin == null)
            Debug.LogError("panelWin no asignado en UImanager!");

        if (panelGameOver == null)
            Debug.LogError("panelGameOver no asignado en UImanager!");
    }

    public void UpdateScore(int score)
    {
        if (scoreText == null) return;
        scoreText.text = "Score: " + score;
    }

    public void UpdateTimer(float timer)
    {
        if (timerText == null) return;
        float timerClamped = Mathf.Max(0f, timer);
        timerText.text = "Time: " + timerClamped.ToString("F1");
    }

    public void MostrarPantallaWin()
    {
        if (panelWin == null) return;
        panelWin.SetActive(true);
    }

    public void MostrarPantallaGameOver()
    {
        if (panelGameOver == null) return;
        panelGameOver.SetActive(true);
    }
}