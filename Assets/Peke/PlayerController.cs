using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;

    [SerializeField] private float jumpForce = 650.0f;//[SerializeField]によってUnityEditor上で編集できる
    [SerializeField] private float walkForce = 7.0f;
    //float maxwalkSpeed = 10.0f;
   
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;
        if (Input.GetKey(KeyCode.D))
        {
            key = 1;
            this.animator.SetTrigger("RightTrigger");
        }
        if (Input.GetKey(KeyCode.A))
        {
            key = -1;
            this.animator.SetTrigger("LeftTrigger");
        }


        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        rigid2D.velocity = new Vector2(key * walkForce, rigid2D.velocity.y);
        /*
        if(speedx < this.maxwalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        if(key == 0)
        {
            rigid2D.velocity = new Vector2(0f, this.rigid2D.velocity.y);
        }
        */
        this.animator.speed = speedx/2.0f;
    }
}
