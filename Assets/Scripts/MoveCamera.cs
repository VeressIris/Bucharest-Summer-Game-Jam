using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float speed = 2f;

    void Update()
    {
        if (playerController.health > 0)
        {
            transform.position = new Vector3(transform.position.x + 1f * speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}
