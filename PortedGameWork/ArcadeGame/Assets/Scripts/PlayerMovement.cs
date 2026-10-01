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

    void OnEnable() {
        if (Accelerometer.current != null)
        {
            InputSystem.EnableDevice(Accelerometer.current);
            Debug.Log("Accelerometer enabled");
        }
    }

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move"); // Get inputs for movement
    }

    void Update()
    {
        if (Accelerometer.current == null)
            return;

        Vector3 acceleration =
            Accelerometer.current.acceleration.ReadValue();

        Debug.Log($"Accelerometer: {acceleration}");

        // Get input using Vector2 for use with linear velocity
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        // Seperate inputs for axis specific tasks
        float verticalInputAxis = moveValue.y;
        float horizontalInputAxis = moveValue.x;

        if (GravitySensor.current != null) {
            Vector3 gravity = GravitySensor.current.gravity.ReadValue();
            moveValue = new Vector2(gravity.x, gravity.y);

            Debug.Log(moveValue);
        }

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
