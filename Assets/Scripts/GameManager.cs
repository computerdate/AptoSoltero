using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public bool isGamePaused;
    private int score;
    public GameObject startScreen;
    public GameObject pauseScreen;
    public GameObject winScreen;
    public GameObject lossScreen;

    public void UpdateScore() {
        score += 1;
        if (score == 3) {
            Debug.Log("You have completed the work!");
        }
    }

    public void StartGame() {
        score = 0;
        isGameActive = true;
    }

    public void GameOver() {
        isGameActive = false;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame() {
        isGamePaused = true;
    }

    public void ResumeGame() {
        isGamePaused = false;
    }
}
