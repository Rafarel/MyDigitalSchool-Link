using UnityEngine;

public class ParticleOnDestroy : MonoBehaviour
{
    public ParticleSystem particle;

    public Color color;
    
    private void OnDestroy()
    {
        ParticleSystem ps = Instantiate(particle, transform.position, Quaternion.identity);
        ParticleSystem.MainModule particleMain = ps.main;
        particleMain.startColor = color;
    }
}
