using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip goblin1;
    public AudioClip goblin2;
    public AudioClip goblin3;
    private AudioClip[] goblinSounds;
    public AudioClip victory;
    public AudioClip death;
    private AudioSource goblinSource;

    // Start is called before the first frame update
    void Start()
    {
        goblinSource = GameObject.Find("Goblin").GetComponent<AudioSource>();
        goblinSounds = new AudioClip[] { goblin1, goblin2, goblin3 };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRandomGoblinSound()
    {
        int index = UnityEngine.Random.Range(0, goblinSounds.Length);
        goblinSource.PlayOneShot(goblinSounds[index]);
        Debug.Log("Played sound number" + index);
    }
}
