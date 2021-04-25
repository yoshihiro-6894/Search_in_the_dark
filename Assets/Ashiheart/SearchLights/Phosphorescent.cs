using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Phosphorescent : MonoBehaviour, IReactsToLight
{
    private Sequence LightBlock;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        LightBlock = DOTween.Sequence()
            .Append(spriteRenderer.DOFade(0, 1.5f))
            .AppendCallback(() => spriteRenderer.sortingOrder = 0)
            .Join(spriteRenderer.DOFade(1f, 0f))
            .SetAutoKill(false)
            .Pause()
            ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Illuminated(bool characterEnter)
    {
        spriteRenderer.sortingOrder = 2;

        LightBlock.Restart();

    }
}
