using UnityEngine;
using System.Collections;

public class ExplanationGUI : MonoBehaviour {

	// Return to Main Menu
	public void ReturntoMenu ()
    {
        Application.LoadLevel("Main Menu");
	}

    //Class Ship Explainations
    public void Explainations()
    {
        Application.LoadLevel("Instructions");
    }
}
