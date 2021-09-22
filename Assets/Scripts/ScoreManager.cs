using System;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    private GameManager m_Game;

    public AudioClip bestScoreClip;
    public int Value { get; private set; }

    private const string BEST = "best-score";

    public int Best
    {
        get => PlayerPrefs.GetInt(BEST, 0);

        set => PlayerPrefs.SetInt(BEST, value);
    }

    public event EventHandler<EventArgs> Changed;
    
    private void Awake()
    {
        m_Game = GameManager.Instance;

        m_Game.Rupees.RupeeCollected += RupeeCollectedHandler;
    }

    public void Reset()
    {
        Value = 0;
    }

    private void RupeeCollectedHandler(object sender, RupeeEvent e)
    {
        Rupee rupee = e.Rupee;

        if (rupee)
        {
            Value += rupee.Data.score;
            OnChanged();
        }
    }

    public void SubmitScore(int score)
    {
        if (score > Best)
        {
            Best = score;
            AudioSource.PlayClipAtPoint(bestScoreClip, Vector3.zero);
        }
    }

    private void OnChanged()
    {
        Changed?.Invoke(this, EventArgs.Empty);
    }
}
