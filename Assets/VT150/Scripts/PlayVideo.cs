using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using UnityEngine.Video;


public class PlayVideo : MonoBehaviour, IActivatable
{

    public VideoPlayer videoPlayer;

    public GameObject videoCanvas;

    public string fileName;

    public bool startPlaying = false;

    private bool started = false;
    
    private VideoSource videoSource;

    public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;
    }

    private void Update()
    {
        if(videoPlayer.enabled && !started)
        {
            started = true;
            OnActive();
        }
    }

    public void OnActive()
    {
        StartCoroutine(playVideo());
    }

    IEnumerator playVideo()
    {

        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;
        audioSource.Pause();

        //We want to play from video clip not from url

        //videoPlayer.source = VideoSource.VideoClip;

        // Vide clip from Url
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = Application.streamingAssetsPath + "/" + fileName;

        //Debug.Log(videoPlayer.url);

        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        //Assign the Audio from Video to AudioSource to be played
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        //Set video To Play then prepare Audio to prevent Buffering
        //videoPlayer.clip = videoToPlay;
        videoPlayer.Prepare();

        //Wait until video is prepared
        WaitForSeconds waitTime = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            //Debug.Log("Preparing Video");
            //Prepare/Wait for 5 sceonds only
            yield return waitTime;
            //Break out of the while loop after 5 seconds wait
            break;
        }

        //Debug.Log("Done Preparing Video");

        //Assign the Texture from Video to RawImage to be displayed
       // image.texture = videoPlayer.texture;
       
        

        //Play Video
        videoPlayer.Play();

        //Play Sound
        audioSource.Play();

        startPlaying = true;

        videoCanvas.SetActive(true);
        //Debug.Log("Playing Video");
        while (videoPlayer.isPlaying)
        {
            //Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
            yield return null;
        }
        started = false;
        startPlaying = false;
        //Debug.Log("startPlaying = " + startPlaying);
        videoPlayer.Stop();
        videoCanvas.SetActive(false);
        //Debug.Log("Done Playing Video");
    }

}