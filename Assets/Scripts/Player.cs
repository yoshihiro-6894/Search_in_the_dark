using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rigid2D;
    [SerializeField]private Animator animator;
    [SerializeField]private SpriteRenderer sprite;
    [SerializeField]private AudioSource AudioSE;
    public AudioClip SEgameover;

    [Header("ジャンプ力")][SerializeField] private float jumpForce = 7.0f;//[SerializeField]によってUnityEditor上で編集できる
    [Header("移動の力")][SerializeField] private float walkForce = 4.0f;
    [Header("ジャンプの最大の高さ")][SerializeField] private float MaxjumpHeight = 2.0f;
    [SerializeField] ContactFilter2D filter2d;//接地判定に用いる
    [SerializeField] ContactFilter2D upfilter2d;//天井にぶつかったかどうかを判定する
    [SerializeField] ContactFilter2D slidefilter2d;

    private bool CanMove = true;//移動可能
    private bool onGround = false;//接地しているか
    private bool upGround = false;//天井にぶつかっているか
    private bool onMoveBlock = false;//動く床にのっているか
    private bool ablejump = false;//ジャンプ可能
    private bool already_jump = false;//ジャンプキーを押している間1度でもジャンプしたかどうか
    private bool StageClear = false;

    private float key;//左右移動-1,0.1をとる
    private float spd_y;
    private float GroundYpos;//ジャンプ時の自分のY座標


    // Start is called before the first frame update
    void Start()
    {
        filter2d.useNormalAngle = true;
        upfilter2d.useNormalAngle = true;
        slidefilter2d.useNormalAngle = true;
        if (sprite.sprite.name == "right1")
            animator.SetBool("startidle", true);
        else
            animator.SetBool("startidle", false);
    }

    private void Update()
    {
        key = Input.GetAxisRaw("Horizontal");//左-1,右1,その他0
        animator.SetFloat("Xvec", key);
    }


    private void FixedUpdate()
    {

        spd_y=this.rigid2D.velocity.y;
        onGround = rigid2D.IsTouching(filter2d);//接地判定
        upGround = rigid2D.IsTouching(upfilter2d);
        onMoveBlock = rigid2D.IsTouching(slidefilter2d);

        if (!CanMove)
        {
            rigid2D.velocity = Vector2.zero;
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            JumpAction();

        }
        else//ジャンプキーを離したら(押すのをやめたら)
        {
            ablejump = false;
            if (onGround)//地面に着くと
            {
                already_jump = false;
                ablejump = true;
            }

        }

        if (StageClear)
        {
            key = 0;
            this.animator.SetFloat("Xvec", 0);
        }

        this.rigid2D.velocity = new Vector2(key * walkForce, spd_y);

        this.animator.SetBool("isjump", !onGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")//当たったコライダーのタグがTrapだったら
        {
            if(!StageClear)
                NotMove();
        }

    }

    public void NotMove()
    {
        this.animator.SetBool("GameOver", true);
        if (CanMove)//2個以上のトゲに当たった場合SEの重複が起きないようにする
            this.AudioSE.PlayOneShot(SEgameover);
        this.CanMove = false;//動けなくする
        this.rigid2D.bodyType = RigidbodyType2D.Kinematic;
        RegisterResult.STAGE_CLEAR = false;
        FadeManager.Instance.LoadScene("StageResult", 2.0f, false);
    }
    
    public void GetGoal()
    {
        StageClear = true;
        RegisterResult.STAGE_CLEAR = true;
    }

    private void JumpAction()
    {
        if (!ablejump) return;

        if (onGround && !already_jump)
        {
            Debug.Log("ジャンプ押した！");
            ablejump = true;
            AudioSE.PlayOneShot(AudioSE.clip);//ジャンプ音再生
            GroundYpos = this.transform.position.y;//地面のy座標を取得
            already_jump = true;
        }


        spd_y = jumpForce;

        this.rigid2D.velocity = new Vector2(key * walkForce, spd_y);

        if (this.transform.position.y >= MaxjumpHeight + GroundYpos)//ジャンプの最高点にいったらジャンプ終了
        {
            ablejump = false;
            Debug.Log("maxJump");
        }


        if (upGround)//これがないと天井にぶつかったときに空中に浮いてしまう
        {
            ablejump = false;
            Debug.Log("天井");
        }
    }
}
