using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Targay")
        {
            Destroy(other.gameObject);
        }
    }
}
