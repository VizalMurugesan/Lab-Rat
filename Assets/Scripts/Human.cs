using UnityEngine;

public class Human : MonoBehaviour
{
    [Header("Patrol Points")]
    public Transform pointA;
    public Transform pointB;

    [Header("Settings")]
    public float speed = 2f;
    public float waitTime = 2f;
    public float turnSpeed = 5f;

    private Transform currentTarget;
    private Animator anim;
    private float waitTimer;
    private bool isWaiting;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentTarget = pointB; // Start by walking toward B
    }

    void Update()
    {
        if (isWaiting)
        {
            HandleWaiting();
        }
        else
        {
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        // 1. Move the position
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        // 2. Rotate to face the target
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        }

        // 3. Animation
        anim.SetBool("walking", true);

        // 4. Check if reached destination
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            isWaiting = true;
            waitTimer = waitTime;
            anim.SetBool("walking", false);
        }
    }

    void HandleWaiting()
    {
        waitTimer -= Time.deltaTime;
        if (waitTimer <= 0f)
        {
            isWaiting = false;
            // Switch targets
            currentTarget = (currentTarget == pointA) ? pointB : pointA;
        }
    }
}