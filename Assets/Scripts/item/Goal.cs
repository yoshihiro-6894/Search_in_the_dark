using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private Animator goalAnim;
    private AudioSource AudioGoal;
    private Collider2D col2d;
    [Header("ゴールアイテムが出現時のSE")]public AudioClip Awakegoal;
    [Header("ステージクリアのSE")]public AudioClip FinishStage;
    [Header("プレイヤーキャラクタ")]public GameObject Player;
    //public GameObject fademanage;

    private bool NotFinish = true;

    // Start is called before the first frame update
    void Start()
    {
        AudioGoal = GetComponent<AudioSource>();
        AudioGoal.PlayOneShot(Awakegoal);
        col2d = GetComponent<BoxCollider2D>();
        goalAnim = GetComponent<Animator>();
        goalAnim.SetBool("isGet", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        col2d.enabled = false;
        goalAnim.SetBool("isGet", true);
        if (NotFinish)
        {
            AudioGoal.PlayOneShot(FinishStage);
            NotFinish = false;
            Player.GetComponent<Player>().GetGoal();
            FadeManager.Instance.LoadScene("StageResult", 2.0f, false);
        }
    }
}
