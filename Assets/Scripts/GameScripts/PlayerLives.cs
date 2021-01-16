using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public static int lives = 3;
    
    public GameObject managerObj;
    Manage_Game managerScript;

    void Start()
    {
        managerScript = managerObj.GetComponent<Manage_Game>();
    }
    void checkLives()
    {
        if (lives < 0)
        {
            managerScript.endGame();
        }
    }
}
