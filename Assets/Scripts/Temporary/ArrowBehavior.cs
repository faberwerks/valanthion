using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{

    public Vector2 CurrDir { get; set; }

    public float attackStrength;
    public float lifetime;
    public float speed;

    private void OnEnable()
    {
        Invoke("Destroy", lifetime);
    }

    private void Update()
    {
        Move();
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Move()
    {
        transform.Translate(CurrDir * speed);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.CompareTag("Player"))
        {
            c.collider.SendMessage("TakeDamage", attackStrength);
        }
    }

}
