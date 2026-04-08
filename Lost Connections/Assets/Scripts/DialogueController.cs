using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;
using System.Text;
using System.Collections.Generic;
using System.Collections;

public class DialogueController : MonoBehaviour
{
    public static Story _story { get; private set; }

    [HideInInspector] public TMP_Text _storyText;
    [HideInInspector] public Button[] _choiceButtons;
    private string _lastStoryText = "";

    public void StartDialog(TextAsset dialog)
    {
        _story = new Story(dialog.text);
        RefreshView();
    }



    void RefreshView()
    {
        StringBuilder storyText = new StringBuilder();
        while (_story.canContinue)
        {
            storyText.AppendLine(_story.Continue());
            HandleTags();
        }
        _lastStoryText = storyText.ToString();

        if (_storyText != null)           // add this null check
            _storyText.SetText(_lastStoryText);

        ShowChoiceButtons();
    }

    void ShowChoiceButtons()
    {
        for (int i = 0; i < _choiceButtons.Length; i++)
        {
            var button = _choiceButtons[i];
            button.onClick.RemoveAllListeners();
            button.gameObject.SetActive(i < _story.currentChoices.Count);
            if (i < _story.currentChoices.Count)
            {
                var choice = _story.currentChoices[i];
                button.GetComponentInChildren<TMP_Text>().SetText(choice.text);
                button.onClick.AddListener(() =>
                {
                    _story.ChooseChoiceIndex(choice.index);
                    RefreshView();
                });
            }
        }
    }

    void HandleTags()
    {
        foreach (var tag in _story.currentTags)
        {
            if (tag.StartsWith("E."))
            {
                string eventName = tag.Substring(2);

                if (eventName.StartsWith("Delay"))
                {
                    string[] parts = eventName.Split('.');
                    float delay = float.Parse(parts[0].Substring(5));
                    string delayedEvent = parts[1];
                    StartCoroutine(RaiseEventAfterDelay(delay, delayedEvent));
                }
                else
                {
                    GameEvent.RaiseEvent(eventName);
                }
            }
        }
    }

    IEnumerator RaiseEventAfterDelay(float seconds, string eventName)
    {
        yield return new WaitForSeconds(seconds);
        GameEvent.RaiseEvent(eventName);
    }

    public void RefreshToCurrentScreen()
    {
        if (_storyText == null) return;

        _storyText.SetText(_lastStoryText);
        ShowChoiceButtons();
    }
}