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
        Vector3 targetXPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetXPos, xspeed * Time.deltaTime);

        Vector3 targetYPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetYPos, yspeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("DAMAGE");
            playerController.health--;
        }
    }
}
