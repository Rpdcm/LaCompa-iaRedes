using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour {

    public Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public GameObject image1;
    private int cont = -1;
    public GameObject w1t1;
    public GameObject w1t2y3;
    public GameObject w1t4;
    public GameObject w1t5;
    public GameObject w2t1;
    public GameObject w2t2;
    public GameObject w2t3y4;

    // Use this for initialization
    void Start () {
        sentences = new Queue<string>();
	}


    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        cont++;
        ImageCounter();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }


    void EndDialogue()
    {
        SceneManager.LoadScene(2);
    }

    void ImageCounter()
    {
        if (cont == 4)
        {
            image1.SetActive(true);
        }
        if (cont == 5)
        {
            image1.SetActive(false);
        }
        if(cont == 7)
        {
            w1t1.SetActive(true);
        }
        if(cont == 8)
        {
            w1t1.SetActive(false);
            w1t2y3.SetActive(true);
        }
        if(cont == 9)
        {
            w1t2y3.SetActive(false);
            w1t4.SetActive(true);
        }
        if(cont == 10)
        {
            w1t4.SetActive(false);
            w1t5.SetActive(true);
        }
        if(cont == 12)
        {
            w1t5.SetActive(false);
            w2t1.SetActive(true);
        }
        if(cont == 13)
        {
            w2t1.SetActive(false);
            w2t2.SetActive(true);
        }
        if(cont == 14)
        {
            w2t2.SetActive(false);
            w2t3y4.SetActive(true);
        }
        if(cont == 16)
        {
            w2t3y4.SetActive(false);
        }

    }
}
