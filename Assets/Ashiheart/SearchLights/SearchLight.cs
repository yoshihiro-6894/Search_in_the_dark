using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using System.Linq;
using UniRx;

public class SearchLight : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private bool isCursorFollowing = false;

    private float CursorSize;

    public bool onPlayerEnter { get; private set; }

    private void Awake()
    {
        Cursor.visible = true;

        transform.position = transform.Find("../Character").position;

        CursorSize = transform.localScale.x;

        transform.localScale = Vector2.one * CursorSize;
    }

    // Start is called before the first frame update
    void Start()
    {
        // マウスカーソルがライト内に入ったら始まる
        Observable.EveryUpdate()
            .Where(_ => !isCursorFollowing)
            .Select(p => (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition))
            .Select(p => Physics2D.Raycast(p, transform.forward))
            .Where(r => r && string.Equals(r.collider.gameObject.name, gameObject.name))
            .Subscribe(_ =>
                DOTween.Sequence()
                    .AppendCallback(() => Cursor.visible = false)
                    .AppendCallback(() => isCursorFollowing = true)
                    .Join(transform.DOScale(CursorSize, 0.1f))
                    )
            .AddTo(this)
            ;

        // サーチライトのマウス追従
        this.ObserveEveryValueChanged(p => Input.mousePosition)
            .Where(_ => isCursorFollowing)
            .Select(p => (Vector2)Camera.main.ScreenToWorldPoint(p))
            .Subscribe(p => transform.position = p)
            .AddTo(this)
            ;
    }

    // Update is called once per frame
    void Update()
    {
        onPlayerEnter = Physics2D.CircleCast(transform.position, transform.localScale.x * 0.5f * 0.99f, transform.forward, Mathf.Infinity, 1 << 8);

        foreach (var r in Physics2D.CircleCastAll(transform.position, transform.localScale.x * 0.5f * 0.99f, transform.forward, Mathf.Infinity, 1 << 10))
        {
            r.collider.gameObject.GetComponent<IDarknessBehaviour>()?.LightEnter(onPlayerEnter);
        }
    }
}
