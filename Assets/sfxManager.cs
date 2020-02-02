using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxManager : MonoBehaviour
{
    public AudioSource handExtension;
    public AudioSource handContraction;
    public AudioSource itemGet;
    public AudioSource dig;

    public List<AudioClip> extensionClips;
    public List<AudioClip> contractionClips;
    public AudioClip itemClip;
    public List<AudioClip> digSounds;

    bool handPlaying;
    bool extended;


    // Start is called before the first frame update
    void Start()
    {
        handPlaying = false;
        extended = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Extend()
    {
        extended = true;
        handPlaying = true;
        int clipRand = Random.Range(0, extensionClips.Count);
        float pitchRand = Random.Range(0.9f, 1.1f);
        handExtension.pitch = pitchRand;
        handExtension.PlayOneShot(extensionClips[clipRand]);
        yield return new WaitForSeconds(0.25f);
        handPlaying = false;
    }
    public IEnumerator Contract()
    {
        extended = false;
        handPlaying = true;
        int clipRand = Random.Range(0, contractionClips.Count);
        float pitchRand = Random.Range(0.9f, 1.1f);
        handContraction.pitch = pitchRand;
        handContraction.PlayOneShot(contractionClips[clipRand]);
        yield return new WaitForSeconds(0.25f);
        handPlaying = false;

    }

    public void MoveSound(bool moveBool)
    {
        if (moveBool && !handPlaying)
        {
            if (!extended)
            {
                StartCoroutine(Extend());
            } else if (extended)
            {
                StartCoroutine(Contract());
            }
        }
        if (!moveBool)
        {
            StopAllCoroutines();
            extended = false;
            handPlaying = false;
        }
    }
    public void digSound()
    {

    }
    public void itemGetSound()
    {

    }

}
