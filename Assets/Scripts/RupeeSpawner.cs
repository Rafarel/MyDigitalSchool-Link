
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RupeeSpawner : MonoBehaviour
{
    public GameObject container;
    
    public Rupee rupeePrefab;
    
    [Range(1, 10)]
    public float delay = 2f;

    public List<RupeeData> rupeeData;

    public event EventHandler<RupeeEvent> Spawned;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        Spawn();
        yield return new WaitForSeconds(delay);
        StartCoroutine(SpawnRoutine());
    }

    private void Spawn()
    {
        // Instanciate the rupee
        Rupee go = Instantiate(rupeePrefab, transform.position, Quaternion.identity);
        go.transform.parent = container.transform;

        Rupee rupee = go.GetComponent<Rupee>();
        RupeeData data = GetRandomRupeeData();
        rupee.LoadData(data);

        // Dispatch Spawned event
        OnSpawned(new RupeeEvent(rupee));
    }

    private RupeeData GetRandomRupeeData()
    {
        int index = Random.Range(0, rupeeData.Count);
        return rupeeData[index];
    }

    private void OnSpawned(RupeeEvent e)
    {
        Spawned?.Invoke(this, e);
    }
}
