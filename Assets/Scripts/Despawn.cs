using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    private GameObject cam;

    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {
        if (transform.position.x < cam.transform.position.x - 20) 
        {
            Destroy(gameObject);
        }
    }
}
