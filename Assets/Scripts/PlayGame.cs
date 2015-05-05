using UnityEngine;
using System.Collections;

public class PlayGame : MonoBehaviour 
{	
	public void LoadScene () 
    {
        Time.timeScale = 0;
		Application.LoadLevel("scene_0");
	}
}
