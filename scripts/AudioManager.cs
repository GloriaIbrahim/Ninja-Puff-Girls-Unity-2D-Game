using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
    public AudioSource background, effects;
    static public AudioManager instance;
    // Use this for initialization
    void Start () {
	
	}
    void awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(instance.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public void playSingle(AudioClip c)
    {
        effects.clip = c;
        effects.Play();
    }

    public void randomize(params AudioClip[] c)
    {
        int index = Random.Range(0, c.Length);
        effects.clip = c[index];
        effects.Play();
    }
    // Update is called once per frame
    void Update () {
	
	}
}
