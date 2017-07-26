using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
		Debug.Log ("Level load requested for: "+name);
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
		// Application.LoadLevel(name);
	}
	public void QuitLevel()
    {
		Debug.Log ("Quit game request received");
	}

    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        print("Load next level request");
        // SceneManager.LoadSceneAsync(++activeSceneBuildIndex);
        // Application.LoadLevel(Application.loadedLevel + 1);
        // SceneManager.LoadScene("Win");

    }
    public void BrickDestroyed()
    {
        // if last brick destroyed
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
