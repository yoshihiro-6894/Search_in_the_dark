using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UniRx;

public class SearchLight : MonoBehaviour
{
    [SerializeField] private float LightRadius = 3.5f;

    public bool onPlayerEnter { get; private set; }

    private Vector3 pos = Vector3.zero;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(
            pos.x,
            pos.y,
            1f
            );

        onPlayerEnter = Physics2D.CircleCast(transform.position, LightRadius * 0.5f * 0.99f, transform.forward, Mathf.Infinity, 1 << 8);

        foreach (var r in Physics2D.CircleCastAll(transform.position, LightRadius * 0.5f * 0.99f, transform.forward, Mathf.Infinity, 1 << 10))
        {
            r.collider.gameObject.GetComponent<IDarknessBehaviour>()?.LightEnter(onPlayerEnter);
        }
    }
}
