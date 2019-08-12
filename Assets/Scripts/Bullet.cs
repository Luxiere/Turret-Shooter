using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Projectile properties")]
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float projectileDestroyTime = 4f;
    [Tooltip("In degree")][SerializeField] float directionChange = 90f;

    [Header("EMP Blast")]
    [SerializeField] GameObject empBlast;
    [SerializeField] float explosionTime = 1f;

    Rigidbody2D rb;
    CircleCollider2D explosionRadius;
    Player player;

    bool moving = true;

    private IEnumerator Start()
    {
        rb = GetComponent<Rigidbody2D>();
        explosionRadius = GetComponent<CircleCollider2D>();
        player = FindObjectOfType<Player>();
        empBlast.SetActive(false);
        yield return new WaitForSeconds(projectileDestroyTime - explosionTime);
        empBlast.SetActive(true);
        moving = false;
        //explosion here
        yield return new WaitForSeconds(explosionTime);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (moving)
        {
            rb.velocity = transform.up * projectileSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.velocity.x > 0 && rb.velocity.y > 0 || rb.velocity.x < 0 && rb.velocity.y < 0)
        {
            gameObject.transform.eulerAngles += new Vector3(0f, 0f, directionChange);
        }
        else
        {
            gameObject.transform.eulerAngles -= new Vector3(0f, 0f, directionChange);
        }
    }
}
