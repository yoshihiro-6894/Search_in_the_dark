using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private Animator goalAnim;

    // Start is called before the first frame update
    void Start()
    {
        goalAnim = GetComponent<Animator>();
        goalAnim.SetBool("isGet", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        goalAnim.SetBool("isGet", true);
    }
}
