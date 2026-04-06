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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.instance.currentPoints >= 15){
            Destroy(targetObject2)
            Text.text = "Mousehole Open!"; 
            Invoke(nameof(HideText), 2f);
        }
        
    }

    void HideText()
        {
      Text.gameObject.SetActive(false);
        }
  

}
