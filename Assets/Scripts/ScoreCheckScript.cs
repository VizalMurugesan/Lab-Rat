using UnityEngine;
using TMPro;
using System.Dynamic;

public class ScoreCheckScript : MonoBehaviour
{    
    public static ScoreCheckScript instance;

    public GameObject targetObject1;
    public GameObject targetObject2;
    public TextMeshProUGUI Text;

    private bool message15Shown = false;
    private bool message30Shown = false;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.instance.currentPoints >= 15 && !message15Shown){
            message15Shown = true;
            Destroy(targetObject2);
            Text.gameObject.SetActive(true);
            Text.text = "You got 15 points! Mousehole is Open!"; 
            Invoke(nameof(HideText), 2f);
        }

        if (ScoreManager.instance.currentPoints >= 30 && !message30Shown){
            message30Shown = true;
            Destroy(targetObject1);
            Text.gameObject.SetActive(true);
            Text.text = "You got 30 points! Vent is Open!"; 
            Invoke(nameof(HideText), 2f);
        }


        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetObject1)
        {
            Text.gameObject.SetActive(true);
            Text.text = "Can't go here unless you've got 30 points!";
            Invoke(nameof(HideText), 2f);
        } 
        else if (other.gameObject == targetObject2)
        {
            Text.gameObject.SetActive(true);
            Text.text = "Can't go here unless you've got 15 points!";
            Invoke(nameof(HideText), 2f);
        }
        
    }

    void HideText()
        {
      Text.gameObject.SetActive(false);
        }
  

}
