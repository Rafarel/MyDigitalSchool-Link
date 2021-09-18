using System;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    private GameManager m_Game;
    public int Value { get; private set; }

    public event EventHandler<EventArgs> Changed;
    
    private void Awake()
    {
        m_Game = GameManager.Instance;

        m_Game.Rupees.RupeeCollected += RupeeCollectedHandler;
    }

    private void RupeeCollectedHandler(object sender, RupeeEvent e)
    {
        Rupee rupee = e.Rupee;

        if (rupee)
        {
            Value += rupee.Score;
            OnChanged();
        }
    }

    private void OnChanged()
    {
        Changed?.Invoke(this, EventArgs.Empty);
    }
}
