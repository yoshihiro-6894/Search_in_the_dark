using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ボタンを使用するためUIとSceneManagerを使用するためSceneManagementを追加
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //はるひさんのスクリプト

    Text stagenumber;//ボタンの中にあるテキスト

    private void Start()
    {
        stagenumber = GetComponentInChildren<Text>();
    }
    // ボタンをクリックするとPreStage1に移動する
    public void ButtonClicked()
    {
        //SceneManager.LoadScene("PreStage");これははるひさんが書いたコード後で見直すように残しておきます。

        SceneManager.LoadScene("Stage_" + stagenumber.text);//テキストに1が書いてあればStage_1へ
    }
}