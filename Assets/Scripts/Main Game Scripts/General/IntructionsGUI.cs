using UnityEngine;
using System.Collections;

public class IntructionsGUI : MonoBehaviour {

	//For Main Menu
    public void ReturntoMainMenu()
        {
        Application.LoadLevel("Main Menu");
        }
    //Class Ship Explainations
    public void Explainations()
    {
        Application.LoadLevel("Class Explainations");
    }

}
