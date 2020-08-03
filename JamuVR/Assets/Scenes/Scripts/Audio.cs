using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource source;
    public float newClip;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= newClip + 1)
        {
            newClipPlay();
            timer = 0;
        }
    }

    void newClipPlay()
    {
        int clipNum = Random.Range(0, clips.Length);

        if (!source.isPlaying)
        {
            source.loop = true;
            source.PlayOneShot(clips[clipNum]);
        }

        newClip = clips[clipNum].length;
    }
}
