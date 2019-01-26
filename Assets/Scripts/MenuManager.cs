using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.Select();
    }

    public void ToGame() {
        SceneManager.LoadScene("ECA_Game");
    }

    public void Leave() {
        Debug.Log("bye");
		Application.Quit();
    }
}
