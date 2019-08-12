using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Vector2 target;
    public float speed;

    public float turnSpeed;
    Vector3 moveDirection;

    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        StartCoroutine(destroyAfterTime());
        moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        moveDirection.z = 0;
        moveDirection.Normalize();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

        transform.position = transform.position + moveDirection * speed * Time.deltaTime;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Targay")
        {
            Destroy(gameObject);
        }
    }


    IEnumerator destroyAfterTime()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

}
