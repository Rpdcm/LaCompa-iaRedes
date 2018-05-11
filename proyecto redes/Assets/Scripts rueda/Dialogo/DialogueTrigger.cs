using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    private bool start = false;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (!start)
        {
            if (Input.anyKey)
            {
                TriggerDialogue();
                start = true;
                
            }
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
    }
}
