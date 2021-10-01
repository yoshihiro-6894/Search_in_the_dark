using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject goal;//鍵を全部取ったら出現するゴール
    private int CountKey = 0;//鍵の数
    private bool Set = false;
    [SerializeField] private int nowStage = 1;
    //public stageButton nextbutton;
    //public FadeManager fade;


    private void Awake()
    {
        goal.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        RegisterResult.STAGE_NUMBER = nowStage;
        //nextbutton.SetStageNumber(nowStage);
        //fade.SetStagenuber(nowStage);
    }

    // Update is called once per frame
    void Update()
    {
        if(!Set && CountKey != 0)//鍵が0じゃなくSetがfalseのとき
        {
            Set = true;
        }

        if (Set && CountKey == 0)//鍵が0かつSetがtrueのとき
        {
            StartCoroutine(GoalSet());
        }
    }

    public void UpCount()
    {
        CountKey++;
    }

    public void DownCount()
    {
        CountKey--;
    }

    IEnumerator GoalSet()
    {
        yield return new WaitForSeconds(3f);
        goal.SetActive(true);
        yield return null;
    }
}
