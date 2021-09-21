using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager m_Game;
    
    public TextMeshProUGUI score;
    public TextMeshProUGUI best;
    
    // Start is called before the first frame update
    void Awake()
    {
        m_Game = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score : " + m_Game.Score.Value;
        best.text = "Best : " + m_Game.Score.Best;
    }
}
