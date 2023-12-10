using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public float destroyDelay;
    Vector3 rotation;

    void Start()
    {
        rotation = Random.insideUnitSphere * 90;
        Destroy(gameObject, destroyDelay);
    }

    private void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}