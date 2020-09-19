using UnityEngine.Audio;
using System; //Allows us to use Array.ETC... 
using UnityEngine;

public class audioManager : MonoBehaviour
{

    [Header("Audio Manager")]
    //Set public and the Array name of the AUDIO SCRIPT so if script is named hi, use hi[]
    public sound01[] sounds;

    //Setup Proccess
    //Go into specific script that will play the audio source and use line...
    //FindObjectOfType<AudioManager>().Play("PlayerDeath");
    //AudioManager References this script while playerdeath references the audio clip created

    //With duplication check of AudioManager explained below...
    public static audioManager instance;

    void Awake()
    {
        //Checks if theres a duplicate of AudioManager before starting another
        if(instance == null)
        {
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
        //Won't destroy when loading into next scene
        DontDestroyOnLoad(gameObject);

        //Setup for Audio Sources
        foreach(sound01 s in sounds)
        {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
        }
    }

    //Plays the background theme song when started
    void Start()
    {
        Play("Theme");
    }

    //Plays specific audio source from sound01 script
    public void Play(string name)
    {
        sound01 s = Array.Find(sounds, sounds => sounds.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

}
