using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vomit : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField] private float slowDuration = 3f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float spawnPower = 2.5f;
    
    [Header("Checks")]
    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private LayerMask playerLayer;
    private bool playerSlowed = false;
    private PlayerController playerController;
    private float initPlayerSpeed;

    void Start()
    {
        rb.AddForce(transform.right * spawnPower, ForceMode2D.Impulse);

        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        initPlayerSpeed = playerController.moveSpeed;

        StartCoroutine(DelayedDespawn());
    }

    private void Update()
    {
        if (playerController.OnVomit() && !playerSlowed)
        {
            playerSlowed = true;
            StartCoroutine(SlowPlayer());
        }
    }

    IEnumerator DelayedDespawn()
    {
        yield return new WaitForSeconds(8.25f);
        Destroy(gameObject);
    }

    public IEnumerator SlowPlayer()
    {
        playerController.moveSpeed = 5.25f;
        
        yield return new WaitForSeconds(slowDuration);
        
        playerController.moveSpeed = initPlayerSpeed;
        playerSlowed = false;
    }
}
