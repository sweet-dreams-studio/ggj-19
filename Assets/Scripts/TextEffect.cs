using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextEffect : MonoBehaviour
{
    private string text;
    private Text UItext;

    public float delay = 2f;
    public float fadeOutTime = 2f;
    public bool leaveAfterText = false;

    // Start is called before the first frame update
    void Start()
    {
        UItext = GetComponent<Text> ();
        text = UItext.text;
        UItext.text = "";
        StartCoroutine(showNextChar());
    }

    public IEnumerator showNextChar() {
        yield return new WaitForSeconds(delay);
		foreach (char ch in text) {
			UItext.text += ch;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2f);
        Color color = UItext.color;
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime) {
            UItext.color = Color.Lerp(color, Color.clear, Mathf.Min(1, t/fadeOutTime));
            yield return null;
        }
        if(leaveAfterText) {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("ECA_menu");
        }
    }
}
