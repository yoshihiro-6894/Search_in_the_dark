﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

[RequireComponent(typeof(Collider2D))]

public class DarknessBehaviour : MonoBehaviour, IDarknessBehaviour
{
    public bool onLighted { get; set; }

    public void LightEnter(bool characterEnter)
    {
        gameObject.GetComponent<Collider2D>().isTrigger = characterEnter;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Where(c => string.Equals(c.gameObject.name, "Character"))
            .Subscribe(c => gameObject.GetComponent<Collider2D>().isTrigger = false)
            .AddTo(this)
            ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
