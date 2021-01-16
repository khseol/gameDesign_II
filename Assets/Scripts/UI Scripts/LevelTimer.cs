using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    float levelTimer = 180f; //will take approximate of 3 minutes
    public GameObject manager;
    Manage_Game managerScript;

    Text remainingTime;
    public GameObject playerStatus;
    Player_move playerStatusScript;

    bool status = false;

    void Start()
    {
        managerScript = manager.GetComponent<Manage_Game>();
        remainingTime = GetComponent<Text>();
        playerStatusScript = playerStatus.GetComponent<Player_move>();
    }

    void Update()
    {
        status = hasReachedGoal();
        if (status == false)
        {
            levelTimer -= Time.deltaTime;
            remainingTime.text = "Time: " + Mathf.RoundToInt(levelTimer);
            if (levelTimer <= 0)
            {
                managerScript.endGame();
            }
        }
        else if (status == true)
        {
            remainingTime.text = "Time: " + Mathf.RoundToInt(levelTimer);
        }
    }

    bool hasReachedGoal()
    {
        return playerStatusScript.getGoalStatus;
    }
}
