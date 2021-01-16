using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manage_Game : MonoBehaviour
{
    //bool gameOver = false;
    //bool levelOver = false;
    bool sceneReset = false;
    public GameObject gameOverUI;
    
    public void endGame() //for clarification, this is a trigger for a game over
    {
        gameOverUI.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void endLevel()
    {

    }

    public void resetScene()
    {

        if (sceneReset == false)
        {
            sceneReset = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            LivesRemaining.lives = LivesRemaining.lives - 1;
        }
    }

}
