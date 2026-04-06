using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FoodPickupCookie : MonoBehaviour
{
    public int pointValue = 3;
    public float disappearDelay = 1.5f;
    private XRGrabInteractable grab;
    public ParticleSystem particles;

    [Header("Audio")]
    public AudioClip eatSound;
    private AudioSource audioSource;

    void Start()
    {
        grab = GetComponent<XRGrabInteractable>();
        audioSource = GetComponent<AudioSource>();

        if (grab != null)
            grab.selectEntered.AddListener(OnGrab);
    }

    void OnGrab(UnityEngine.XR.Interaction.Toolkit.SelectEnterEventArgs args)
    {
        if (particles != null) particles.Play();

        if (audioSource != null && eatSound != null)
            audioSource.PlayOneShot(eatSound);

        Invoke(nameof(Disappear), disappearDelay);
    }

    void Disappear()
    {
        Destroy(gameObject);
        if (ScoreManager.instance != null)
            ScoreManager.instance.AddPoints(pointValue);
    }
}