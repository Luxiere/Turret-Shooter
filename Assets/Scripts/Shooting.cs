using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject EmptyBullet;
    public Vector2 BulletSpeed;
    float count;
    public Transform MuzzlePos;


    private void Start()
    {
        count = 1;

        
    }

    private void OnMouseUp()
    {
        Debug.Log("Touch Detected");
        if (count > 0)
        {
            EmptyBullet = Instantiate(Bullet, MuzzlePos) as GameObject;
            Bullet.gameObject.GetComponent<Rigidbody2D>().velocity = BulletSpeed;       
              
                
                }

    }
}
