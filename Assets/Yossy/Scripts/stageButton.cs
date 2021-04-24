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
        Cursor.visible = true;
    }

   

    public void AgainStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnSelect()
    {
        SceneManager.LoadScene("Pre_StageSelect");
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
