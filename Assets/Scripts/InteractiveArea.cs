// InteractiveArea.cs
using UnityEngine;

public class InteractiveArea : MonoBehaviour
{
    [Header("Configuración de Puntuación")]
    public int scoreMaximo = 5;

    private int score = 0;
    private UImanager uiManager;
    private GameManager gameManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UImanager>();
        gameManager = FindObjectOfType<GameManager>();

        if (uiManager == null)
            Debug.LogError("UImanager no encontrado en la escena!");

        if (gameManager == null)
            Debug.LogError("GameManager no encontrado en la escena!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            if (uiManager == null || gameManager == null) return;

            score++;
            uiManager.UpdateScore(score);
            Destroy(other.gameObject);

            if (score >= scoreMaximo)
            {
                gameManager.TerminarJuegoVictoria();
            }
        }
    }
}