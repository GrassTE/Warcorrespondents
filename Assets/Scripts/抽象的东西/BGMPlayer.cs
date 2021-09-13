using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioPlayer;
    private bool isSlowlyStopTheClip;
    [Tooltip("请填入BGM切换时淡出原BGM的速度")]
    public float fadeSpeed;
    private AudioClip newBGM;
    private float defulatVolume;

    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioPlayer = GetComponent<AudioSource>();
        defulatVolume = audioPlayer.volume;
        if(FindObjectsOfType<BGMPlayer>().Length > 1) Destroy(gameObject); 
    }

    // Update is called once per frame
    void Update()
    {
        if(isSlowlyStopTheClip)
        {
            audioPlayer.volume -= fadeSpeed*Time.deltaTime;
            if(audioPlayer.volume.Equals(0f))
            {
                isSlowlyStopTheClip = false;
                audioPlayer.clip = newBGM;
                audioPlayer.volume = defulatVolume;
                audioPlayer.Play();
            }
        }
    }

    public void ChangedTheBGM(AudioClip newBGM)
    {
        isSlowlyStopTheClip = true;
        this.newBGM = newBGM;
    }
}
