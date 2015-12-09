using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public static int score;
    public static int credits;
    Text text;

	// Use this for initialization
	void Awake () {
        text = GetComponent<Text>();
        score = 0;
        credits = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (text.name == "Text")
        {
            text.text = "Score: " + score;
        }
        else
        {
            text.text = "Credits: " + credits;
        }
	}
}
