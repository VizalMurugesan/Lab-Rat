using UnityEngine;

public class MouseFootsteps : MonoBehaviour
{
    [Header("Audio Clips")]
    public AudioClip[] footstepSounds;
    public AudioClip[] squeakSounds;

    [Header("Settings")]
    public float stepInterval = 0.4f;
    public float squeakChance = 0.08f;  // 8% chance of squeak per step
    public float moveThreshold = 0.02f;

    private AudioSource audioSource;
    private float stepTimer = 0f;
    private Vector3 lastPosition;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 0f;
        audioSource.volume = 0.5f;
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 currentFlat = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 lastFlat = new Vector3(lastPosition.x, 0, lastPosition.z);
        float distanceMoved = Vector3.Distance(currentFlat, lastFlat);

        bool isMoving = distanceMoved > moveThreshold * Time.deltaTime;

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                PlayStep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }

        lastPosition = transform.position;
    }

    void PlayStep()
    {
        if (squeakSounds.Length > 0 && Random.value < squeakChance)
        {
            AudioClip squeak = squeakSounds[Random.Range(0, squeakSounds.Length)];
            audioSource.PlayOneShot(squeak, 0.6f);
            return;
        }

        if (footstepSounds.Length > 0)
        {
            AudioClip step = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audioSource.PlayOneShot(step, 0.4f);
        }
    }
}