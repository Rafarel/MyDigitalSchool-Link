using UnityEngine;

public class MoveRandom : MonoBehaviour
{
    private Rigidbody2D m_body;

    [Range(0f, 5f)]
    public float speed = 1;

    void Awake()
    {
        m_body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        int x = Random.value < 0.5f ? -1 : 1;
        int y = Random.value < 0.5f ? -1 : 1;
        Vector2 velocity = new Vector2(x, y);
        m_body.velocity = velocity * speed;
    }
}
