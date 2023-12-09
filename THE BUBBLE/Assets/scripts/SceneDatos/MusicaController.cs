using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaController : MonoBehaviour
{
    public static MusicaController Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

    }

    public void ActivarAudio()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
    }

    public void DesactivarAudio()
    {
        this.gameObject.GetComponent<AudioSource>().Stop();
    }
}
