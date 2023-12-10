using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : MonoBehaviour
{
    public float shrinkSpeed;
    public GameObject particle;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (transform.localScale.x > 1.35f)
        {
            transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        }
    }

    private void OnMouseDown()
    {
        GameManager.clicks++;
        transform.localScale = Vector3.one * 1.5f;
        source.PlayOneShot(source.clip);
        Instantiate(particle, new Vector3(Random.Range(-2.3f, 2.3f), 7f, 2.1f), transform.rotation);
    }
}
