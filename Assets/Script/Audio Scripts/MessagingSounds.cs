using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagingSounds : MonoBehaviour
{
    public AudioSource recieveMessage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayMessageRecieve()
    {
        recieveMessage.Play();
    }
}
