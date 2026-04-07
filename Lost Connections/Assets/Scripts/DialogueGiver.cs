using System;
using UnityEngine;

public class DialogueGiver : MonoBehaviour
{
    [SerializeField] TextAsset _dialog;

    private void Start()
    {
    }

    public void StartDialogue()
    {
        FindFirstObjectByType<DialogueController>().StartDialog(_dialog);
    }
    
    
}