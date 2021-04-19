using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

[RequireComponent(typeof(Collider2D))]

public class DarknessBehaviour : MonoBehaviour, IDarknessBehaviour
{
    [SerializeField] SearchLight searchlight;

    private bool searchLightEnter;

    private bool characterEnter;


    public void Highlighted()
    {

    }

    public void DisHighlighted()
    {
    }

    public void Highlighting()
    {
    }

    void Awake()
   {
    }

    // Start is called before the first frame update
    void Start()
    {

        /*
        Observable.Zip(searchlight.OnTriggerStay2DAsObservable(), searchlight.OnTriggerStay2DAsObservable())
            .Where(_ => _[0].gameObject.name == "Character" && _[1].gameObject.name == "Character")
            */
        
    }

    // Update is called once per frame
    void Update()
    {
        if (searchLightEnter && characterEnter && !gameObject.GetComponent<Collider2D>().isTrigger)
        {

        }
        
    }

    public void OnCollisionEnter(Collider other)
    {
        /*
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        if (string.Equals(other.gameObject.name, "Character"))
        {
            CharacterAndLightEnter.Chara
        }
        else if (string.Equals(other.gameObject.name, "SearchLight"))
        {


        }
        */
    }

    public void OnTriggerExit(Collider other)
    {
        /*
        if (string.Equals(other.gameObject.name, "Character"))
        {
            gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
        */
    }
}
