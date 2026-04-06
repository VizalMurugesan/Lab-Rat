using UnityEngine;
using TMPro;
using System.Net.Mime;

public class ScoreCheckScript : MonoBehaviour
{    
    public static ScoreCheckScript instance;

    public GameObject targetObject1;
    public GameObject targetObject2;
    public TextMeshProUGUI Text;

    
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
        if (ScoreManager.instance.currentPoints >= 15){
            Destroy(targetObject2);
            Text.gameObject.SetActive(true);
            Text.text = "You got 15 points! Mousehole is Open!"; 
            Invoke(nameof(HideText), 2f);
        }

        if (ScoreManager.instance.currentPoints >= 30){
            Destroy(targetObject1);
            Text.gameObject.SetActive(true);
            Text.text = "You got 30 points! Vent is Open!"; 
            Invoke(nameof(HideText), 2f);
        }
        
    }

    void HideText()
        {
      Text.gameObject.SetActive(false);
        }
  

}
