using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string targetTag;

    public int damage = 5;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * (35 * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            other.gameObject.GetComponent<IEntity>()?.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Wall")) Destroy(gameObject);
    }
}