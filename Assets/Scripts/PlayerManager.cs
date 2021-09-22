using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameManager m_Game;
    
    public  Controller controller;

    private void Awake()
    {
        m_Game = GameManager.Instance;
    }

    private void Start()
    {
        m_Game.Rupees.RupeeCollected += RupeeCollectedHandler;
    }

    private void RupeeCollectedHandler(object sender, RupeeEvent e)
    {
        controller.Speed += e.Rupee.Data.speedBonus;
    }

    private void OnDestroy()
    {
        m_Game.Rupees.RupeeCollected -= RupeeCollectedHandler;
    }
}
