using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using System.Linq;
using UniRx;

[RequireComponent(typeof(Collider2D))]

public class SearchLight : MonoBehaviour
{
    [SerializeField, Header("初期位置を設定できます")] private GameObject StartByPosition = null;

    private LightState lightState = LightState.Wait;

    private void Awake()
    {
        Cursor.visible = true;

        if (StartByPosition) transform.position = StartByPosition.transform.position; 

        transform.localScale *= 0.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        // マウスカーソルがライト内に入ったら始まる
        Observable.EveryUpdate()
            .Where(_=> lightState == LightState.Wait)
            .Select(_ => Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward))
            .Where(r => r && string.Equals(r.collider.gameObject.name, gameObject.name))
            .Select(s => transform.localScale * 2.0f)
            .Subscribe(s =>
                DOTween.Sequence()
                    .AppendCallback(() =>
                    {
                        Cursor.visible = false;
                        lightState = LightState.Search;
                    })
                    .Join(transform.DOScale(s, 1.0f))
                    )
            .AddTo(this)
            ;

        // サーチライトのマウス追従
        this.ObserveEveryValueChanged(p => Input.mousePosition)
            .Where(_ => lightState == LightState.Search)
            .Select(p => Camera.main.ScreenToWorldPoint(p))
            .Subscribe(p => transform.position = (Vector2)p)
            .AddTo(this)
            ;
    }

    // Update is called once per frame
    void Update()
    {
        bool onPlayerEnter = Physics2D.CircleCast(transform.position, transform.localScale.x * 0.5f * 0.99f, transform.forward, Mathf.Infinity, 1 << 8);

        foreach (var r in Physics2D.CircleCastAll(transform.position, transform.localScale.x * 0.5f * 0.99f, transform.forward, Mathf.Infinity, 1 << 10))
        {
            r.collider.gameObject.GetComponent<IReactsToLight>()?.Illuminated(onPlayerEnter);
        }
    }
}
