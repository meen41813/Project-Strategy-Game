using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncDecUnitBuilding : MonoBehaviour
{
    public int amount;
    public Text display;
   
    // Start is called before the first frame update
    void Start()
    {
        amount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(amount < 0)
        {
            amount = 0;
        }
        if(amount >= 5)
        {
            amount = 5;
        }
        display.text = amount.ToString();
    }
    public void Increase()
    {
        amount++;
    }
    public void Decrease()
    {
        amount--;
    }

}
