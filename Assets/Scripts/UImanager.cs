using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    [Header("Referencias UI - Textos")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI restartText;

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

        // Inicializar textos
        UpdateScore(0);
        UpdateTimer(0);

        // Ocultar paneles al comenzar
        if (panelWin != null)
            panelWin.SetActive(false);

        if (panelGameOver != null)
            panelGameOver.SetActive(false);

        // Ocultar mensaje de reinicio
        if (restartText != null)
            restartText.gameObject.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        if (scoreText == null) return;

        scoreText.text = "Score: " + score;
    }

    public void UpdateTimer(float timer)
    {
        if (timerText == null) return;

        float tiempo = Mathf.Max(0f, timer);
        timerText.text = "Timer: " + tiempo.ToString("F1");
    }

    public void MostrarPantallaWin()
    {
        if (panelWin != null)
            panelWin.SetActive(true);

        if (restartText != null)
        {
            restartText.text = "Press R to Restart";
            restartText.gameObject.SetActive(true);
            Debug.Log ("R funciona");
        }
    }

    public void MostrarPantallaGameOver()
    {
        if (panelGameOver != null)
            panelGameOver.SetActive(true);

        if (restartText != null)
        {
            restartText.text = "Press R to Restart";
            restartText.gameObject.SetActive(true);
            Debug.Log ("R funciona");
        }
    }
}