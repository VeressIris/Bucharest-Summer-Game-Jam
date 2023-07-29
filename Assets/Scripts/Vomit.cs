using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vomit : MonoBehaviour
{
    private float initPlayerSpeed;
    private PlayerController playerController;
    [SerializeField] private float slowDuration = 3f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float spawnPower = 2.5f;

    void Start()
    {
        rb.AddForce(transform.right * spawnPower, ForceMode2D.Impulse);
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
        playerController.moveSpeed = 5.25f;
        yield return new WaitForSeconds(slowDuration);
        playerController.moveSpeed = initPlayerSpeed;
    }
}
