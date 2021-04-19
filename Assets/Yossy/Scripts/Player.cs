using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private Animator animator;
    private SpriteRenderer sprite;
    private AudioSource AudioSE;
    public AudioClip SEgameover;

    [SerializeField] private float jumpForce = 7.0f;//[SerializeField]によってUnityEditor上で編集できる
    [SerializeField] private float walkForce = 4.0f;
    [SerializeField] private float MaxjumpHeight = 2.0f;
    [SerializeField] ContactFilter2D filter2d;

    private bool CanMove = true;//移動可能
    private bool allowJump = true;//ジャンプできるか
    private bool onGround = false;//接地しているか
    private bool PlayjumpSE = false;

    private float key;//左右移動-1,0.1をとる
    private float GroundYpos;


    // Start is called before the first frame update
    void Start()
    {
        filter2d.useNormalAngle = true;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.sprite = GetComponent<SpriteRenderer>();
        this.AudioSE = GetComponent<AudioSource>();
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
    }
    private void FixedUpdate()
    {
        float spd_y=this.rigid2D.velocity.y;
        onGround = rigid2D.IsTouching(filter2d);//接地判定
        if (CanMove)
        {
            if (allowJump)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
                {
                    if (PlayjumpSE)
                    {
                        if (onGround)
                            AudioSE.PlayOneShot(AudioSE.clip);

                        PlayjumpSE = false;
                    }
                    spd_y = jumpForce;
                    if (onGround)//地面についている時、y座標を取得
                        GroundYpos = this.transform.position.y;

                    if (this.transform.position.y >= MaxjumpHeight + GroundYpos)//ジャンプの最高点にいったらジャンプ終了
                        allowJump = false;

                    if (this.rigid2D.velocity.y == 0)//これがないと天井にぶつかったときに空中に浮いてしまう
                        allowJump = false;
                }
                else
                     allowJump = false;
            }
            else
            {
                if (!allowJump && onGround)
                {
                    allowJump = true;
                    PlayjumpSE = true;
                }
            }


            this.animator.SetBool("isjump", !onGround);

            rigid2D.velocity = new Vector2(key * walkForce, spd_y);
        }
        else
            rigid2D.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            this.animator.SetBool("GameOver",true);
            NotMove();
        }
    }

    public void NotMove()
    {
        this.CanMove = false;
        this.AudioSE.PlayOneShot(SEgameover);
    }


}
