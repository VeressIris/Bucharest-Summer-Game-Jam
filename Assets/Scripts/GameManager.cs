using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerInput playerInput;
    private bool paused = false;

    [Header("UI")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject completedLevelScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject score;
    [SerializeField] private TMP_Text scoreText;
    private float rawScore = 0;

    void Start()
    {
        Time.timeScale = 1;
        paused = false;

        SetUIElements();
    }

    void Update()
    {
        if (playerController.health <= 0)
        {
            playerInput.enabled = false;
            gameOverScreen.SetActive(true);
        }
        else
        {
            UpdateScore();
        }
    }

    public void PauseResume()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            
            pauseMenu.SetActive(true);
            healthBar.SetActive(false);

            if (score != null) score.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;

            pauseMenu.SetActive(false);
            healthBar.SetActive(true);

            if (score != null) score.SetActive(true);
        }

        paused = !paused;
    }

    private void SetUIElements()
    {
        gameOverScreen.SetActive(false);
        pauseMenu.SetActive(false);
        healthBar.SetActive(true);
        
        if (completedLevelScreen != null) completedLevelScreen.SetActive(false);
        if (winScreen != null) winScreen.SetActive(false);
        if (score != null) score.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void UpdateScore()
    {
        if (score != null)
        {
            rawScore += Time.deltaTime * 10;
            scoreText.text = rawScore.ToString("0");
        }
    }
}
