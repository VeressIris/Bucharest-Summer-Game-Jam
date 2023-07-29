using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerInput playerInput;
    private bool paused = false;

    [Header("UI")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject healthBar;

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
    }

    public void PauseResume()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            
            pauseMenu.SetActive(true);
            healthBar.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;

            pauseMenu.SetActive(false);
            healthBar.SetActive(true);
        }

        paused = !paused;
    }

    private void SetUIElements()
    {
        gameOverScreen.SetActive(false);
        pauseMenu.SetActive(false);
        healthBar.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
