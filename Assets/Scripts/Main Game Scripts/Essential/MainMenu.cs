using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    public void ArcadeMode()
    {
        Application.LoadLevel("Gameplay");
    }
    // Unable at this time- public void SwarmMode() { }
    // Unable at this time- public void Options() { }
    // Unable at this time-  public void Scoreboard() { }
    // Unable at this time-  public void Instructions() { }
    public void QuitGame()
    {
        Application.LoadLevel("Title");
    }

}
