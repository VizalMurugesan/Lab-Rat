using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FoodPickupCookie : MonoBehaviour
{
    public int pointValue = 3;
    private XRGrabInteractable grab; 

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

    Destroy(gameObject);
}
}
