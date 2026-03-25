using UnityEngine;
using UnityEngine.InputSystem;

public class VRMouseTurn : MonoBehaviour
{
    [Header("Settings")]
    public float turnSpeed = 60.0f;

    [Header("Input")]
    // Point this to your Right Controller 'Turn' or 'Look' action
    public InputActionProperty turnAction;

    void OnEnable()
    {
        if (turnAction.action != null) turnAction.action.Enable();
    }

    void Update()
    {
        // 1. Read the Vector2 from the right stick
        Vector2 input = turnAction.action.ReadValue<Vector2>();

        // 2. We only care about horizontal movement (x) for turning the body
        if (Mathf.Abs(input.x) > 0.1f)
        {
            float rotationAmount = input.x * turnSpeed * Time.deltaTime;

            // 3. Rotate the ENTIRE XR Origin. 
            // This moves the camera and the controllers together.
            transform.Rotate(0, rotationAmount, 0);
        }
    }
}