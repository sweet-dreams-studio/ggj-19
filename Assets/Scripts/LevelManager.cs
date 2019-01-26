using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public float[] size_of_pref;

    private static GameObject[] s_prefabs;
    private static float[] s_size_of_pref;

    void Start() {
        s_prefabs = prefabs;
        s_size_of_pref = size_of_pref;
    }

    public static void SpawnNextPrefab(Vector3 prev_pos) {
        int rand = Random.Range(0, s_prefabs.Length);
        GameObject instance = Instantiate(s_prefabs[rand], new Vector3(0f, 0f, s_size_of_pref[rand]) + prev_pos, Quaternion.identity);
        instance.transform.Rotate(new Vector3(90f, 0f, 0f));
    }
}
