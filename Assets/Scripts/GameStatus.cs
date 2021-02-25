using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {
    [SerializeField] Character Character1;
    [SerializeField] Character Character2;

    [SerializeField] double dailyTimer = 300f;

    private bool timerRunning;

    // Cached Elements
    LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start() {
        levelLoader = FindObjectOfType<LevelLoader>();
        timerRunning = true;
    }

    // Update is called once per frame
    void Update() {
        UpdateTimer();

        MentalEnergyLoseCondition();
        ProgressLoseCondition();
        ProgressWinCondition();

    }

    public void UpdateTimer() {
        if (timerRunning) {
            if (dailyTimer > 0) {
                dailyTimer -= Time.deltaTime;
            } else {
                dailyTimer = 0;
                Debug.Log("Timer has run out");
                timerRunning = false;
            }
        }
    }

    private void MentalEnergyLoseCondition() {
        if (Character1.GetMentalEnergy() < 1 || Character2.GetMentalEnergy() < 1) {
            levelLoader.LoadGameOver();
        }
    }

    private void ProgressLoseCondition() {
        if (dailyTimer <= 0 || timerRunning == false &&
            (Character1.GetProgress() > Character1.GetTotalProgress() ||
            Character2.GetProgress() > Character2.GetTotalProgress())) {

            levelLoader.LoadGameOver();
        }
    }

    private void ProgressWinCondition() {
        float tmp = Character1.GetProgress() + Character2.GetProgress();

        if (tmp >= (Character1.GetTotalProgress() + Character1.GetTotalProgress())) {
            levelLoader.LoadWinScreen();
        }
    }
}
