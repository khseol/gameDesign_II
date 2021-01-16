using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Along : MonoBehaviour
{
    public GameObject player;

    void OnCollisionEnter2D(Collision2D character)
    {
        if (character.gameObject == player)
        {
            player.transform.parent = this.transform;
        }
    }

    void OnCollisionExit2D(Collision2D character)
    {
        if (character.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
