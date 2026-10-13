using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class TouchReader : MonoBehaviour
{
     
    public GameObject pauseText;

    void OnEnable()  => EnhancedTouchSupport.Enable();
    void OnDisable() => EnhancedTouchSupport.Disable();
 
    double firstTapTime;
    double doubleTapTimeout = 0.3;

    void Update()
    {
        foreach (var touch in Touch.activeTouches)
        {
            if (touch.phase != UnityEngine.InputSystem.TouchPhase.Began)
                continue;

            if (touch.time - firstTapTime <= doubleTapTimeout) 
            {
                Debug.Log("Double Tap");

                if (Time.timeScale == 1.0f) {
                    Time.timeScale = 0f;
                    pauseText.SetActive(true);
                } else {
                    Time.timeScale = 1.0f;
                    pauseText.SetActive(false);
                }

                // if (GravitySensor.current == null) {
                //     InputSystem.EnableDevice(GravitySensor.current);
                // } else {
                //     InputSystem.DisableDevice(GravitySensor.current);
                // }

            } else 
            {
                firstTapTime = touch.time;
            }

            if (touch.phase == TouchPhase.Ended)
                Debug.Log($"Finger {touch.finger.index} down");
            
        }
    }
}