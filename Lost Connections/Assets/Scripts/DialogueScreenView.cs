using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScreenView : MonoBehaviour
{
    [SerializeField] TMP_Text _storyText;
    [SerializeField] Button[] _choiceButtons;

    void OnEnable()
    {
        var controller = FindFirstObjectByType<DialogueController>();
        controller._storyText = _storyText;
        controller._choiceButtons = _choiceButtons;

        // Only repaint if the story is already running
        if (DialogueController._story != null)
            controller.RefreshToCurrentScreen();
    }
}