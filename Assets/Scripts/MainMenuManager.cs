using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectScreen;
    [SerializeField] private GameObject mainMenu;

    void Start()
    {
        levelSelectScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelSelectScreen()
    {
        mainMenu.SetActive(false);
        levelSelectScreen.SetActive(true);
    }

    //automate this?
    public void SelectLevel(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        levelSelectScreen.SetActive(false);
    }
}
