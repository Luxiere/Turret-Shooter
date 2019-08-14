using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blobsmovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 Mov = new Vector3(0, 1, 0);
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Mov * speed * Time.deltaTime;
    }
}
