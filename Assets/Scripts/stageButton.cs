using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageButton : MonoBehaviour
{
    private int stagenumber;
    private float fadetime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        SetStageNumber(RegisterResult.STAGE_NUMBER);
        Cursor.visible = true;
    }

   

    public void AgainStage()
    {
        string scenename = "Stage_" + stagenumber.ToString();
        FadeManager.Instance.LoadScene(scenename, fadetime, false);
    }

    public void ReturnSelect()
    {
        FadeManager.Instance.LoadScene("StageSelect", fadetime, false);
    }

    public void GotoNext()
    {
        int nextstage = stagenumber + 1;
        FadeManager.Instance.LoadScene("Stage_" + nextstage.ToString(), fadetime, false);
    }

    public void SetStageNumber(int now)
    {
        stagenumber = now;
    }
}
