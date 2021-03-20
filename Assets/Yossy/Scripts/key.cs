using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    private GameManager gamemanager;
    private Animator keyAnim;

    // Start is called before the first frame update
    void Start()
    {
        keyAnim = GetComponent<Animator>();
        keyAnim.SetBool("IsGetkey", false);
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gamemanager.UpCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GetComponent<PolygonCollider2D>().enabled = false;
        gamemanager.DownCount();
        keyAnim.SetBool("IsGetkey", true);
    }
}
