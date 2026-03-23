using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FoodPickupCheese : MonoBehaviour
{
    public int pointValue = 5;
    public float disappearDelay = 1.5f;
    private XRGrabInteractable grab; 
    public ParticleSystem particles;

  void Start()
{
    grab = GetComponent<XRGrabInteractable>();
    Debug.Log("Grab found: " + (grab != null));
    Debug.Log("Particles found: " + (particles != null));

    if (grab != null)
        grab.selectEntered.AddListener(OnGrab);
}
void OnGrab(UnityEngine.XR.Interaction.Toolkit.SelectEnterEventArgs args)
{
    Debug.Log("Grabbed! Particles null? " + (particles == null));

    if (ScoreManager.instance != null)
        ScoreManager.instance.AddPoints(pointValue);

    if (particles != null)
        particles.Play();

    Invoke(nameof(Disappear), disappearDelay);
}

     void Disappear()
    {
        Destroy(gameObject);
    }

}