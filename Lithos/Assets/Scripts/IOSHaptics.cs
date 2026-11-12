using UnityEngine;
using System.Runtime.InteropServices;

public class IOSHaptics : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void _HapticImpact(int style);

    public void Light()
    {
        #if UNITY_IOS && !UNITY_EDITOR
        _HapticImpact(0);
        #endif
    }

    public void Medium()
    {
        #if UNITY_IOS && !UNITY_EDITOR
        _HapticImpact(1);
        #endif
    }

    public void Heavy()
    {
        #if UNITY_IOS && !UNITY_EDITOR
        _HapticImpact(2);
        #endif
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
