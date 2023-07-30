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
        StartCoroutine(Spawn(Random.Range(1.25f, 2.1f), buildings.Length));
    }

    IEnumerator Spawn(float speed, int len)
    {
        while (playerController.health > 0)
        {
            Instantiate(buildings[Random.Range(0, len)], transform.position, transform.rotation);
            
            int spawnPuddle = Random.Range(1, 0);
            if (spawnPuddle == 1)
            {
                Vector3 puddleSpawn = GetPuddleSpawnPoint();
                Instantiate(puddle, puddleSpawn, transform.rotation);
            }

            yield return new WaitForSeconds(speed);
        }
    }

    Vector3 GetPuddleSpawnPoint()
    {
        float randomOffset = Random.Range(0f, 3.8f);
        return new Vector3(transform.position.x + randomOffset, transform.position.y, transform.position.z);
    }
}
