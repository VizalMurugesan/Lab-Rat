using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int currentPoints = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddPoints(int points)
    {
        currentPoints += points;
        Debug.Log("Points: " + currentPoints);
    }
}