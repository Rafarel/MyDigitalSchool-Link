using UnityEngine;
using UnityEngine.Serialization;

public class Controller : MonoBehaviour
{
    private Rigidbody2D m_body;
    private Animator m_animator;
    private SpriteRenderer m_renderer;

    private float m_Speed;
    
    public float Speed
    {
        get => m_Speed;

        set
        {
            m_Speed = Mathf.Clamp(value, minSpeed, maxSpeed);
        }
    }

    public float minSpeed = 1;

    public float maxSpeed = 5;

    public float speedDecreaseRate; 
    
    void Awake()
    {
        m_body = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float translationX = Input.GetAxis("Horizontal");
        float translationY = Input.GetAxis("Vertical");
        Vector2 translation = new Vector2(translationX, translationY); 

        m_body.velocity = translation * Speed;
        m_animator.SetFloat("translationX", translationX);
        m_animator.SetFloat("translationY", translationY);

        if (translationX != 0) 
        {
            m_renderer.flipX = translationX < 0;
        }

        Speed -= speedDecreaseRate;
    }
}
