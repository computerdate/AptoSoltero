using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timer = 100;
    public Text textoTimer;
    private bool colorChanged = false;
    private bool gameEnded = false;

    public GameObject gameOverPanel;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        textoTimer.text = "" + timer.ToString("f1");
        
        if (timer <= 90 && !colorChanged)
        {
            textoTimer.color = Color.red;
            colorChanged = true;
        }

        if (timer <= 88 && !gameEnded)
        {
            Time.timeScale = 0; // detener el tiempo del juego
            gameEnded = true;
            gameOverPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        // Carga la escena actual
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

        // Reinicia el valor de timer
        timer = 100;

        // Activa el panel de game over
        gameOverPanel.SetActive(false);

        // Vuelve a poner el juego en marcha
        Time.timeScale = 1;

        // Reinicia las variables de control
        gameEnded = false;
        colorChanged = false;
    }

    public void RestartGameButton()
    {
        // Llama al método RestartGame en el objeto Timer
        FindObjectOfType<Timer>().RestartGame();
    }
}
