using UnityEngine;

public class Rupee : MonoBehaviour
{
    private Color m_color;

    private AudioClip m_sound;

    private int m_score;

    private SpriteRenderer m_Renderer;
    
    public Collectible Collectible { get; private set; }
    

    private void Awake()
    {
        Collectible = GetComponent<Collectible>();
    }

    public void LoadData(RupeeData data)
    {
        m_color = data.color;
        m_score = data.score;
    }
}
