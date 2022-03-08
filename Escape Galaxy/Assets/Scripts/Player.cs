using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player: MonoBehaviour {

  public int health;
  public float fuel;
  public float fuelDecrement;
  public Text healthDisplay;
  public Text lowFuelText;
  public Text fuelDisplay;
  public int playerIndex;
  public GameObject controlGuide;

  private Shake shake;
  private bool movingLeft;
  private bool firstInput;
  private float boost;
  private bool stopBoost;
  private float sideBoost;

  private float playerSpeed = 2.05f;

  // text modification 
  private int newFontSize = 90;
  private int fontSize = 77;
  private float textTime = 0;
  private bool startTimer = false;

  private bool deleteThis;

  private float startTime, endTime;

  // Start is called before the first frame update
  void Start() {
    movingLeft = true;
    firstInput = false;
    stopBoost = false;
    boost = 3f; // defualt = 4
    sideBoost = 1.35f;
    shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent < Shake > ();

    // Setup asteroid spawner
    PlayerPrefs.SetInt("AsteroidCount", 0);
    
    PlayerPrefs.SetInt("DisableDoubleButton", 0);

    PlayerPrefs.SetInt("FuelSpawn", 0);

    if (PlayerPrefs.GetInt("SelectedPlayer") != playerIndex) {
      Destroy(gameObject, 0);
    }

    if (PlayerPrefs.GetInt("SelectedPlayer") == 2 || PlayerPrefs.GetInt("SelectedPlayer") == 7) {
      sideBoost = 1.5f;
    }

    if (PlayerPrefs.GetInt("SelectedPlayer") == 6) {
      sideBoost = 1.5f;
    }

    if (PlayerPrefs.GetInt("SelectedPlayer") == 3 || PlayerPrefs.GetInt("SelectedPlayer") == 6){
      fuelDecrement = 0.04f;
    }

  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player Position")) {
      stopBoost = true;
      Destroy(controlGuide, 0);
    }
  }

  void ChangeFuelColour(bool increment) {
    if (increment) {
      fuelDisplay.color = Color.green;
    } else {
      fuelDisplay.color = Color.red;
    }
    fuelDisplay.fontSize = newFontSize;
    fuelDisplay.fontStyle = FontStyle.Bold;
  }

  void ResetUIText() {
    fuelDisplay.color = Color.white;
    fuelDisplay.fontSize = fontSize;
    fuelDisplay.fontStyle = FontStyle.Normal;
  }

  // Update is called once per frame
  void Update() {
    healthDisplay.text = health.ToString();
    fuelDisplay.text = Math.Round(fuel).ToString();

    if (fuel >= 15.0f) {
      lowFuelText.text = "";
    } else {
      lowFuelText.text = "LOW FUEL";
    }

    if (PlayerPrefs.GetInt("FuelSpawn") == 1) {
      ChangeFuelColour(true);
      startTimer = true;
      PlayerPrefs.SetInt("FuelSpawn", 0);
    } else if (PlayerPrefs.GetInt("FuelSpawn") == 2) {
      ChangeFuelColour(false);
      startTimer = true;
      PlayerPrefs.SetInt("FuelSpawn", 0);
    }

    if (startTimer) {
      textTime += 0.05f;
    }

    if (textTime > 3.0f) {
      textTime = 0;
      ResetUIText();
      startTimer = false;
    }

    fuel -= fuelDecrement;

    // defaul -> transform.position.y < 2
    if (!stopBoost) {
      //shake.CamShake();
      transform.Translate(Vector2.up * Time.deltaTime * boost);
    }

    if (health < 0 || fuel <= 0) {
      if (health < 0) {
        PlayerPrefs.SetString("GameOverCause", "health");
      }
      if (fuel <= 0) {
        PlayerPrefs.SetString("GameOverCause", "fuel");
      }
      SceneManager.LoadScene("GameOver");
    }

    if (Input.GetMouseButtonDown(0)) {
      firstInput = true;
      movingLeft = !movingLeft;
      startTime = Time.time;
    }

    if (Input.GetMouseButtonUp(0)) {
      startTime = 0;
    }

    if (stopBoost) {
        if (firstInput) {
          if (movingLeft && startTime > 1f) {
            transform.Translate(Vector2.left * Time.deltaTime * playerSpeed * sideBoost);
          } else if (!movingLeft && startTime > 1f) {
            transform.Translate(Vector2.right * Time.deltaTime * playerSpeed * sideBoost);
          } else if (movingLeft) {
            transform.Translate(Vector2.left * Time.deltaTime * playerSpeed);
          } else if (!movingLeft) {
            transform.Translate(Vector2.right * Time.deltaTime * playerSpeed);
          }
      }
    }
  }
}