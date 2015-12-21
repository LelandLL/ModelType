using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    private float adjust;
    private float hp;

    // Update is called once per frame
    void Update() { 
	try{
			hp = (float)GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().hp;
			if(hp > 0){
				adjust = (200f-hp)/10;
				GetComponent<GUITexture>().pixelInset = new Rect(-6, -32+adjust, 14, 59f * hp / 200f);
}
		}
		catch{
			GetComponent<GUITexture>().enabled = false;
		}	
	}
}
