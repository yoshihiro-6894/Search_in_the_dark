using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageResultManager : MonoBehaviour
{
    public GameObject nextButton;
    // Start is called before the first frame update
    void Start()
    {
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
