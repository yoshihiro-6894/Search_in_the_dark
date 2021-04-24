using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image sprite;

    private void Awake()
    {
        sprite = GetComponent<Image>();
        Blackin(1f);
    }
    public void Blackin(float fadeTime)
    {
        StartCoroutine(FadeIn(fadeTime));
    }

    public void Blackout(float fadeTime)
    {
        StartCoroutine(FadeOut(fadeTime));
    }


    private IEnumerator FadeIn(float fadeTime)
    {
        float time = 0f;
        sprite.color = new Color(0f, 0f, 0f, 1f);
        while (time < fadeTime)
        {
            sprite.color = new Color(0f, 0f, 0f, 1f - time / fadeTime);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = new Color(0f, 0f, 0f, 0f);
    }

    private IEnumerator FadeOut(float fadeTime)
    {
        float time = 0f;
        sprite.color = new Color(0f, 0f, 0f, 0f);
        while (time < fadeTime)
        {
            sprite.color = new Color(0f, 0f, 0f, time / fadeTime);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = new Color(0f, 0f, 0f, 1f);
    }
}
