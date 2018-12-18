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

        float angle = Mathf.Atan2(CurrDir.y, CurrDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            c.SendMessage("TakeDamage", attackStrength);
            Destroy();
        }
    }

}
