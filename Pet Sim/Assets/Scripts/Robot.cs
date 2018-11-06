using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Robot : MonoBehaviour {

    [SerializeField]
    private int _hunger;
    [SerializeField]
    private int _happiness;

    private bool _serverTime;
    private int _clickCount;

	void Start () {
        PlayerPrefs.SetString("then", "10/05/2018 12:54:00");
        UpdateStatus();
	}

    private void Update()
    {
        GetComponent<Animator>().SetBool("jump", gameObject.transform.position.y > -2.9f);

        if(Input.GetMouseButtonUp(0))
        {
            Vector2 v = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(v), Vector2.zero);
            if(hit)
            {
                if(hit.transform.gameObject.tag == "robot")
                {
                    _clickCount++;
                    if(_clickCount >= 3)
                    {
                        _clickCount = 0;
                        UpdateHappiness(1);
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000000));
                    }
                }
            }
        }
    }

    void UpdateStatus()
    {
        if (!PlayerPrefs.HasKey("_hunger"))
        {
            _hunger = 100;
            PlayerPrefs.SetInt("_hunger", _hunger);
        } else
        {
            _hunger = PlayerPrefs.GetInt("_hunger");
        }

        if(!PlayerPrefs.HasKey("_happiness"))
        {
            _happiness = 100;
            PlayerPrefs.SetInt("_happiness", _happiness);
        } else
        {
            _happiness = PlayerPrefs.GetInt("_happiness");
        }

        if (!PlayerPrefs.HasKey("then"))
            PlayerPrefs.SetString("then", GetStringTime());

        TimeSpan ts = GetTimeSpan();

        _hunger -= (int)(ts.TotalHours * 2);
        if (_hunger < 0)
            _hunger = 0;
        _happiness -= (int)((100 - _hunger) * (ts.TotalHours / 5));
        if (_happiness < 0)
            _happiness = 0;

        //Debug.Log(GetTimeSpan().ToString());
        //Debug.Log(GetTimeSpan().TotalHours);

        if(_serverTime)
            UpdateServer();
        else
            InvokeRepeating("UpdateDevice", 0f, 30f);
    }

    void UpdateServer()
    {

    }

    void UpdateDevice()
    {
        PlayerPrefs.SetString("then", GetStringTime());
    }

    TimeSpan GetTimeSpan()
    {
        if (_serverTime)
            return new TimeSpan();
        else
            return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
    }

    string GetStringTime()
    {
        DateTime now = DateTime.Now;
        return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }

    public int Hunger
    {
        get { return _hunger; }
        set { _hunger = value; }
    }

    public int Happiness
    {
        get { return _happiness; }
        set { _happiness = value;  }
    }

    public void UpdateHappiness(int i)
    {
        Happiness += i;
        if (Happiness > 100)
            Happiness = 100;
    }

}
