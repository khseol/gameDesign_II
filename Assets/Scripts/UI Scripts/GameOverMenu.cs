using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverUI;
    // Update is called once per frame
    void Update()
    {
        if (LivesRemaining.lives < 0)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        LivesRemaining.lives = 3;
        Time.timeScale = 1f; //resumes time of the world.

    }
}
