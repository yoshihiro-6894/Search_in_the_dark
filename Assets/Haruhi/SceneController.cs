using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ボタンを使用するためUIとSceneManagerを使用するためSceneManagementを追加
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    // ボタンをクリックするとPreStage1に移動する
    public void ButtonClicked()
    {
        SceneManager.LoadScene("PreStage1");
    }
}