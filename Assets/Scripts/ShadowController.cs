using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    [Header("Speeds")]
    [SerializeField] private float xspeed = 3f;
    [SerializeField] private float yspeed = 5.5f;

    [Header("Player")]
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerController playerController;

    void Update()
    {
        if (playerController.health > 0)
        {
            FollowPlayer();
        }
        else
        {
            Vector3 targetPos = new Vector3(player.transform.position.x - 2.85f, transform.position.y, player.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, xspeed * Time.deltaTime);

            Vector3 targetYPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetYPos, yspeed * Time.deltaTime);
        }
    }

    void FollowPlayer()
    {
        //follow player on X axis
        Vector3 targetXPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetXPos, xspeed * Time.deltaTime);

        //follow player on Y axis
        Vector3 targetYPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        if (!playerController.IsGrounded())
        {
            targetYPos = new Vector3(transform.position.x, player.transform.position.y - 0.85f, transform.position.z);
        }
        transform.position = Vector3.Slerp(transform.position, targetYPos, yspeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraShake.Instance.ShakeCamera(4.15f, 0.1545f);
            playerController.health--;
        }
    }
}
