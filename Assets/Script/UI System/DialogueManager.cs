using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //public Text nameText;
    public TMP_Text dialogueText;
    private Queue<string> sentences;
    //private Queue<AudioSource> v_Audios;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        //v_Audios = new Queue<AudioSource>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversionation with " + dialogue.name);

        //nameText.text = dialogue.name;

        //Clear out because it is playing from the start
        sentences.Clear();
        //v_Audios.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        /*foreach (AudioSource audio in dialogue.voiceOver)
        {
            //v_Audios.Enqueue(audio);
        }*/

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

        /*AudioSource audio = v_Audios.Dequeue();
        audio.Play();*/
    }

    public void playNextMessage()
    {
        //play message sound
        DisplayNextSentence();
    }

    void EndDialogue()
    {
        Debug.Log("end of convo");
    }


}
