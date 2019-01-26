using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

        transform.Translate (movement * speed);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Respawn") {
            Destroy(other.gameObject, 20f);
            Destroy(other);
            LevelManager.SpawnNextPrefab(other.gameObject.transform.position);
        }
        if(other.gameObject.tag == "Finish") {
            Debug.Log("T ES MORT !");
        }
    }
}
