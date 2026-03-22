using UnityEngine;

public class FloatAndSpinCookie : MonoBehaviour
{
    public float floatHeight = 0.1f;
    public float floatSpeed = 2f;
    public float rotationSpeed = 50f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Float up and down
        Vector3 pos = transform.position;
        pos.y = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = pos;

        // Rotate left to right
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);
    }
}