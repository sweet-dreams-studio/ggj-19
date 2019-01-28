using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed_x;
    public float speed_y;

    private Animator anim;
    private GameObject player;

    private static float now = 0f;
    private float cooldown;

    void Start() {
        anim = GetComponent<Animator>();
        if (speed_x != 0) anim.SetInteger("direction", 2);
        if (speed_y < 0) anim.SetInteger("direction", 0);
        if (speed_y > 0) anim.SetInteger("direction", 1);
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        cooldown = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > CinematicManager.c_time) {
            Vector3 movement = new Vector3 (speed_x, -speed_y, 0.0f);

            transform.Translate (movement * Time.deltaTime * 60);
        }
        if ((Time.timeSinceLevelLoad - now > cooldown) && (Vector3.Distance(transform.position, player.transform.position) < 10f)) {
            SoundManager.Vroum();
            now = Time.timeSinceLevelLoad;
        }
    }

    public void SetSpeedX(float x) {
        speed_x = x;
        if (x != 0) anim.SetInteger("direction", 2);
    }

    public void SetSpeedY(float y) {
        speed_y = y;
        if (y < 0) anim.SetInteger("direction", 0);
        if (y > 0) anim.SetInteger("direction", 1);
    }
}
