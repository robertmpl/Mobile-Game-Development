using System;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{

    public float scrollAmount; // The speed at which the game object scrolls

    private float spriteWidth; // Width of the actual sprite

    void Start()
    {
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x; // Sets the sprite width by using the bounds
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - (scrollAmount * Time.deltaTime), 0f,0f); // Apply scroll to x axis

        if (transform.position.x <= -spriteWidth) // Check if sprite has gone off screen
        {
            transform.position = new Vector3(spriteWidth, 0f, 0f); // Reposition it back to the front
        };
    }
}
