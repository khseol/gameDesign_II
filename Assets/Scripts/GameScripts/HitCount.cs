using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCount : MonoBehaviour
{
    public int hitCount = 0;
    int hitLimit = 2;
    //bool trigger = false;
    public GameObject manager;
    Manage_Game manager_script;
    Invincibility noDamage; //this will nulify any damage taken for 3 seconds. if the player happens to fall off the screen, it counts as losing a life

    public AudioSource hurt_snd;
    public AudioClip hurt_efx;

    void Awake()
    {
        noDamage = gameObject.GetComponent<Invincibility>();
        manager_script = manager.GetComponent<Manage_Game>();
    }

    void OnTriggerEnter2D(Collider2D enemyCollision)
    {
        if (enemyCollision.gameObject.tag == "Enemy" && noDamage.enabled == false)
        {
            applyHit(1);
            Debug.Log("Hit count is: " + hitCount);
            noDamage.enabled = true;
            //this.enabled = false;
        }if (enemyCollision.gameObject.tag == "Enemy" && noDamage.enabled == true)
        {
            applyHit(0);
        }
        if (enemyCollision.gameObject.tag == "Enemy_Special")
        {
            applyHit(hitLimit);
        }



    }

   void applyHit(int damage)
    {
        hitCount = hitCount + damage;
        hurt_snd.PlayOneShot(hurt_efx);
        if (hitCount == hitLimit || hitCount >= hitLimit)
        {
            manager_script.resetScene();
        }
    }
}
