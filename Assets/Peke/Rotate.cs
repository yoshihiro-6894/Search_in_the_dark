using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float rotSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        transform.Rotate(0, rotSpeed, 0);   //ここで回転

        Destroy(this.gameObject, 1.0f);
    }
}
