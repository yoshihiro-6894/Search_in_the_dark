using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanage : MonoBehaviour
{
    public static BGMmanage instance = null;

    private AudioSource[] audiosource;

    private float looptime = 138f;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audiosource[0].time >= looptime && !audiosource[1].isPlaying)
        {
            audiosource[1].Play();
        }
        if (audiosource[1].time >= looptime && !audiosource[0].isPlaying)
        {
            audiosource[0].Play();
        }
    }
}
