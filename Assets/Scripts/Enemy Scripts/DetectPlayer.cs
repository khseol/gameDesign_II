using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DetectPlayer : MonoBehaviour
{
    public GameObject target;
    float targetDistance;
    [SerializeField] public int engageDistance;
    [SerializeField] public int disengageDistance;

    

    bool engage; //boolean variable to make the bat follow and engage the player when the distance between is some less than or equal to some threshold
    //follow script

    
    void FixedUpdate()
    {
        checkDistance();
    }

    void checkDistance()
    {
        Debug.Log("Distance between the player and the enemy");
        foreach (Transform child in this.transform)
        {
            targetDistance = Mathf.RoundToInt(Vector3.Distance(target.transform.position, child.transform.position));
            Debug.Log(targetDistance);

            if (targetDistance <= engageDistance)
            {
                Debug.Log("Player insight, attack/follow player");
                GetComponent<AIPath>().enabled = true;
                GetComponent<AIDestinationSetter>().enabled = true;
            }
            if (targetDistance >= disengageDistance)
            {
                Debug.Log("Play is out of enemy sight, stop following");
                GetComponent<AIPath>().enabled = false;
                GetComponent<AIDestinationSetter>().enabled = false;
            }
        }
    }

    
}
