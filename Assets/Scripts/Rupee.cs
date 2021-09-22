using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Rupee : MonoBehaviour
{
    public ParticleSystem particles;
    
    public Light pointLight;
    
    public RupeeData Data { get; private set; }

    private SpriteRenderer m_Renderer;

    private ParticleOnDestroy m_ParticleDestroy;


    public Collectible Collectible { get; private set; }


    private void Awake()
    {
        Collectible = GetComponent<Collectible>();
        m_ParticleDestroy = GetComponent<ParticleOnDestroy>();
        m_Renderer = GetComponent<SpriteRenderer>();

        Collectible.Collected += CollectedHandler;
    }

    public void LoadData(RupeeData data)
    {
        Data = data;
        m_Renderer.color = Data.color;
        pointLight.color = Data.color;
        
        ParticleSystem.MainModule particleMain = particles.main;
        particleMain.startColor = Data.color;

        m_ParticleDestroy.color = Data.color;
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
