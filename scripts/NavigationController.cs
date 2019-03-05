using UnityEngine;
using System.Collections;

public class NavigationController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    public void GoToIntroScene()
    {
        Destroy(FindObjectOfType<gameManager>());
        Application.LoadLevel(0);
    }
    public void GoToThreatenScene()
    {
        Application.LoadLevel(1);
    }
    public void GoToScene1Level1()
    {
        Application.LoadLevel(2);
    }
    public void GoToScene2Level1()
    {
        Application.LoadLevel(3);
    }
    public void GoToThreaten2Scene()
    {
        Application.LoadLevel(4);
    }
    public void GoToScene1Level2()
    {
        Application.LoadLevel(5);
    }
    public void GoToScene2Level2()
    {
        Application.LoadLevel(6);
    }
    public void GoToThreaten3Scene()
    {
        Application.LoadLevel(7);
    }
    public void GoToScene1Level3()
    {
        Application.LoadLevel(8);
    }
    public void GoToScene2Level3()
    {
        Application.LoadLevel(9);
    }
    public void GoToGameOverScene()
    {
        Application.LoadLevel(10);
    }
    public void GoToVictoryScene()
    {
        Application.LoadLevel(11);
    }
    public void GoToHowToPlayScene()
    {
        Application.LoadLevel(12);
    }
    public void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
