using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleVR.Beta;

public class SceneOneController : MonoBehaviour
{

    public GameObject player;

    //Need to be able to adjust the position of the overlay
    public GameObject overlay;

    //Needed in order to set the image of the overlay
    public ImageOverlay imageOverlay;

    public GameObject visionBlocker;

    //Needed to fade user's vision for augmented to virtual transition
    public VisionBlock visionBlock;

    //The game object will be activated and deactivated as needed
    public GameObject video;

    //This controls the video playing
    public PlayVideo playVideo;

    //The audio source any audio files will be played from
    public AudioSource narratorAudio;

    //Needed to be able to switch between augmented and virtual environments
    public GvrBetaHeadset headset;

    //List containing anything that may be shown in scene
    public List<GameObject> sceneObjects;

    //List containing the names of video files for this scene
    public List<String> videoFiles;

    //List containing the names of audio files for this scene
    public List<String> audioFiles;

    //Indicates whether video should currently be playing
    private bool videoPlay;

    //Indicates whether audio should be playing
    private bool audioPlay;

    private int videoNum = 0;

    private int audioNum = 0;

    //Indicates whether the user has clicked the start button
    private bool sceneStarted = false;

    //Indicates whether the user has reached the second location
    private bool markerReached = false;

    //Indicates vision blocker is gone
    private bool blocker = false;

    private float time = 10000.0f;

    private bool faded = false;

    //The audio clip currently playing or that will play next
    private AudioClip currAudio;

    //Indicates if the overlay has been placed
    private bool placed = false;

    private bool sceneEnding = false;

    //Needed to handle controller input
    private GvrControllerInputDevice controller;

    // Start is called before the first frame update
    void Start()
    {

        videoPlay = true;
        audioPlay = false;
        currAudio = Resources.Load<AudioClip>("Audio/Section1/" + audioFiles[0]);
        controller = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);
        Reset();
        overlay.SetActive(false);
        visionBlocker.SetActive(false);
        playVideo.videoPlayer.enabled = false;
        playVideo.videoCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (playVideo.startPlaying && !playVideo.videoPlayer.isPlaying && videoPlay)
        {
            videoPlay = false;
            playVideo.videoPlayer.enabled = false;
            playVideo.videoCanvas.SetActive(false);
            videoNum++;
            if (videoNum != videoFiles.Capacity)
            {
                playVideo.fileName = videoFiles[videoNum];
            }
            audioPlay = false;
            //Debug.Log("Video hidden");
        }

        if (!videoPlay && !audioPlay && !narratorAudio.isPlaying && audioNum != audioFiles.Capacity)
        {
            narratorAudio.clip = currAudio;
            narratorAudio.Play();
            audioPlay = true;
            //Debug.Log("Playing audio");
        }

        if (audioNum == 0 && audioPlay)
        {
            overlay.SetActive(true);
        }

        if (!narratorAudio.isPlaying && audioPlay && !videoPlay)
        {
            audioPlay = false;
            audioNum++;
            //Debug.Log(audioNum);
            videoPlay = true;
            if (audioNum != audioFiles.Capacity)
            {
                //Debug.Log("Switching tracks");        
                currAudio = Resources.Load<AudioClip>("Audio/Section1/" + audioFiles[audioNum]);
            }
        }

        if (videoPlay && !audioPlay && videoNum != videoFiles.Capacity)
        {
            if (videoNum == 0 && sceneStarted)
            {
                //Debug.Log("Scene starting");
                playVideo.videoPlayer.enabled = true;
                playVideo.videoCanvas.SetActive(true);
            }
            if (videoNum == 1 && placed)
            {
                playVideo.videoPlayer.enabled = true;
                playVideo.videoCanvas.SetActive(true);
            }
            if (videoNum == 2 && markerReached && blocker)
            {
                playVideo.videoPlayer.enabled = true;
                playVideo.videoCanvas.SetActive(true);
            }
        }


        //Image disappears at correct time
        if (playVideo.videoPlayer.isPlaying && videoNum == 1 && playVideo.videoPlayer.time >= 39)
        {
            sceneObjects[1].SetActive(false);
        }


        //Make the plantation markers appear at the correct time
        if (playVideo.videoPlayer.isPlaying && videoNum == 1 && playVideo.videoPlayer.time >= 77)
        {
            sceneObjects[3].SetActive(true);
            sceneObjects[7].SetActive(true);
        }

