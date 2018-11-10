using System.Collections;
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

    private void Start()
    {
        CreateRobot(0);      
    }

    void Update () {
        happinessText.GetComponent<Text>().text = "" + robot.GetComponent<Robot>().Happiness;
        hungerText.GetComponent<Text>().text = "" + robot.GetComponent<Robot>().Hunger;
        nameText.GetComponent<Text>().text = robot.GetComponent<Robot>().Name;

        if (Input.GetKeyUp(KeyCode.Space))
            CreateRobot(1);
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

                break;
            case (1):

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

    void CreateRobot(int i)
    {
        if (robot)
            Destroy(robot);
        robot = Instantiate(robotList[i], Vector3.zero, Quaternion.identity) as GameObject;
    }

}
