using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerVoid : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private CinemachineVirtualCamera virtualCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController.health = 0;

            virtualCam.Follow = null;
        }
    }
}
