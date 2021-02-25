using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    [SerializeField] GameObject[] MEP;
    [SerializeField] public Slider slider;
    [SerializeField] float moveSpeed;
    private int mentalEnergy;

    // Cached Elements
    LevelLoader levelLoader;

    void Start() {
        levelLoader = FindObjectOfType<LevelLoader>();
        mentalEnergy = MEP.Length - 1;
        slider.value = 0;
    }

    void Update() {
        Move();

    }

    private void Move() {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = transform.position.x + deltaX;
        var newYPos = transform.position.y + deltaY;

        transform.position = new Vector2(newXPos, newYPos);
    }

    public void AddProgress() {
        if (slider.value < 5) {
            slider.value++;
        }
    }

    public void RaiseMentalEnergy(int pRaiseAmount) {
        int tmp = mentalEnergy + pRaiseAmount;
        Debug.Log("Raised TMP: " + tmp);

        if (tmp <= MEP.Length && mentalEnergy < MEP.Length) {
            for (int i = 0; i < pRaiseAmount; i++) {
                RaiseMEHelper();
            }

        } else {
            Debug.Log("Invalid pRaiseAmount value");
        }
    }

    private void RaiseMEHelper() {
        if (mentalEnergy >= 0 && mentalEnergy < MEP.Length) {
            MEP[mentalEnergy].SetActive(true);
            mentalEnergy++;
            Debug.Log("Raised mentalEnergy: " + mentalEnergy);
        }
    }

    public void LowerMentalEnergy(int pLowerAmount) {
        int tmp = mentalEnergy - pLowerAmount;
        Debug.Log("Lowered TMP: " + tmp);

        if (tmp >= 0 && mentalEnergy >= 0) {
            for (int i = pLowerAmount; i > 0; i--) {
                LowerMEHelper();
			}

        } else {
            Debug.Log("Invalid pLowerAmount value");
        }
    }

    private void LowerMEHelper() {
        if (mentalEnergy >= 0 && mentalEnergy < MEP.Length) {
            Debug.Log("Mental Energy: " + mentalEnergy);
            MEP[mentalEnergy].SetActive(false);
            mentalEnergy--;
            Debug.Log("Lowered mentalEnergy: " + mentalEnergy);
        }
    }

    public int GetMentalEnergy() {
        return mentalEnergy + 1;
    }

    public float GetProgress() {
        return slider.value;
    }

    public float GetTotalProgress() {
        return slider.maxValue;
    }
}
