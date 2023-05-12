using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    [SerializeField]
    private string path;
    private string fileName;
    [SerializeField]
    [Range(1, 5)]
    private int size = 1;
    public AudioSource sound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("screenshot");
            StartCoroutine(wait5secs());
        }
    }

    IEnumerator wait5secs()
    {
        yield return new WaitForSeconds(5);
        fileName = "screenshot ";
        fileName += System.Guid.NewGuid().ToString() + ".png";
        sound.Play();
        ScreenCapture.CaptureScreenshot(path + fileName, size);
    }
}
