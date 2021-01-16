using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Level One");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void LevelSelect(Button level)
    {
        if (level.name == "Level One Button")
        {
            SceneManager.LoadScene("Level One");
            LivesRemaining.lives = 3;
            Time.timeScale = 1f;
        }
        else if (level.name == "Level Two Button")
        {
            //Debug.Log("Forest level selected. Loading scene");
            SceneManager.LoadScene("Level Two");
            LivesRemaining.lives = 3;
            Time.timeScale = 1f;
        }
        else if (level.name == "Level Three Button")
        {
            //Debug.Log("Swamp level selected. Loading scene");
            SceneManager.LoadScene("Level Three");
            LivesRemaining.lives = 3;
            Time.timeScale = 1f;
        }
    }
    
}
