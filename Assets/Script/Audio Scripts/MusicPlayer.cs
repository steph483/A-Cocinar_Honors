using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    
    public AudioSource cienAnos;
    public AudioSource oye;
    public AudioSource NCNST;

    public float timer;
    public float timer2;
    private string playing;
    void Start()
    {
        timer = cienAnos.clip.length;
        playing = "cien anos";
        cienAnos.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (playing == "cien anos")
            {
                playing = "oye";
                timer2 = oye.clip.length;
                oye.Play();
            }
       

        }
        if (timer2 <= 0)
        {
           if (playing == "oye")
            {
                playing = "NCNST";
                timer = NCNST.clip.length;
                NCNST.Play();
            }
        }
        //if (timer <= 0) Destroy(gameObject);
    }
}
