using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager m_Game;
    
    public TextMeshProUGUI score;
    public TextMeshProUGUI best;
    public TextMeshProUGUI time;
    public Button start;
    
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
        time.text = m_Game.Time.Formated;
        start.gameObject.SetActive(!m_Game.Playing);
    }
}
