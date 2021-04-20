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

    public bool onPlayerEnter { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position;

        transform.localScale = new Vector3(
            transform.localScale.x * 0.5f,
            transform.localScale.y * 0.5f,
            transform.localScale.z * 0.5f
            );

        Observable.EveryUpdate()
            .Where(_ => !isCursorFollowing)
            .Select(p => Camera.main.ScreenToWorldPoint(Input.mousePosition))
            .Select(p => p = new Vector3(p.x, p.y, 1f))
            .Where(p => string.Equals(Physics2D.Raycast(p, transform.forward).collider.gameObject.name, gameObject.name))
            .Select(p => Physics2D.Raycast(p, transform.forward))
            .Where(r => r)
            .Where(r => string.Equals(r.collider.gameObject.name, gameObject.name))
            .Subscribe(_ =>
                DOTween.Sequence()
                    .Append(transform.DOMove(p, 0.1f))
                    .AppendCallback(() => isCursorFollowing = true)
            .AddTo(this)
            ;

        this.ObserveEveryValueChanged(p => Input.mousePosition)
            .Where(_ => isCursorFollowing)
            .Select(p => Camera.main.ScreenToWorldPoint(p))
            //.Select(p => new Vector3(p.x, p.y, 1f))
            .Subscribe(p => transform.position = new Vector3(p.x, p.y, 1f))
            //.Subscribe(p => transform.DOMove(p, 0.1f))
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
