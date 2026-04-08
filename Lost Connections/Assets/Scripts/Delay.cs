using System.Collections;
using UnityEngine;

public class Delay : MonoBehaviour
{
    public void RunAfterDelay(float seconds, string eventName)
    {
        StartCoroutine(DelayThenRaise(seconds, eventName));
    }

    IEnumerator DelayThenRaise(float seconds, string eventName)
    {
        yield return new WaitForSeconds(seconds);
        GameEvent.RaiseEvent(eventName);
    }
}