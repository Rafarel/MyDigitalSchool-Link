using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RupeesManager : MonoBehaviour
{
    private readonly List<Rupee> m_Rupees = new List<Rupee>();

    public Transform spawner;
    
    public Transform container;
    
    public Rupee rupeePrefab;
    
    [Range(0.1f, 10)]
    public float delay = 2f;

    public List<RupeeData> rupeeData;

    private Coroutine m_SpawnRoutine;

    public event EventHandler<RupeeEvent> Spawned;
    
    public event EventHandler<RupeeEvent> RupeeCollected;
    
    public void StartSpawning()
    {
        m_SpawnRoutine = StartCoroutine(SpawnRoutine());
    }
    
    public void StopSpawning()
    {
        if (m_SpawnRoutine != null)
        {
            StopCoroutine(m_SpawnRoutine);
            m_SpawnRoutine = null;
        }
    }

    private IEnumerator SpawnRoutine()
    {
        Spawn();
        yield return new WaitForSeconds(delay);
        m_SpawnRoutine = StartCoroutine(SpawnRoutine());
    }

    private void Spawn()
    {
        // Instantiate the rupee
        Rupee go = Instantiate(rupeePrefab, transform.position, Quaternion.identity);
        go.transform.parent = container.transform;

        Rupee rupee = go.GetComponent<Rupee>();
        
        // Load random data
        RupeeData data = GetRandomRupeeData();
        rupee.LoadData(data);
        
        // Add listener
        rupee.Collectible.Collected += CollectedHandler;
        
        // Add the rupee to the list
        m_Rupees.Add(rupee);

        // Dispatch Spawned event
        OnSpawned(new RupeeEvent(rupee));
    }

    private RupeeData GetRandomRupeeData()
    {
        int index = Random.Range(0, rupeeData.Count);
        return rupeeData[index];
    }

    public void Clear()
    {
        foreach (Rupee rupee in m_Rupees)
        {
            Destroy(rupee.gameObject);
        }
        
        m_Rupees.Clear();
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
            m_Rupees.Remove(rupee);

            // Dispatch collected event
            OnRupeeCollected(new RupeeEvent(rupee));
        }
    }
    
    private void OnSpawned(RupeeEvent e)
    {
        Spawned?.Invoke(this, e);
    }

    private void OnRupeeCollected(RupeeEvent e)
    {
        RupeeCollected?.Invoke(this, e);
    }
}
