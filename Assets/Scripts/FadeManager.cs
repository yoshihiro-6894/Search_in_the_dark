using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image sprite;
    public GameObject againbutton;
    public GameObject selectbutton;
    public GameObject nextbutton;
    public GameObject mouselight;

    private int stagenumber;

    private void Awake()
    {
        sprite = GetComponent<Image>();
        Blackin(1f);
    }
    public void Blackin(float fadeTime)
    {
        StartCoroutine(FadeIn(fadeTime));
    }

    public void Blackout(float fadeTime,bool trap)
    {
        StartCoroutine(FadeOut(fadeTime,trap));
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

    private IEnumerator FadeOut(float fadeTime,bool trap)
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
        mouselight.SetActive(false);
        againbutton.SetActive(true);
        selectbutton.SetActive(true);

        if (stagenumber != 10 && !trap)
            nextbutton.SetActive(true);
    }

    public void SetStagenuber(int now)
    {
        stagenumber = now;
    }
}
