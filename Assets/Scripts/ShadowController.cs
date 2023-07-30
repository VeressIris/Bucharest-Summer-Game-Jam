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
    [HideInInspector] public bool canMove = false;

    [Header("Anim")]
    [SerializeField] private Animator anim;


    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (canMove)
        {
            if (playerController.health > 0)
            {
                FollowPlayer();
            }
            else if (playerController.health <= 0)
            {
                anim.Play("Idle");
                
                xspeed = 3.75f;
                Vector3 targetPos = new Vector3(player.transform.position.x - 3.5f, transform.position.y, player.transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPos, xspeed * Time.deltaTime);

                Vector3 targetYPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetYPos, yspeed * Time.deltaTime);
            }
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
            targetYPos = new Vector3(transform.position.x, player.transform.position.y - 1.3f, transform.position.z);
            anim.Play("Shadow Jump");
        }
        else anim.Play("Shadow Walk");

        transform.position = Vector3.Slerp(transform.position, targetYPos, yspeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraShake.Instance.ShakeCamera(4.15f, 0.1545f);
            playerController.TakeDamage();
        }
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(0.45f);
        canMove = true;
    }
}
