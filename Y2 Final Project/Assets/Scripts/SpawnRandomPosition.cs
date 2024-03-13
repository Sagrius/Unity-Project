using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnRandomPoint
{
    public void SpawnAtRandomPoint(GameObject PrefabToSpawn, Transform SpawnPoint1, Transform SpawnPoint2, Transform SpawnPoint3, Transform SpawnPoint4);
}