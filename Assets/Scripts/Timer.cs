using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    private int totalTime = 100;
    private int alertTime = 10;
    private int gameOverTime = 0;
    public float timer;
    public Text textoTimer;
    private bool colorChanged = false;  
    private bool gameEnded = false;


    public GameObject gameOverPanel;

    void Start() {
        timer = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        textoTimer.text = "" + timer.ToString("f1");
        
        if (timer <= alertTime && !colorChanged)
        {
            textoTimer.color = Color.red;
            colorChanged = true;
        }

        if (timer <= gameOverTime && !gameEnded)
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
        timer = totalTime;

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
        // Llama al metodo RestartGame en el objeto Timer
        FindObjectOfType<Timer>().RestartGame();
    }
}
