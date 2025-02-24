using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cheese : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnCheese();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCheese()
    {
        // Picks a random point on the NavMesh to spawn cheese when the function is called
        Vector3 randomPoint = Random.insideUnitSphere * 80;
        NavMeshHit navHit;
        if (!NavMesh.SamplePosition(randomPoint, out navHit, 100, NavMesh.AllAreas))
        {
            return;
        }
        transform.position = navHit.position;
    }
}
