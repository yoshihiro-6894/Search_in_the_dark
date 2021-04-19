using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UniRx;

public class SearchLight : MonoBehaviour
{
    [SerializeField] private float LightRadius = 3.5f;

    private Subject<bool> onLighted= new Subject<bool>();

    public IObservable<bool> OnLighted => onLighted;


    public enum PlayerState {  Enter, Exit, Stay }

    private Vector3 pos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (transform.position != pos)
        {
            transform.position = new Vector3(
                pos.x,
                pos.y,
                1f
                );

            Physics2D.CircleCastAll(transform.position, LightRadius * 0.5f, transform.forward);

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        
    }

}
