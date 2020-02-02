using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiobitch : MonoBehaviour
{
    public AudioClip intro;
    public AudioClip loop;
    private AudioSource source;

    private void Start() {
      source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      if (source.isPlaying == false)
      {
        source.clip = loop;
        source.Play();
      }
    }
}
