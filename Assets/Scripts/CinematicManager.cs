using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicManager : MonoBehaviour
{
    public static float c_time = 8f;
    public GameObject car;
    public GameObject dog;

    private bool has_rotate = false;

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > 2f && Time.timeSinceLevelLoad < 3.8f) {
            car.transform.Translate (new Vector3 (0.03f, 0.0f, 0.0f));
        }
        if(Time.timeSinceLevelLoad > 4f) {
            if (!has_rotate) {
                car.GetComponent<CarMovement>().SetSpeedX(0f);
                car.GetComponent<CarMovement>().SetSpeedY(-1f);
                has_rotate = true;
            }
            car.transform.Translate (new Vector3 (0.0f, 0.1f, 0.0f));
        }
        if(Time.timeSinceLevelLoad > 6f &&  Time.timeSinceLevelLoad < 7f) {
            dog.transform.Translate (new Vector3 (0.06f, 0.025f, 0.0f));
        }
        if(Time.timeSinceLevelLoad > 9f) {
            Destroy(car);
            Destroy(gameObject);
        }
    }
}
