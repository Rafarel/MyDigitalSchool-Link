using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody2D m_body;
    private Animator m_animator;
    private SpriteRenderer m_renderer;

    [Range(0f, 5f)]
    public float speed = 1; 
    
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

        m_body.velocity = translation * speed;
        m_animator.SetFloat("translationX", translationX);
        m_animator.SetFloat("translationY", translationY);

        if (translationX != 0) 
        {
            m_renderer.flipX = translationX < 0;
        }
    }
}
