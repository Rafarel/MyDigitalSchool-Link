using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public int totalTime = 60;

    private float m_timeLeft;

    private bool m_started;

    public event EventHandler<EventArgs> Completed; 
    
    void Update()
    {
        if (m_started)
        {
            m_timeLeft = Mathf.Max(0, m_timeLeft -Time.deltaTime);

            if (m_timeLeft == 0)
            {
                m_started = false;
                OnCompleted();
            }
        }
    }

    private void StartCountdown()
    {
        m_timeLeft = totalTime;
        m_started = true;
    }

    private void OnCompleted()
    {
        Completed?.Invoke(this, EventArgs.Empty);
    }
}
