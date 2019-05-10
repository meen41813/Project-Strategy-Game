using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManage : MonoBehaviour
{
    [SerializeField]
    private Text timeDisplay;
    [SerializeField]
    private float speed = 3;

    public Text timeShow;
    private float second = 0;
    private int min, hour = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        second += (Time.deltaTime);
        if(second >= 60)
        {
            min++;
            second = 0;
        }
        if(min >= 60)
        {
            hour++;
            min = 0;
        }
        timeDisplay.text = "Time: " + hour + " : " + min+" : "+(int)second;
    }
    public void ShowTime()
    {
        timeShow.text = "Time: " + hour + " : " + min + " : " + (int)second;
    }
}
