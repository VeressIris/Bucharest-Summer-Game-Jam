using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vomit : MonoBehaviour
{
    private float initPlayerSpeed;
    private PlayerController playerController;
    [SerializeField] private float slowDuration = 3f;

    void Start()
    {
        StartCoroutine(DelayedDespawn());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController = collision.gameObject.GetComponent<PlayerController>();
            initPlayerSpeed = playerController.moveSpeed;
            
            StartCoroutine(SlowPlayer());
        }
    }

    IEnumerator DelayedDespawn()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }

    IEnumerator SlowPlayer()
    {
        playerController.moveSpeed -= 1.75f;
        yield return new WaitForSeconds(slowDuration);
        playerController.moveSpeed = initPlayerSpeed;
    }
}
