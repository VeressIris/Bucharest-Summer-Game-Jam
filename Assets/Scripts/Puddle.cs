using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraShake.Instance.ShakeCamera(4.15f, 0.1545f);

            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.TakeDamage();
        }
    }
}
