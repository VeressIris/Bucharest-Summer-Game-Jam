using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] buildings;
    [SerializeField] private GameObject puddle;
    [SerializeField] private float buildingSpawnSpeed;
    [SerializeField] private PlayerController playerController;

    void Start()
    {
        StartCoroutine(Spawn(Random.Range(0.78f, 1.85f), buildings.Length));
    }

    IEnumerator Spawn(float speed, int len)
    {
        while (playerController.health > 0)
        {
            GameObject instantiatedBuilding = Instantiate(buildings[Random.Range(0, len)], transform.position, transform.rotation);
            Transform puddleSpawnY = instantiatedBuilding.transform.GetChild(0).transform;

            //decide if puddle should be spawned
            int spawnPuddle = Random.Range(0, 2);
            if (spawnPuddle == 1)
            {
                Vector3 puddleSpawn = GetPuddleSpawnPoint(puddleSpawnY);
                Instantiate(puddle, puddleSpawn, transform.rotation, instantiatedBuilding.transform);
            }

            yield return new WaitForSeconds(speed);
        }
    }

    Vector3 GetPuddleSpawnPoint(Transform puddleSpawnY)
    {
        float randomOffset = Random.Range(-1f, 2f);
        return new Vector3(transform.position.x + randomOffset, puddleSpawnY.position.y, transform.position.z);
    }
}
