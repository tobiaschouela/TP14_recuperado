using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Configuración del Timer")]
    public float timer = 60f;

    private UImanager uiManager;
    private bool timerActivo = true;

    private void Awake()
    {
        // IMPORTANTE
        Time.timeScale = 1f;

        uiManager = FindObjectOfType<UImanager>();
    }

    private void Update()
    {
        // Reiniciar SIEMPRE con R
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReiniciarPartida();
        }

        if (!timerActivo)
            return;

        timer -= Time.deltaTime;

        if (uiManager != null)
            uiManager.UpdateTimer(timer);

        if (timer <= 0f)
        {
            timer = 0f;
            timerActivo = false;

            if (uiManager != null)
                uiManager.MostrarPantallaGameOver();

            Time.timeScale = 0f;
        }
    }

    public void TerminarJuegoVictoria()
    {
        timerActivo = false;

        if (uiManager != null)
            uiManager.MostrarPantallaWin();

        Time.timeScale = 0f;
    }

    private void ReiniciarPartida()
    {
        // Despausar antes de cargar
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}