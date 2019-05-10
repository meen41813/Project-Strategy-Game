using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageProfile : MonoBehaviour
{
    public InputField name;
    public GameObject account;
    public GameObject panel;
    public GameObject nameBtn;

    public Text AccountText;


    public void createProfile()
    {
        string text = name.text;
        GameObject newAccount = Instantiate(account, panel.transform);
        newAccount.name = name.text;
        nameBtn = GameObject.Find("AccountNameBtn");
        nameBtn.name = name.text;
        nameBtn.GetComponentInChildren<Text>().text = text;
        //Save system jane.bin
        
    }
}

