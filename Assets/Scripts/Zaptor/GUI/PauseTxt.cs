﻿using UnityEngine;
using System.Collections;

public class PauseTxt : MonoBehaviour {
    // Use this for initialization
    void Start()
    {
        GetComponent<GUIText>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.gamePaused)
            GetComponent<GUIText>().enabled = true;
        else
            GetComponent<GUIText>().enabled = false;

    }

    void OnMouseEnter()
    {
        // change color on mouse over
        GetComponent<GUIText>().color = Color.green;
        GetComponent<AudioSource>().Play();
    }

    void OnMouseExit()
    {
        // change color back to white
        GetComponent<GUIText>().color = Color.white;
    }

    void OnMouseDown()
    {
        Pause.gamePaused = false;
        if (this.name == "TXTRestart")
        {
            Application.LoadLevel("game");

            // restart the music
            Audio.TogglePause(false);
        }
        if (this.name == "TXTResume")
        {
            Audio.TogglePause(Pause.gamePaused);
        }
        if (this.name == "TXTMainMenu")
            Application.LoadLevel("menu");
    }
}
