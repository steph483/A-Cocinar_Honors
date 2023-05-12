using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ObjectMemory : MonoBehaviour
{
    //public GameObject videoPlayer;
    private VideoPlayer videoPlayer;
    public GameObject screen;
    // Start is called before the first frame update
    void Start()
    {
        // videoPlayer.GetComponent<video>
        screen.SetActive(false);
        videoPlayer = screen.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject item = other.gameObject;
        //Debug.Log(item.gameObject.name);

        if (item.gameObject.name == "RightHand Controller")
        {
             Debug.Log("hand entered");
            //Get the video to show up and play
            
            StartCoroutine(PlayVideo());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject item = other.gameObject;
        //Debug.Log(item.gameObject.name);

        if (item.gameObject.name == "RightHand Controller")
        {
             Debug.Log("hand left");
            //Get the video to show up and play

            videoPlayer.Stop();
            screen.SetActive(false);
        }
    }



    IEnumerator PlayVideo()
    {
        yield return new WaitForSeconds(5);
        screen.SetActive(true);
        videoPlayer.Play();
    }
}
