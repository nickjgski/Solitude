using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    public ImageOverlay imageOverlay;
    public GameObject overlay;
    public bool hideObjects;
    public List<GameObject> sceneObjects;
    public List<String> audioFiles;
    

    private AudioClip currAudio;

    private AudioSource narratorAudio;

    private bool placed = false;
    
    private GvrControllerInputDevice controller;

    // Start is called before the first frame update
    void Start()
    {
        
        narratorAudio = GetComponent<AudioSource>();
        currAudio = Resources.Load<AudioClip>("Audio/Section1/Intro");
        controller = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);
        if (hideObjects)
        {
            Reset();
        } else
        {
            placed = true;
            ChangeActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (imageOverlay.anchored && !placed)
        {
            placed = true;
            overlay.transform.SetPositionAndRotation(new Vector3(overlay.transform.position.x,
                     overlay.transform.position.y - 2, overlay.transform.position.z - 1.58f), Quaternion.identity);
            ChangeActive(true);
            
        }
        
    }

    public void Reset()
    {

        ChangeActive(false);
        placed = false;
        imageOverlay.AttachToCamera();

    }

    public void SetImage(int imgNum)
    {
        imageOverlay.SetImage(imgNum - 1);
    }

    private void ChangeActive(bool active)
    {
        foreach (GameObject gameObject in sceneObjects)
        {
            gameObject.SetActive(active);
        }
    }

}
