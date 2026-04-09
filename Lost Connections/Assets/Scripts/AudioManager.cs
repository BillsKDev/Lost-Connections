using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundEntry
    {
        public string label;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume = 1f;
        [Range(0.1f, 3f)]
        public float pitch = 1f;
        public bool loop = false;
        [HideInInspector]
        public AudioSource source;
    }

    public SoundEntry[] sounds;

    void Awake()
    {
        foreach (SoundEntry s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void PlaySound(string label)
    {
        SoundEntry s = System.Array.Find(sounds, x => x.label == label);

        if (s == null)
        {
            Debug.LogWarning($"AudioManager: no sound labelled '{label}'");
            return;
        }

        s.source.Play();
    }
}