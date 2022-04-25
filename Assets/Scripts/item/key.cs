using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    private GameManager gamemanager;
    [SerializeField]private Animator keyAnim;
    [SerializeField]private AudioSource audioSource;
    [SerializeField]private Collider2D col2d;

    private bool NotGet = true;

    // Start is called before the first frame update
    void Start()
    {
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
        if (NotGet)
        {
            audioSource.PlayOneShot(audioSource.clip);
            NotGet = false;
        }
        col2d.enabled = false;
        gamemanager.DownCount();
        keyAnim.SetBool("IsGetkey", true);
    }
}
