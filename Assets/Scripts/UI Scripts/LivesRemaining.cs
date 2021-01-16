using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesRemaining : MonoBehaviour
{
    public static int lives = 3;
    //bool hasLives = true;
    public GameObject managerObj;
    Manage_Game managerScript;
    Text livesRemain;

    void Start()
    {
        managerScript = managerObj.GetComponent<Manage_Game>();
        livesRemain = GetComponent<Text>();

    }

    void Update()
    {
        bool checkLives = hasLives();
        if (checkLives == true)
        {
            livesRemain.text = "Lives: " + lives;
        }
        else if (checkLives == false)
        {
            livesRemain.text = "Lives: " + 0;

        }
    }

    bool hasLives()
    {
        if (lives < 0)
        {
            managerScript.endGame();
            return false;
        }

        return true;
    }
}
