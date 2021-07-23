using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using DG.Tweening;

public class MoveBlock : MonoBehaviour
{
    private Sequence slideBlock;

    // Start is called before the first frame update
    void Start()
    {

        slideBlock = DOTween.Sequence()
            .Append(this.GetComponent<Rigidbody2D>().DOMoveX(5f,3f))
            .SetLink(this.gameObject)
            .SetAutoKill(false)
            .Pause()
            ;

        this.OnCollisionEnter2DAsObservable()
            .Do(x=>Debug.Log(x.gameObject.name))
            .Where(c => c.gameObject.name == "Character")
            .Subscribe(c => c.gameObject.transform.parent = transform)
            ;

        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V)&& !slideBlock.IsPlaying())
            slideBlock.Restart();
    }
}
