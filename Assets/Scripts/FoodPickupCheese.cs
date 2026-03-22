using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodPickupCheese : MonoBehaviour
{
    public int pointValue = 5;

    void Start()
    {
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grab != null)
            grab.selectEntered.AddListener(OnGrab);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        ScoreManager.instance.AddPoints(pointValue);
        Destroy(gameObject);
    }
}