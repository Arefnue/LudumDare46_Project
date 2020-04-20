using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour
{
    public static SpawnController instance = null;
    public Vector3 center;
    public float maxDistance;
    public string areaName;

    public CollectableController healthController;
    public CollectableController energyController;
    public int healthSpawnStartTime;
    public int healthSpawnRate;
    public int energySpawnStartTime;
    public int energySpawnRate;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InvokeRepeating("SpawnEnergy",energySpawnStartTime,energySpawnRate);
        InvokeRepeating("SpawnHealth",healthSpawnStartTime,healthSpawnRate);
    }

    public void SpawnHealth()
    {
        var pos = GetRandomPointOnNavmesh();
        var instance = Instantiate(healthController, pos, Quaternion.identity);

    }

    public void SpawnEnergy()
    {
        var pos = GetRandomPointOnNavmesh();
        var instance = Instantiate(energyController, pos, Quaternion.identity);
    }
    
    

    // Get Random Point on a Navmesh surface
    public Vector3 GetRandomPointOnNavmesh() {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;
        
        Debug.DrawLine(center,randomPos,Color.red,12f);
        NavMeshHit hit; // NavMesh Sampling Info Container

        var areaId = 1 << NavMesh.GetAreaFromName(areaName);
        
        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        NavMesh.SamplePosition(randomPos, out hit, maxDistance,areaId);
        
        return hit.position;
    }
}
