using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideBlock : MonoBehaviour
{
    [Header("移動経路")] public GameObject[] movePoint;
    [Header("移動速度")] public float speed = 1.0f;

    private Rigidbody2D rbody2d;
    private int nowPoint = 0;
    private bool returnPoint = false;

    Vector2 BlockVec;

    // Start is called before the first frame update
    void Start()
    {
        rbody2d = GetComponent<Rigidbody2D>();
        if (movePoint.Length > 0)
        {
            transform.position = movePoint[0].transform.position;
            rbody2d.position = movePoint[0].transform.position;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //rbody2d.velocity = new Vector2(1, 0);
        
        if (movePoint != null && movePoint.Length > 1 && rbody2d != null)
        {
            if (!returnPoint)
            {
                int nextPoint = nowPoint + 1;
                if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
                {
                    Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);
                    
                    rbody2d.MovePosition(toVector);
                }
                else
                {
                    rbody2d.MovePosition(movePoint[nextPoint].transform.position);
                    nowPoint++;

                    if (nowPoint + 1 >= movePoint.Length)
                    {
                        returnPoint = true;
                    }
                }
            }
            else
            {
                int nextPoint = nowPoint - 1;
                if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
                {
                    Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);

                    rbody2d.MovePosition(toVector);
                }
                else
                {
                    rbody2d.MovePosition(movePoint[nextPoint].transform.position);
                    nowPoint--;

                    if (nowPoint <=0)
                    {
                        returnPoint = false;
                    }
                }
            }
        }
        //BlockVec = rbody2d.GetPointVelocity(Vector2.zero) ;
        //Debug.Log(BlockVec);
    }
}
