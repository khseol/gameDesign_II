using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    //public bool trigger;
    public float countDown;
    HitCount normal;
    Animator animate;

    void Awake()
    {
        animate = gameObject.GetComponent<Animator>();
        normal = gameObject.GetComponent<HitCount>();
        countDown = 3f;
    }

    void Update()
    {
        countDown -= Time.deltaTime;
        Debug.Log("Invincibility timer activated:");
        Debug.Log(Mathf.RoundToInt(countDown));
        animate.enabled = true;

        if (countDown <= 0f)
        {
            normal.enabled = true;
            animate.enabled = false;
            countDown = 3f;
            this.enabled = false;
            
        }
    }

    
}
