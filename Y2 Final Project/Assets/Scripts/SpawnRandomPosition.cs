using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnRandomPoint
{
    public void SpawnAtRandomPoint(GameObject PrefabToSpawn, List<Transform> SpawnsLocations);
}