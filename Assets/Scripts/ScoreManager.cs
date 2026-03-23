using System.Net.Mime;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI Text;

    public int currentPoints = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddPoints(int points)
    {
        currentPoints += points;
        Text.text = "Score" + points;
        Debug.Log("Points: " + currentPoints);
    }
}