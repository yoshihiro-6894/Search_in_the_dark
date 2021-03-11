using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //追加しましょう

public class Button : MonoBehaviour
{
    public GameObject score_object = null; //textオブジェクト

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.Getcomponent<Text>();

        //テキストの表示を入れ替える
        score_text.text = "PreStage1";
    }
}
