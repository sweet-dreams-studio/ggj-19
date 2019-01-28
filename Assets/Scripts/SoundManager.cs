using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bass;
    public AudioSource bass2;
    public AudioSource tint;

    public AudioClip bassClip;
    public AudioClip[] tintClip;

    public AudioSource vroum;
    public static AudioSource svroum;
    public AudioClip[] vroumClip;
    public static AudioClip[] svroumClip;

    public AudioSource woof;
    public AudioClip[] woofClip;

    // Start is called before the first frame update
    void Start()
    {
        bass.clip = bassClip;
        bass2.clip = bassClip;
        tint.volume = .5f;
        bass.volume = .5f;
        bass2.volume = .5f;
        bass.Play();
        StartCoroutine(loopBass());
        StartCoroutine(randomizeTint());
        StartCoroutine(randomizeWoof());

        svroum = vroum;
        svroumClip = vroumClip;
    }

    public IEnumerator loopBass() {
        yield return new WaitForSeconds(7f);
        bass2.Play();    
    }

    public IEnumerator randomizeTint() {
        while(true) {
            float random = Random.Range(7f, 15f);
            yield return new WaitForSeconds(random);
            int rand = Random.Range(0, tintClip.Length);
            tint.clip = tintClip[rand];
            tint.Play();
        }
    }

    public IEnumerator randomizeWoof() {
        while(true) {
            float random = Random.Range(0f, 20f);
            yield return new WaitForSeconds(random);
            int rand = Random.Range(0, woofClip.Length);
            woof.clip = woofClip[rand];
            woof.Play();
        }
    }

    public static void Vroum() {
        svroum.volume = .3f;
        svroum.clip = svroumClip[Random.Range(0, svroumClip.Length)];
        svroum.Play();
    }
}
