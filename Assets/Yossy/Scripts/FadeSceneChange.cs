using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeSceneChange : MonoBehaviour
{
    public Image sprite;
    public string toscene=null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn(1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// フェードし、真っ暗になったらシーン遷移する
    /// </summary>
    /// <param name="loadsceneName">遷移したいシーン名</param>
    /// <param name="fadetime">フェードの秒数</param>
    public void FadeLoadSceneChange(string loadsceneName,float fadetime)
    {
        StartCoroutine(SceneChange(loadsceneName, fadetime));
    }
    
    public IEnumerator SceneChange(string loadsceneName,float fadetime)
    {
        yield return StartCoroutine(FadeOut(fadetime));
        SceneManager.LoadScene(loadsceneName);
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
            sprite.color = new Color(0f, 0f, 0f,time / fadeTime);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = new Color(0f, 0f, 0f, 1f);
    }
}
