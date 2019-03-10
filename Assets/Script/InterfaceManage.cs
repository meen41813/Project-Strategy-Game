using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManage : MonoBehaviour
{
    public Text HP;
    public Text name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraManage mouseSelect = GameObject.Find("Main Camera").GetComponent<CameraManage>();
        if(mouseSelect.selected != null)
        {
            UnitManage unit = mouseSelect.selected.GetComponent<UnitManage>();
            name.text = "Name: " + unit.name;
            HP.text = "HP: " + unit.currentHP + "/" + unit.maxHP;

        }
       
       

        

    }
}
