﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float speed;

    void Start() {
        StartCoroutine(slowScroller());
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > CinematicManager.c_time) {
            Vector3 movement = new Vector3 (0.0f, 0.0f, -1f);

            transform.Translate (movement * speed * Time.deltaTime * 60);
        }
    }

    public IEnumerator slowScroller() {
        while (speed > 0.015f) {
            speed -= 0.0015f;
            yield return new WaitForSeconds(3f);
        }
    }
}
