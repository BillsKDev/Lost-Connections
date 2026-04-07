using System;
using UnityEngine;

public class DialogueGiver : MonoBehaviour
{
    [SerializeField] TextAsset _dialog;

    private void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        FindFirstObjectByType<DialogueController>().StartDialog(_dialog);
    }
    
    
}