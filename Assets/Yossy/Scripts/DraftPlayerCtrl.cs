using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraftPlayerCtrl : MonoBehaviour
{
    //仮のキャラ移動用コード

    [SerializeField] private float speed = 5f;
    [SerializeField] private ContactFilter2D filter2d;

    private bool allowJump = false;
    private bool isMove = true;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriterenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float spd_x = 0f;
        float spd_y = rb2d.velocity.y;

        if (isMove)
            spd_x = Input.GetAxisRaw("Horizontal");

        if (spd_x < 0)
            spriterenderer.flipX = true;
        else if (spd_x > 0)
            spriterenderer.flipX = false;

        // var isTouched = GetComponent<Rigidbody2D>().IsTouching(filter2d);

        rb2d.velocity = new Vector2(spd_x * speed, spd_y);
    }
}
