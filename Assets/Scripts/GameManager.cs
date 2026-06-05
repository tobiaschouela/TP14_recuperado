// GameManager.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Configuración del Timer")]
    public float timer = 60f;

    private UImanager uiManager;
    private bool timerActivo = true;
    private bool juegoTerminado = false;

    private void Awake()
    {
        Time.timeScale = 1f;
        uiManager = FindObjectOfType<UImanager>();

        if (uiManager == null)
            Debug.LogError("UImanager no encontrado en la escena!");
    }

    private void Update()
    {
        if (uiManager == null) return;

        if (juegoTerminado && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (!timerActivo) return;

        timer -= Time.deltaTime;
        uiManager.UpdateTimer(timer);

        if (timer <= 0f)
        {
            timer = 0f;
            timerActivo = false;
            juegoTerminado = true;
            uiManager.MostrarPantallaGameOver();
            Time.timeScale = 0f;
        }
    }

    public void TerminarJuegoVictoria()
    {
        timerActivo = false;
        juegoTerminado = true;
        uiManager.MostrarPantallaWin();
        Time.timeScale = 0f;
    }
}