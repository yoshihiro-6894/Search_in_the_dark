using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject goal;//鍵を全部取ったら出現するゴール
    private int CountKey = 0;//鍵の数
    private bool Set = false;

    // Start is called before the first frame update
    void Start()
    {
        goal.SetActive(false);//ゴールを非表示にする
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
            goal.SetActive(true);//ゴールを表示する
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
}
