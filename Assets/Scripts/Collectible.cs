using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string collectorTags;

    public bool autoDestroy = true;

    public event EventHandler<EventArgs> Collected;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag(collectorTags))
        {
            OnCollected();
            if (autoDestroy) Destroy(gameObject);
        }
    }

    protected virtual void OnCollected()
    {
        Collected?.Invoke(this, EventArgs.Empty);
    }
}
