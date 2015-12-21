using UnityEngine;
using System.Collections;

public class MainManagerGUI : MonoBehaviour {

    public void ArcadeGame()
    {
        Application.LoadLevel("Gameplay");
    }
    public void Cloudless()
    {
        Application.LoadLevel("Cloudless");
    }
    public void Raptor()
    {
        Application.LoadLevel("Zaptor");
    }
    public void Explanation()
    {
        Application.LoadLevel("Instructions");
    }
    public void ForTesting()
    {
        Application.LoadLevel("Testers");
    }
    public void Credits()
    {
        Application.LoadLevel("Credits");
    }
    public void ExitGame()
    {
        Application.LoadLevel("Intro");
    }
}
