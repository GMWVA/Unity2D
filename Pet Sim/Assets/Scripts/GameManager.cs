﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject happinessText;
    public GameObject hungerText;

    public GameObject namePanel;
    public GameObject nameInput;
    public GameObject nameText;

    public GameObject robot;
    public GameObject robotPanel;
    public GameObject[] robotList;

    public GameObject homePanel;
    public Sprite[] homeTileSprites;
    public GameObject[] homeTiles;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("looks"))
            PlayerPrefs.SetInt("looks", 0);
        CreateRobot(PlayerPrefs.GetInt("looks"));

        if (!PlayerPrefs.HasKey("tiles"))
            PlayerPrefs.SetInt("tiles", 0);
        ChangeTiles(PlayerPrefs.GetInt("tiles"));
    }

    void Update ()
    {
        happinessText.GetComponent<Text>().text = "" + robot.GetComponent<Robot>().Happiness;
        hungerText.GetComponent<Text>().text = "" + robot.GetComponent<Robot>().Hunger;
        nameText.GetComponent<Text>().text = robot.GetComponent<Robot>().Name;
    }

    public void TriggerNamePanel(bool b)
    {
        namePanel.SetActive(!namePanel.activeInHierarchy);

        if(b)
        {
            robot.GetComponent<Robot>().Name = nameInput.GetComponent<InputField>().text;
            PlayerPrefs.SetString("Name", robot.GetComponent<Robot>().Name);
        }
    }

    public void ButtonBehavior(int i)
    {
        switch(i)
        {
            case (0):
            default:
                robotPanel.SetActive(!robotPanel.activeInHierarchy);
                break;
            case (1):
                homePanel.SetActive(!homePanel.activeInHierarchy);
                break;
            case (2):

                break;
            case (3):

                break;
            case (4):
                robot.GetComponent<Robot>().SaveRobot();
                Application.Quit();
                break;
        }
    }

    public void CreateRobot(int i)
    {
        if (robot)
            Destroy(robot);
        robot = Instantiate(robotList[i], Vector3.zero, Quaternion.identity) as GameObject;

        if (robotPanel.activeInHierarchy)
            robotPanel.SetActive(false);
        PlayerPrefs.SetInt("looks", i);
    }

    public void ChangeTiles(int t)
    {
        for (int i = 0; i < homeTiles.Length; i++)
            homeTiles[i].GetComponent<SpriteRenderer>().sprite = homeTileSprites[t];

        if (homePanel.activeInHierarchy)
            homePanel.SetActive(false);
        PlayerPrefs.SetInt("tiles", t);
    }
}