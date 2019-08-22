using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneThreeController : MonoBehaviour
{

    public GameObject overlay;

    public GameObject player;

    public GameObject book;

    public ImageOverlay imageOverlay;

    public List<GameObject> sceneObjects;

    public AudioSource narratorAudio;

    public List<String> audioFiles;

    public List<PlayVideo> videos;

    private bool sceneStarted;

    private bool placed;

    private bool audioPlay;

    private bool videoPlay;

    private int audioNum;

    private int videoNum;

    // Start is called before the first frame update
    void Start()
    {

        overlay.SetActive(false);
        sceneStarted = false;
        placed = false;
        audioPlay = false;
        videoPlay = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(sceneStarted && audioNum == 0 && !narratorAudio.isPlaying && !audioPlay)
        {
            audioPlay = true;
            overlay.SetActive(true);
            narratorAudio.clip = Resources.Load<AudioClip>("Audio/Section1/" + audioFiles[0]);
            narratorAudio.Play();
        }

        if (imageOverlay.anchored && !placed)
        {
            placed = true;
            overlay.transform.position = player.transform.TransformPoint(Vector3.forward * 0 + Vector3.right * 0 + Vector3.down * 2);
        }

        if (audioNum == 0 && !narratorAudio.isPlaying && audioPlay && placed)
        {
            audioPlay = true;
            sceneObjects[0].SetActive(true);
            narratorAudio.clip = Resources.Load<AudioClip>("Audio/Section3/" + audioFiles[1]);
            narratorAudio.Play();
            audioNum++;
        }

        if(audioNum == 1 && narratorAudio.time >= 6.28f)
        {
            sceneObjects[1].SetActive(true);
        }

        if (audioNum == 1 && narratorAudio.time >= 12.19f)
        {
            sceneObjects[1].GetComponent<FloatMove>().SetDestination(book.transform.position + ((book.transform.right * -0.15f) + (book.transform.up * 0.092f) + (book.transform.forward * 0.075f)), 
                Quaternion.Euler(book.transform.rotation.x+69, book.transform.rotation.y, book.transform.rotation.z), 0.5f);
            sceneObjects[1].GetComponent<SizeTransform>().SetDestination(new Vector2(0.125f, 0.125f), 0.5f);
        }

        if (audioNum == 1 && narratorAudio.time >= 17.54f)
        {
            sceneObjects[2].SetActive(true);
        }

        if (audioNum == 1 && narratorAudio.time >= 24.26f)
        {
            sceneObjects[2].GetComponent<FloatMove>().SetDestination(book.transform.position + new Vector3(-0.15f, 0.03f, -0.08f), 
                Quaternion.Euler(book.transform.rotation.x+69, book.transform.rotation.y, book.transform.rotation.z), 0.5f);
            sceneObjects[2].GetComponent<SizeTransform>().SetDestination(new Vector2(0.125f, 0.125f), 0.5f);
        }

        if (audioNum == 1 && narratorAudio.time >= 28.26f)
        {
            sceneObjects[3].SetActive(true);
            sceneObjects[4].SetActive(true);
        }

        if (audioNum == 1 && narratorAudio.time >= 28.26f)
        {
            sceneObjects[3].SetActive(true);
            sceneObjects[4].SetActive(true);
        }

        if(audioNum == 1 && narratorAudio.time >= 34.5)
        {
            sceneObjects[4].SetActive(false);
        }

        if (audioNum == 1 && narratorAudio.time >= 39.62)
        {
            sceneObjects[5].SetActive(true);
        }

        if (audioNum == 1 && narratorAudio.time >= 40.45)
        {
            sceneObjects[6].SetActive(true);
        }

        if (audioNum == 1 && narratorAudio.time >= 42.76)
        {
            sceneObjects[7].SetActive(true);
        }

        if (audioNum == 1 && narratorAudio.time >= 44.37)
        {
            sceneObjects[5].SetActive(false);
            sceneObjects[6].SetActive(false);
            sceneObjects[7].SetActive(false);
        }

        if (audioNum == 1 && narratorAudio.time >= 45.62)
        {
            sceneObjects[8].SetActive(true);
        }

        if (audioNum == 1 && narratorAudio.time >= 46.92)
        {
            sceneObjects[9].SetActive(true);
        }

        if (audioNum == 1 && narratorAudio.time >= 48.11)
        {
            sceneObjects[8].SetActive(false);
            sceneObjects[9].SetActive(false);
        }

        if (audioNum == 1 && narratorAudio.time >= 49.22)
        {
            sceneObjects[10].SetActive(true);
        }

        if (audioNum == 1 && narratorAudio.time >= 57.16)
        {
            sceneObjects[10].SetActive(false);
        }

        if (audioNum == 1 && narratorAudio.time >= 69.20f)
        {
            sceneObjects[3].GetComponent<FloatMove>().SetDestination(book.transform.position + new Vector3(0.15f, 0.06f, -0.02f), 
                Quaternion.Euler(book.transform.rotation.x+69, book.transform.rotation.y, book.transform.rotation.z), 0.5f);
            sceneObjects[3].GetComponent<SizeTransform>().SetDestination(new Vector2(0.1851435f, 0.3f), 0.5f);
        }

        if(!narratorAudio.isPlaying && audioPlay && audioNum == 1)
        {
            audioPlay = false;
            videoPlay = true;
        }

        if(videoPlay && videoNum == 0 && !audioPlay)
        {
            videos[0].videoPlayer.enabled = true;
            videoPlay = false;
            videoNum++;
            sceneObjects[1].SetActive(false);
            sceneObjects[2].SetActive(false);
            sceneObjects[3].SetActive(false);
        }

        if(!videoPlay && videoNum == 1 && !videos[0].videoPlayer.isPlaying && videos[0].startPlaying)
        {
            videos[0].videoPlayer.enabled = false;
            audioPlay = true;
            audioNum++;
        }

        if (audioNum == 2 && audioPlay && !narratorAudio.isPlaying)
        {
            narratorAudio.clip = Resources.Load<AudioClip>("Audio/Section3/" + audioFiles[2]);
            narratorAudio.time = 0;
            narratorAudio.Play();
        }

        if(audioNum == 2 && narratorAudio.time >= 33.36)
        {
            sceneObjects[11].SetActive(true);
        }

        if (audioNum == 2 && narratorAudio.time >= 36.77)
        {
            sceneObjects[11].GetComponent<FloatMove>().SetDestination(book.transform.position + new Vector3(-0.15f, 0.06f, -0.02f), 
                Quaternion.Euler(book.transform.rotation.x+69, book.transform.rotation.y, book.transform.rotation.z), 0.5f);
            sceneObjects[11].GetComponent<SizeTransform>().SetDestination(new Vector2(0.20649f, 0.25f), 0.5f);
        }

        if (audioNum == 2 && narratorAudio.time >= 37.65)
        {
            sceneObjects[12].SetActive(true);
            sceneObjects[13].SetActive(true);
            audioNum++;
        }

        if (audioNum == 3 && audioPlay && !narratorAudio.isPlaying)
        {
            sceneObjects[12].GetComponent<FloatMove>().SetDestination(book.transform.position + new Vector3(0.15f, 0.06f, -0.02f), 
                Quaternion.Euler(book.transform.rotation.x+69, book.transform.rotation.y, book.transform.rotation.z), 1.0f);
            sceneObjects[12].GetComponent<SizeTransform>().SetDestination(new Vector2(0.08866f, 0.2f), 1.0f);
            sceneObjects[13].SetActive(false);
            narratorAudio.clip = Resources.Load<AudioClip>("Audio/Section3/" + audioFiles[3]);
            narratorAudio.Play();
            audioNum++;
        }

        if (audioNum == 4 && audioPlay && !narratorAudio.isPlaying)
        {
            narratorAudio.clip = Resources.Load<AudioClip>("Audio/Section3/" + audioFiles[4]);
            narratorAudio.Play();
            audioPlay = false;
        }

        if (!narratorAudio.isPlaying && !audioPlay && audioNum == 4)
        {
            videoPlay = true;
        }

        if (videoPlay && videoNum == 1 && !audioPlay)
        {
            videos[1].videoPlayer.enabled = true;
            videoNum++;
        }

        if (videoPlay && videoNum != 9 && !videos[videoNum-1].videoPlayer.isPlaying && videos[videoNum-1].startPlaying)
        {
            SnippetPlayer(videoNum);
        }
        
        if (videoPlay && videoNum == 9 && !videos[8].videoPlayer.isPlaying && videos[8].startPlaying)
        {
            videos[8].videoPlayer.enabled = false;
            sceneObjects[0].GetComponent<Scrapbook>().enabled = true;
        }

    }

    public void StartScene()
    {
        sceneStarted = true;
    }

    

    private void SnippetPlayer(int video)
    {
        videos[video-1].videoPlayer.enabled = false;
        videos[video-1].videoCanvas.SetActive(false);
        videoNum++;
        videos[video].videoPlayer.enabled = true;
        videos[video].videoCanvas.SetActive(true);
    }

}
