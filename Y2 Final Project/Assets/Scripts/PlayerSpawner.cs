using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour, ISpawnRandomPoint
{
    [SerializeField] private GameObject _player;

    private List<Transform> _spawnLocations = new List<Transform>();

    public List<Transform> SpawnLocations { get => _spawnLocations; set => _spawnLocations = value; }

    private void OnValidate()
    {
        SpawnLocations.Clear();
        Transform[] allTransforms = FindObjectsOfType<Transform>();

        foreach (Transform singleTransform in allTransforms)
        {
            if (singleTransform.CompareTag("SpawnPoint"))
            {
                SpawnLocations.Add(singleTransform);
            }
            else if(singleTransform.CompareTag("Player"))
            {
                _player = singleTransform.GetComponent<Transform>().gameObject;
            }
        }
    }

    private void Start()
    {
        if (SpawnLocations.Count == 0)
            return;
        SpawnAtRandomPoint(_player);
    }

    public void SpawnAtRandomPoint(GameObject PrefabToSpawn)
    {
        int RandomIndex = Random.Range(0, SpawnLocations.Count);
        Vector3 spawnLocation = 
            new Vector3(SpawnLocations[RandomIndex].position.x, PrefabToSpawn.transform.position.y, SpawnLocations[RandomIndex].position.z);
        PrefabToSpawn.transform.position = spawnLocation;
    }
}
