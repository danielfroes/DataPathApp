using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fog.Dialogue;
using UnityEngine.Events;



[System.Serializable]
public struct DialogueBatch
{  
    public Dialogue dialogue;
    public UnityEvent onDialogueStart;
    public UnityEvent onDialogueEnd;
}

public class DialogueManager : MonoBehaviour
{

    public GameObject NextButton = null;
    public GameObject WaitButton = null;
    public DialogueBatch[] dialogueArray;
    private int dialogueIndex = 0;
    

    public static DialogueManager instance;


    private void Awake() 
    {
        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(this);    
    }
    // [SerializeField] private Dialogue[] dialogueArray;
    void Start()
    {   
        DialogueHandler.instance.OnDialogueEnd += EndDialogue;
        DialogueHandler.instance.OnDialogueStart += StartDialogue;
        DialogueHandler.instance.StartDialogue(dialogueArray[dialogueIndex].dialogue);
    }    

    public void EndDialogue()
    {
        dialogueArray[dialogueIndex].onDialogueEnd.Invoke();
    }

    public void StartDialogue()
    {
        TweenControler.instance.UnhighligthAll();
        TweenControler.instance.PopDownAll();
        dialogueArray[dialogueIndex].onDialogueStart.Invoke();
    }

    public void TriggerNextDialogue()
    {
        dialogueIndex++;
        DialogueHandler.instance.StartDialogue(dialogueArray[dialogueIndex].dialogue);
        
        if(!NextButton.activeInHierarchy)
        {
            NextButton.SetActive(true);
            WaitButton.SetActive(false);
        }

    }

    public void SkipLine()
    {
        if(DialogueHandler.instance.isActive)
            DialogueHandler.instance.Skip();
        else if(dialogueIndex < dialogueArray.Length-1)
            TriggerNextDialogue();
        
    }
}
