using UnityEngine;
using System.Runtime.InteropServices;

public class IOSHaptics : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void _HapticImpact(int style);

    public void Light()
    {
        _HapticImpact(0);
    }

    public void Medium()
    {
        _HapticImpact(1);
    }

    public void Heavy()
    {
        _HapticImpact(2);
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
