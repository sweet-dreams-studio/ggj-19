using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    void Update()
    {
        float action = Input.GetAxis ("Submit");
        if (action < 0) Leave();
        if (action > 0) ToGame();
    }

    public void ToGame() {
        SceneManager.LoadScene("ECA_Game");
    }

    public void Leave() {
        Debug.Log("bye");
		Application.Quit();
    }
}
