using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

     Object[] myMusic = new Object[3]; // declare this as Object array
    AudioSource audio;


    void Awake()
    {
        myMusic = Resources.LoadAll("Music", typeof(AudioClip));
        audio.clip = myMusic[0] as AudioClip;
    }

    void Start()
    {
        audio.Play();
        Debug.Log(audio.name);

    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
            playRandomMusic();
    }

    void playRandomMusic()
    {
        audio.clip = myMusic[Random.Range(0, myMusic.Length)] as AudioClip;
        audio.Play();
    }
}
