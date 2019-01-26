using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3 (0.0f, -1f, 0.0f);

        transform.Translate (movement * speed);
    }
}
