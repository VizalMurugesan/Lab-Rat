using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class VRMouseController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2.0f;
    public float gravity = -9.81f;
    private Vector3 velocity;

    [Header("Rotation")]
    public float rotationSpeed = 70.0f;
    public Transform cameraPivot; // Drag 'Main Camera' here

    [Header("Rotation Limits")]
    public float minPitch = -30f;
    public float maxPitch = 30f;
    private float currentPitch = 0f;

    [Header("Inputs")]
    public InputActionProperty moveAction; // Vector2: Left Stick
    public InputActionProperty lookAction; // Vector2: Right Stick

    private CharacterController controller;

    void Start()
    {
        // Automatically grab the component attached to this object
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        // 1. Get stick input
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        // 2. Calculate direction relative to where the mouse is facing
        Vector3 move = transform.right * input.x + transform.forward * input.y;

        // 3. Apply movement
        controller.Move(move * moveSpeed * Time.deltaTime);

        // 4. Apply Gravity
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Keep the mouse snapped to the floor
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleRotation()
    {
        Vector2 lookInput = lookAction.action.ReadValue<Vector2>();

        // 1. Rotate the whole Mouse (Yaw)
        float yaw = lookInput.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, yaw, 0);

        // 2. Calculate Pitch (Up/Down)
        currentPitch -= lookInput.y * rotationSpeed * Time.deltaTime;
        currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);

        // 3. Apply to the NEW RotationPivot
        if (cameraPivot != null)
        {
            // By setting localRotation directly on a 'clean' pivot, 
            // we avoid conflicts with the XR Origin's internal logic.
            cameraPivot.localRotation = Quaternion.Euler(currentPitch, 0f, 0f);
        }
    }
}