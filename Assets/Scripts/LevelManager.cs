using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private static int remainingBricks;

	public void Start() {
		remainingBricks = 0;
	}

	public void looseLevel() {
        SceneManager.LoadScene("Loose");
    }

    public void backToMenu() {
        SceneManager.LoadScene(0);
    }

    public void nextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void quit() {
        Application.Quit();
    }

	public void brickCreated() {
		remainingBricks++;
	}

	public void brickDestroyed() {
		remainingBricks--;
		if (remainingBricks == 0) {
			nextLevel();
		}
	}
}
