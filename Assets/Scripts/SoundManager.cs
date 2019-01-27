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
    public AudioClip vroumClip;

    // Start is called before the first frame update
    void Start()
    {
        bass.clip = bassClip;
        bass2.clip = bassClip;
        vroum.clip = vroumClip;
        tint.volume = .5f;
        bass.volume = .5f;
        bass2.volume = .5f;
        bass.Play();
        StartCoroutine(loopBass());
        StartCoroutine(randomizeTint());

        svroum = vroum;
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

    public static void Vroum() {
        svroum.volume = 1f;
        svroum.Play();
    }
}
