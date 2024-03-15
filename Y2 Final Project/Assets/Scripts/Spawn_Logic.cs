using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Logic : MonoBehaviour, ISpawnRandomPoint
{
    public List<Transform> _SpawnLocations = new List<Transform>();

    private void OnValidate()
    {
        _SpawnLocations.Clear();
        Transform[] spawnPoints = FindObjectsOfType<Transform>();

        foreach (Transform spawnPoint in spawnPoints)
        {
            if (spawnPoint.CompareTag("SpawnPoint"))
            {
                _SpawnLocations.Add(spawnPoint);
            }
        }
    }

    public void SpawnAtRandomPoint(GameObject PrefabToSpawn, List<Transform> SpawnLocations)
    {
        _SpawnLocations = SpawnLocations;
        int RandomIndex = Random.Range(0, _SpawnLocations.Count);
        PrefabToSpawn.transform.position = new Vector3(_SpawnLocations[RandomIndex].position.x, PrefabToSpawn.transform.position.y, _SpawnLocations[RandomIndex].position.z + 4);
    }
}
