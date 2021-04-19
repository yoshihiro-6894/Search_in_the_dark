﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using DG.Tweening;

[RequireComponent(typeof(Collider2D))]

public class GhostBlock : MonoBehaviour, IDarknessBehaviour
{
    public bool onLighted { get; set; }

    public void LightEnter(bool characterEnter)
    {
        gameObject.GetComponent<Collider2D>().isTrigger = characterEnter;
    }

    void Awake()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
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
