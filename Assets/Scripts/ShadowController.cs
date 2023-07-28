using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
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
            Vector3 targetPos = new Vector3(player.transform.position.x - 3.5f, transform.position.y, player.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
        }
    }

    void FollowPlayer()
    {
        Vector3 targetXPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetXPos, speed * Time.deltaTime);

        //??? maybe change this to something else idk
        Vector3 targetYPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetYPos, speed * Time.deltaTime);
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
