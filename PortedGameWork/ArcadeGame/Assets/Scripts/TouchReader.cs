using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
 
public class TouchReader : MonoBehaviour
{
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