        //Plantation markers disappear, cube showing user where to go appears
        if (!playVideo.videoPlayer.isPlaying && videoNum == 2)
        {
            sceneObjects[3].SetActive(false);
            sceneObjects[6].SetActive(true);
        }

        if (controller.GetButtonDown(GvrControllerButton.TouchPadButton))
        {
            Debug.Log("Video: " + !playVideo.videoPlayer.isPlaying + " Video num: " + (videoNum == 2) + " Faded " + !faded);
            if (!playVideo.videoPlayer.isPlaying && videoNum == 2 && !faded)
            {
                markerReached = true;
                sceneObjects[6].SetActive(false);
                visionBlocker.SetActive(true);
                //visionBlock.FadeIn();
                Debug.Log("Vision blocker fading in 1");
            }
        }

        if (markerReached && visionBlock.image.color.a == 1 && !blocker && time == 10000.0f)
        {
            //Debug.Log("setting time");
            faded = true;
            time = Time.time;
        }

        //Debug.Log("time " + time);

        //Debug.Log("Marker reached: " + (markerReached) + " Faded in: " + faded + " blocker: " + !blocker + " Time met: " + (Time.time - time >= 2.0f));

        if(markerReached && faded && !blocker && Time.time - time >= 4.0f)
        {
            GvrBetaHeadset.SetSeeThroughConfig(GvrBetaSeeThroughCameraMode.Disabled, GvrBetaSeeThroughSceneType.Virtual);
            //visionBlock.FadeOut();
            Debug.Log("Vision blocker fading out 1");
            sceneObjects[0].SetActive(false);
            sceneObjects[3].SetActive(false);
            sceneObjects[6].SetActive(false);
            sceneObjects[4].SetActive(true);
            sceneObjects[8].SetActive(true);
            blocker = true;
            visionBlocker.SetActive(false);
            //visionBlock.FadeOut();
        }

        if(playVideo.videoPlayer.isPlaying && videoNum == 2)
        {
            sceneObjects[6].SetActive(false);
        }

        if (playVideo.videoPlayer.isPlaying && videoNum == 2 && playVideo.videoPlayer.time >= 26)
        {
            sceneObjects[4].SetActive(false);
            sceneObjects[8].SetActive(false);
            sceneObjects[5].SetActive(true);
            sceneObjects[9].SetActive(true);
        }

        if (playVideo.videoPlayer.isPlaying && videoNum == 2 && playVideo.videoPlayer.time >= 38 && !sceneEnding)
        {
            Debug.Log("Vision blocker fading in 2");
            visionBlocker.SetActive(true);
            time = Time.time;
            sceneEnding = true;
        }

        if(playVideo.videoPlayer.isPlaying && videoNum == 2 && playVideo.videoPlayer.time >= 38.5f && sceneEnding)
        {
            sceneObjects[5].SetActive(false);
            sceneObjects[9].SetActive(false);
        }

        if(sceneEnding && Time.time - time >= 4.0f && visionBlocker.activeSelf)
        {
            Debug.Log("Vision blocker fading out 2");
            visionBlocker.SetActive(false);
            GvrBetaHeadset.SetSeeThroughConfig(GvrBetaSeeThroughCameraMode.RawImage, GvrBetaSeeThroughSceneType.Augmented);
        }

        /*
        if(visionBlocker.activeSelf && videoNum == 2)
        {
            visionBlocker.SetActive(false);
        }

        if(markerReached && videoNum == 2)
        {
            visionBlocker.SetActive(true);
            GvrBetaHeadset.SetSeeThroughConfig(GvrBetaSeeThroughCameraMode.Disabled, GvrBetaSeeThroughSceneType.Virtual);
        }
        */

        if (imageOverlay.anchored && !placed)
        {
            placed = true;
            overlay.transform.position = player.transform.TransformPoint(Vector3.forward * 0 + Vector3.right * 0 + Vector3.down * 2);
            sceneObjects[0].SetActive(true);
            sceneObjects[1].SetActive(true);
        }

    }

    //Brings scene to recalibration state
    public void Reset()
    {

        ChangeActive(false);
        placed = false;
        imageOverlay.AttachToCamera();

    }

    //Changes the overlay image
    public void SetImage(int imgNum)
    {
        imageOverlay.SetImage(imgNum - 1);
    }

    public void StartScene()
    {
        sceneStarted = true;
    }

    //Changes all of the objects in scene to active
    private void ChangeActive(bool active)
    {
        foreach (GameObject gameObject in sceneObjects)
        {
            gameObject.SetActive(active);
        }
    }

}
