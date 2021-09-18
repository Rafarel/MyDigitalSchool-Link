using UnityEngine;

public class Rupee : MonoBehaviour
{
    public int Score { get; private set; }
    
    private Color m_color;

    public Color Color
    {
        get { return m_color;  }

        set
        {
            m_color = value;
            m_renderer.color = m_color;
        }
    }
    
    private AudioClip m_sound;

    private SpriteRenderer m_renderer;
    
    public Collectible Collectible { get; private set; }
    

    private void Awake()
    {
        Collectible = GetComponent<Collectible>();
        m_renderer = GetComponent<SpriteRenderer>();
    }

    public void LoadData(RupeeData data)
    {
        Color = data.color;
        Score = data.score;
    }
}
