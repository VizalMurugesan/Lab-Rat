using UnityEngine;

public class FloatAndSpin : MonoBehaviour
{
    public float floatHeight = 0.01f;
    public float floatSpeed = 2f;
    public float rotationSpeed = 50f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Float (only affects Y)
        Vector3 pos = transform.position;
        pos.y = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = pos;

        // Rotate in place
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime, Space.Self);
    }

}