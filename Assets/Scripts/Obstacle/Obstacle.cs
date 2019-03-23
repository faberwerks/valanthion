using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    protected SpriteRenderer sprRend;

    protected Color initialColor;

    public bool destroyable;
    public float health;
    public bool damages;
    public float damage;

    protected float colorTime;
    protected float colorTimer;

    private void Start()
    {
        sprRend = gameObject.GetComponent<SpriteRenderer>();
        initialColor = sprRend.color;
        colorTime = 0.2f;
        colorTimer = colorTime;
    }

    private void Update()
    {
        if (!CheckHealth())
        {
            Destroy(gameObject);
        }
    }

    // a method to check the obstacle's health
    // returns true if still alive, false otherwise
    private bool CheckHealth()
    {
        if (health < 0)
        {
            return false;
        }
        return true;
    }

    // a method to damage obstacle health
    public void TakeDamage(float damage)
    {
        if (destroyable)
        {
            health -= Mathf.FloorToInt(damage);
            StartCoroutine(CTimeColorChange());
        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.CompareTag("Player") && damages)
        {
            c.collider.SendMessage("TakeDamage", damage);
        }
    }

    //COROUTINES
    // color change timer
    protected IEnumerator CTimeColorChange()
    {
        sprRend.color = new Color(255f, 0.0f, 0.0f, 255f);
        colorTimer = colorTime;

        while (colorTimer > 0)
        {
            colorTimer -= Time.deltaTime;
            yield return 0;
        }

        sprRend.color = initialColor;
        yield break;
    }
}
