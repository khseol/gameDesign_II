using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    public Transform target;
    //public Vector3 offsetZ;
    [Range(1, 10)]
    public int smoothFactor;

    void Update()
    {
        follow();   
    }
    void follow()
    {
        Vector3 targetPosition = new Vector3(target.position.x, 2.18f, transform.position.z); //2.18f is the offset for the camera to follow the player at ground level
        Vector3 smoothed = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
        transform.position = targetPosition;
    }
}
