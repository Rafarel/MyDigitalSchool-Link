using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject container;
    public GameObject rupee;

    [Range(1, 10)]
    public float delay = 2f;

    public List<GameObject> m_rupees;

    public event EventHandler<EventArgs> Spawned;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

     IEnumerator SpawnRoutine()
    {
        Spawn();
        yield return new WaitForSeconds(delay);
        StartCoroutine(SpawnRoutine());
    }

    private void Spawn()
    {
        GameObject go = Instantiate(rupee, transform.position, Quaternion.identity);
        go.transform.parent = container.transform;

        Collectible collectible = go.GetComponent<Collectible>();
        collectible.Collected += RuppeCollected;

        m_rupees.Add(go);
    }

    private void RuppeCollected(object sender, EventArgs args)
    {
        Collectible collectible = sender as Collectible;
        m_rupees.Remove(collectible.gameObject);
    }

    protected virtual void OnSpawned()
    {
        Spawned?.Invoke(this, EventArgs.Empty);
    }
}
