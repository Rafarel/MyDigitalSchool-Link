using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public int totalTime = 60;

    private float m_timeLeft;

    private bool m_started;

    public event EventHandler<EventArgs> Completed;

    public string Formated
    {
        get
        {
            int minutes = Mathf.FloorToInt(m_timeLeft / 60);
            int seconds = Mathf.FloorToInt(m_timeLeft % 60);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    
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

    public void StartCountdown()
    {
        m_timeLeft = totalTime;
        m_started = true;
    }

    private void OnCompleted()
    {
        Completed?.Invoke(this, EventArgs.Empty);
    }
}
