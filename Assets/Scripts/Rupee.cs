using System;
using UnityEngine;

public class Rupee : MonoBehaviour
{
    public RupeeData Data { get; private set; }

    private SpriteRenderer m_renderer;

    public ParticleSystem particles;

    public Light light;

    public Collectible Collectible { get; private set; }
    

    private void Awake()
    {
        Collectible = GetComponent<Collectible>();
        m_renderer = GetComponent<SpriteRenderer>();

        Collectible.Collected += CollectedHandler;
    }

    public void LoadData(RupeeData data)
    {
        Data = data;
        m_renderer.color = Data.color;
        light.color = Data.color;
        
        ParticleSystem.MainModule particleMain = particles.main;
        particleMain.startColor = Data.color;
    }

    private void CollectedHandler(object sender, EventArgs args)
    {
        AudioSource.PlayClipAtPoint(Data.sound, transform.position);
    }

    private void OnDestroy()
    {
        Collectible.Collected -= CollectedHandler;
    }
}
