using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour        
{
    int max = 1000;
    int min = 1;
    int guess = 500;

    // Use this for initialization
    void Start ()
    {


        Debug.Log("Welcome to Number Wizard!");
        Debug.Log("Please Pick A Number");
        Debug.Log("The Highest Number You Can Pick Is: " + max);
        Debug.Log("The Lowest Number You Can Pick Is: " + min);
        Debug.Log("Tell Me If Your Number is Higher or Lower than ");
        Debug.Log("Up = Higher, Down = Lower, Enter = Correct");

        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Higher");
            min = guess;
        }      
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Lower");
            max = guess;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Got It!");
        }
    }
}
