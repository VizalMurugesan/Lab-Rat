using UnityEngine;
using TMPro;
using System.Net.Mime;

public class ScoreCheckScript : MonoBehaviour
{

    public GameObject gameObject;
    public GameObject gameObject2;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ScoreManager.instance.AddPoints()
        
    }

    void check(){
        if ScoreManager.instance.AddPoints()
    }
}
