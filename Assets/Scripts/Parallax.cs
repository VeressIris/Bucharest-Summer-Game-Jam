using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght;
    private float startPos;
    [SerializeField] private GameObject cam;
    [SerializeField] private float strength;

    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float dist = cam.transform.position.x * strength;
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        
        float temp = cam.transform.position.x * (1 - strength);
        if (temp > startPos + lenght) startPos += lenght;
        else if (temp < startPos - lenght) startPos -= lenght;
    }
}
