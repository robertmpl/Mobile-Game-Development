using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject weapon;

    [Header("Settings")]
    public float weaponSpeed = 5f; // Speed at which the weapon travels at
    public float weaponFireRate = 1f; // Time between when a shot can be made
    public float weaponDamageMultiplier = 1f; // Multiplier for weapon damage
    public bool homingWeapon = false; // If weapons home in on enemies
    public AudioClip weaponSound;

    float nextShootTime; // To allow for delay between shooting

    InputAction shootAction;

    void Start()
    {
        shootAction = InputSystem.actions.FindAction("Shoot"); // Get inputs for the Shoot action
    }

    void Update()
    {
        Vector2 shootValue = shootAction.ReadValue<Vector2>();

        if (shootValue != new Vector2(0,0) && Time.time >= nextShootTime) // If the player is trying to shoot in a direction and if enough time has passed
        {
            nextShootTime = Time.time + weaponFireRate; // Set next available shoot time

            GameObject newWeapon = Instantiate(weapon, transform.position, Quaternion.identity); // Clone new weapon

            AudioSource.PlayClipAtPoint(weaponSound, transform.position);

            newWeapon.GetComponent<Rigidbody2D>().linearVelocity = weaponSpeed * shootValue; // Make weapon fly into the direction of shot input
        }
    }
}
