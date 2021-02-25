using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    [SerializeField] float delayInSeconds = 2f;

    public void LoadStartScene() {
        SceneManager.LoadScene(0);
    }

    public void LoadGame() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameOver() {
        // StartCoroutine(WaitToLoadGameOver());
        Time.timeScale = 0.1f;
        SceneManager.LoadScene(2);
    }

    IEnumerator WaitToLoadGameOver() {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(2);
    }


    public void LoadWinScreen() {
        SceneManager.LoadScene(3);
    }

    public void Quit() {
        Application.Quit();
    }
}
