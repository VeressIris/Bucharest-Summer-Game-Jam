using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void SelectLevel()
    {
        string name = gameObject.name;
        int level = int.Parse(name[name.Length - 1].ToString());
        
        SceneManager.LoadScene(level);
    }
}
