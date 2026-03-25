using UnityEngine;
using UnityEngine.InputSystem;

public class VRMouseTurn : MonoBehaviour
{
    [Header("Settings")]
    public float turnSpeed = 90.0f;
    public float smoothing = 10.0f; // Higher = Snappier, Lower = Smoother

    [Header("Input")]
    public InputActionProperty turnAction;

    private float smoothedInputX;

    void OnEnable()
    {
        if (turnAction.action != null) turnAction.action.Enable();
    }

    void Update()
    {
        Vector2 input = turnAction.action.ReadValue<Vector2>();

        // 1. Interpolate the input value to remove 'stick jitter'
        smoothedInputX = Mathf.Lerp(smoothedInputX, input.x, Time.deltaTime * smoothing);

        // 2. Threshold check to prevent 'drift' at near-zero values
        if (Mathf.Abs(smoothedInputX) > 0.001f)
        {
            float rotationAmount = smoothedInputX * turnSpeed * Time.deltaTime;

            // 3. Apply rotation to the XR Origin root
            transform.Rotate(0, rotationAmount, 0);
        }
    }
}