using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite knightSprite;
    public Sprite turnedKnightSprite;
    public Sprite backwardKnightSprite;

    [Header("General")]
    public float movementSpeed = 2; // Speed the player moves at

    InputAction moveAction;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move"); // Get inputs for movement
    }

    void Update()
    {
        // Get input using Vector2 for use with linear velocity
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        // Seperate inputs for axis specific tasks
        float verticalInputAxis = moveValue.y;
        float horizontalInputAxis = moveValue.x;

        // Apply input axis to linear velocity with adjustable movement speed variable
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = movementSpeed * moveValue;

        // Sprite changing based on movement
        if (horizontalInputAxis > 0)
        {
            GetComponent<SpriteRenderer>().sprite = turnedKnightSprite;
            GetComponent<SpriteRenderer>().flipX = false;

        } else if (horizontalInputAxis < 0)
        {
            GetComponent<SpriteRenderer>().sprite = turnedKnightSprite;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (verticalInputAxis > 0)
        {
            GetComponent<SpriteRenderer>().sprite = backwardKnightSprite;
        }
        else if (verticalInputAxis < 0)
        {
            GetComponent<SpriteRenderer>().sprite = knightSprite;
        }
    }
}
