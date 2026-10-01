using UnityEngine;

public class WeaponSpinner : MonoBehaviour
{
    [Header("General")]
    public float spinSpeed = 1f;

    void Update()
    {
        // Rotate the object indefinitely using spinSpeed variable
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
    }
}
