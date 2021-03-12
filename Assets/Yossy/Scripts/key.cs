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
        keyAnim.SetBool("IsGetKey", false);
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gamemanager.UpCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        keyAnim.SetBool("IsGetKey", true);
        gamemanager.DownCount();
        //Destroy(this.gameObject);
    }
}
