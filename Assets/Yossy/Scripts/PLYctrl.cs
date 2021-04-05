using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLYctrl : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    SpriteRenderer sprite;

    [SerializeField] private float jumpForce = 650.0f;//[SerializeField]によってUnityEditor上で編集できる
    [SerializeField] private float walkForce = 7.0f;
    [SerializeField] private float MaxjumpHeight = 2.5f;

    private bool Isjump = false;
    private bool onGround = false;

    float key;


    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
        /*
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
       */
        key = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Xvec", key);
        /*
        if(key>0)
            this.animator.SetTrigger("RightTrigger");
        if (key < 0)
            this.animator.SetTrigger("LeftTrigger");
        */

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //rigid2D.velocity = new Vector2(key * walkForce, rigid2D.velocity.y);
    }
    private void FixedUpdate()
    {
        rigid2D.velocity = new Vector2(key * walkForce, rigid2D.velocity.y);
        //this.rigid2D.AddForce(transform.up * this.jumpForce);
    }

    private void Jump()
    {
        this.Isjump = true;
    }
}
