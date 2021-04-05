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
    [SerializeField] ContactFilter2D filter2d;

    private bool Isjump = false;
    private bool onGround = false;

    float key;//左右移動-1,0.1をとる


    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.sprite = GetComponent<SpriteRenderer>();
        if (sprite.sprite.name == "right1")
            animator.SetBool("startidle", true);
        else
            animator.SetBool("startidle", false);
    }

    // Update is called once per frame
    void Update()
    {
        key = Input.GetAxisRaw("Horizontal");//左-1,右1,その他0
        animator.SetFloat("Xvec", key);

        onGround = rigid2D.IsTouching(filter2d);

        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
    }
    private void FixedUpdate()
    {
        rigid2D.velocity = new Vector2(key * walkForce, rigid2D.velocity.y);
        if (Isjump)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            Isjump = false;
        }
    }

    private void Jump()
    {
        this.Isjump = true;
    }
}
