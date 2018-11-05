using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject happinessText;
    public GameObject hungerText;

    public GameObject robot;

	void Update () {
        happinessText.GetComponent<Text>().text = "" + robot.GetComponent<Robot>().Happiness;
        hungerText.GetComponent<Text>().text = "" + robot.GetComponent<Robot>().Hunger;
    }
}
