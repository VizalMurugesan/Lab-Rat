using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FoodPickupCheese : MonoBehaviour
{
    public int pointValue = 5;
    public float disappearDelay = 1.5f;
    private XRGrabInteractable grab; 
    private ParticleSystem particles;

    void Start()
    {
        grab = GetComponent<XRGrabInteractable>(); 
        if (grab != null)
            grab.selectEntered.AddListener(OnGrab);
    }

    void OnGrab(UnityEngine.XR.Interaction.Toolkit.SelectEnterEventArgs args)
{
    if (ScoreManager.instance != null)
        ScoreManager.instance.AddPoints(pointValue);
    else
        Debug.LogError("ScoreManager not found in scene!");
    
    if (particles != null)
            particles.Play();
    // Destroy(gameObject);
    Invoke(nameof(Disappear), disappearDelay);

     void Disappear()
    {
        Destroy(gameObject);
    }
}

}