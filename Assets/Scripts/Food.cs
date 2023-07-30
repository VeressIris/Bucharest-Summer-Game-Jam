using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private GameObject vomitPrefab;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerController.health < 3) 
            {
                playerController.hearts[playerController.health].SetActive(true);
                playerController.health++;
            }

            Instantiate(vomitPrefab, player.transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
