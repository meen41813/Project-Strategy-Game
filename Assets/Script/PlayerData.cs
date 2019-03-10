using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public GameObject nameAccount;
    public Text welcomeText;
    public void changeData()
    {
        nameAccount = GameObject.FindGameObjectWithTag("Selected");
        Debug.Log(nameAccount);

        Debug.Log("bbb");

        if (nameAccount.tag == "Selected")
        {
            welcomeText.text = nameAccount.name;
        }
    }

    // Update is called once per frame
    
}
