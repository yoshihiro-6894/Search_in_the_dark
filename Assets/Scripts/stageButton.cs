using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageButton : MonoBehaviour
{
    private int stagenumber;

    // Start is called before the first frame update
    void Start()
    {
        SetStageNumber(RegisterResult.STAGE_NUMBER);
        Cursor.visible = true;
    }

   

    public void AgainStage()
    {
        SceneManager.LoadScene("Stage_" + stagenumber.ToString());
    }

    public void ReturnSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void GotoNext()
    {
        int nextstage = stagenumber + 1;
        SceneManager.LoadScene("Stage_" + nextstage.ToString());
    }

    public void SetStageNumber(int now)
    {
        stagenumber = now;
    }
}
