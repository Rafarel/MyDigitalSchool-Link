using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public RupeesManager Rupees { get; private set; }
    
    public ScoreManager Score { get; private set; }
    
    public UIManager UI { get; private set; }
    
    public TimeManager Time { get; private set;  }
    
    public bool Playing { get; private set; }

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
        UI = GetComponent<UIManager>();
        Time = GetComponent<TimeManager>();

        Score.Changed += ScoreChangedHandler;
        Time.Completed += TimeCompletedHandler;
    }

    public void StartGame()
    {
        Playing = true;
        Time.StartCountdown();
        Rupees.StartSpawning();
    }

    private void StopGame()
    {
        Playing = false;
        Rupees.StopSpawning();
        Rupees.Clear();
    }

    private void ScoreChangedHandler(object sender, EventArgs args)
    {
        Debug.Log(Score.Value);
        
        if (Score.Value >= scoreToWin)
        {
            Debug.Log("Game Win!");
        }
    }

    private void TimeCompletedHandler(object sender, EventArgs args)
    {
        StopGame();
    }
}
