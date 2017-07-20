using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    //private int activeSceneBuildIndex;

    //void Start()
    //{
    //    Initialise();
    //}

    //private void Initialise()
    //{
    //    Scene activeScene = SceneManager.GetActiveScene();

    //    activeSceneBuildIndex = activeScene.buildIndex;
    //}

    public void LoadLevel(string name)
    {
		Debug.Log ("Level load requested for: "+name);
		Application.LoadLevel(name);
	}
	public void QuitLevel()
    {
		Debug.Log ("Quit game request received");
	}

    public void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        print("Load next level request");
        // SceneManager.LoadSceneAsync(++activeSceneBuildIndex);
        // Application.LoadLevel(Application.loadedLevel + 1);
        // SceneManager.LoadScene("Win");

    }
}
