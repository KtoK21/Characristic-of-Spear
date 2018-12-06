using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CanvasControl : MonoBehaviour {
    
	public void OnStartButtonClick()
    {
        SceneManager.LoadScene("ModeSelect");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnSoloButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnActionClick()
    {
        
        Debug.Log(gameObject.transform.name);
    }
    
}
