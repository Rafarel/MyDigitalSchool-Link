using System;
using System.Collections.Generic;
using UnityEngine;

public class RupeesManager : MonoBehaviour
{
    private List<Rupee> m_rupees = new List<Rupee>();

    public RupeeSpawner spawner;
    
    public event EventHandler<RupeeEvent> RupeeCollected;

    // Start is called before the first frame update
    private void Start()
    {
        spawner.Spawned += SpawnedHandler;
    }

    private void SpawnedHandler(object sender, RupeeEvent args)
    {
        // Get the rupee
        Rupee rupee = args.Rupee;

        // Add listener
        rupee.Collectible.Collected += CollectedHandler;
        
        // Add the rupee to the list
        m_rupees.Add(rupee);
    }

    private void CollectedHandler(object sender, EventArgs args)
    {
        // Get the sender as Collectible instance
        Collectible c = sender as Collectible;
        Rupee rupee = c.GetComponent<Rupee>();

        if (rupee)
        {
            // Remove the event handler
            rupee.Collectible.Collected -= CollectedHandler;

            // Remove from the list
            m_rupees.Remove(rupee);

            // Dispatch collected event
            OnRupeeCollected(new RupeeEvent(rupee));
        }
    }

    private void OnRupeeCollected(RupeeEvent e)
    {
        RupeeCollected?.Invoke(this, e);
    }

    private void OnDestroy()
    {
        spawner.Spawned -= SpawnedHandler;
    }
}
