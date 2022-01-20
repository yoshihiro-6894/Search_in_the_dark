using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageResultManager : MonoBehaviour
{
    public GameObject nextButton;
    [Header("最大ステージ数"),SerializeField]private int maxStageNumber;
    // Start is called before the first frame update
    void Start()
    {
        if (RegisterResult.STAGE_NUMBER >= maxStageNumber)
        {
            nextButton.SetActive(false);
            return;
        }
        if (RegisterResult.STAGE_CLEAR)
            nextButton.SetActive(true);
        else
            nextButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
