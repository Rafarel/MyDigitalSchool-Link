using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public RupeesManager Rupees { get; private set; }
    
    public ScoreManager Score { get; private set; }

    public int scoreToWin;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        Rupees = GetComponent<RupeesManager>();
        Score = GetComponent<ScoreManager>();


        Score.Changed += ScoreChangedHandler;
    }

    private void ScoreChangedHandler(object sender, EventArgs args)
    {
        Debug.Log(Score.Value);
        
        if (Score.Value >= scoreToWin)
        {
            Debug.Log("Game Win!");
        }
    }
}
