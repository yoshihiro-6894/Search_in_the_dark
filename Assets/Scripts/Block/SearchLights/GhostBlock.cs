using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using DG.Tweening;

[RequireComponent(typeof(Collider2D))]

public class GhostBlock : MonoBehaviour, IReactsToLight
{
    private Sequence disappearBlock;

    // Start is called before the first frame update
    void Start()
    {
        disappearBlock = DOTween.Sequence()
            .AppendInterval(0.1f)
            .AppendCallback(() => gameObject.GetComponent<Collider2D>().isTrigger = false)
            //.AppendCallback(() => Debug.Log("disappearBlock called"))
            .SetAutoKill(false)
            .Pause()
            ;
    }
    public void Illuminated(bool characterEnter)
    {
        if(characterEnter)
        {
            gameObject.GetComponent<Collider2D>().isTrigger = characterEnter;
            disappearBlock.Restart();
        }
    }
}
