using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed_x;
    public float speed_y;

    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
        if (speed_x != 0) anim.SetInteger("direction", 2);
        if (speed_y < 0) anim.SetInteger("direction", 0);
        if (speed_y > 0) anim.SetInteger("direction", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > CinematicManager.c_time) {
            Vector3 movement = new Vector3 (speed_x, -speed_y, 0.0f);

            transform.Translate (movement);
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
