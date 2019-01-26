﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Image mask;

    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
        StartCoroutine(slowDown());
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > CinematicManager.c_time) {    
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");
            if(moveHorizontal != 0 && moveVertical != 0) {
                moveHorizontal = .717f * moveHorizontal;
                moveVertical = .717f * moveVertical;
            }

            Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

            if (speed > .045f)
                transform.Translate (movement * speed);
            else {
                transform.Translate (new Vector3(0f, -.05f, 0f));
                Destroy(GetComponent<Rigidbody>());
            }
        }
    }

    public IEnumerator slowDown() {
        Color color = mask.color;
        yield return new WaitForSeconds(6f);
        anim.SetBool("stop", false);
        while (speed > 0.03f) {
            yield return new WaitForSeconds(3f);
            speed -= 0.018f;
            color.a += 0.01f;
            mask.color = color;
            anim.SetFloat("speed", speed);
        }
        while (color.a < 1) {
            color.a += 0.005f;
            mask.color = color;
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene("ECA_gameover");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Respawn") {
            Destroy(other.gameObject, 20f);
            Destroy(other);
            LevelManager.SpawnNextPrefab(other.gameObject.transform.position, other.gameObject.GetComponent<Scroller>().speed);
        }
        if(other.gameObject.tag == "Finish") {
            SceneManager.LoadScene("ECA_gameover");
        }
    }
}
