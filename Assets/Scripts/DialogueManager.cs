using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fog.Dialogue;
using UnityEngine.Events;



[System.Serializable]
public struct DialogueBatch
{
    public Dialogue dialogue;
    public UnityEvent onDialogueEnd;
}

public class DialogueManager : MonoBehaviour
{

    [SerializeField] private GameObject NextButton = null;
    [SerializeField] private GameObject WaitButton = null;
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

        DialogueHandler.instance.StartDialogue(dialogueArray[dialogueIndex].dialogue);
        DialogueHandler.instance.OnDialogueEnd += EndDialogue;
    }

    public void EndDialogue()
    {
            dialogueArray[dialogueIndex].onDialogueEnd.Invoke();


        
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
        else
            TriggerNextDialogue();
        
    }
}
