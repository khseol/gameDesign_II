using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//keeping in mind that the approxiamte length of the background is 1.2
//the parallax effect was looking choppy so i had to extend the number of clones to get the full effect

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPos;
    public GameObject camera;
    public float parallaxEffect; //this refers to horixontal scrolling of the layered background, relative to the camera.
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x; //will be moving in a horizontal fashion for the 2d game
        length = GetComponent<SpriteRenderer>().bounds.size.x; //returns the length of the sprite, avoiding stretching of the image.
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float temp = (camera.transform.position.x * (1f - parallaxEffect)); //record how far the background has mpved relative to the camera
        distance = (camera.transform.position.x * parallaxEffect); //transforms the background's corresponding layer distance in the view.
        //a higher value will move the background layer more appropriately relative to camera, while a low will lag behind.

        //this will set and capture the new position of the background's respective layer as the camera moves.
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
