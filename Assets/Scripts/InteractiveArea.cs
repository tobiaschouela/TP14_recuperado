using System.Collections;
using UnityEngine;

public class InteractiveArea : MonoBehaviour
{
    [Header("Configuración de Puntuación")]
    public int scoreMaximo = 5;

    private int score = 0;
    private UImanager uiManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UImanager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            score++;
            uiManager.UpdateScore(score);
            Destroy(other.gameObject);

            if (score >= scoreMaximo)
            {
                uiManager.MostrarPantallaWin();
                Time.timeScale = 0f;
            }
        }
    }
}