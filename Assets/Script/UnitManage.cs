using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitManage : MonoBehaviour
{
    public Button attacked;


    public Text nameText;
    public Text HPText;


    public int maxHP;
    public int currentHP;
    [SerializeField]
    private int Attack;
    [SerializeField]
    private int Defend;
    [SerializeField]
    private string Type;

    public GameObject selected;

    // Start is called before the first frame update
    void Start()
    {  
        if (Type == "DPS")
        {
            maxHP = 200;
        }
        else if (Type == "Tank")
        {
            maxHP = 400;
        }
        else if (Type == "Healer")
        {
            maxHP = 150;
        }
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Attacked()
    {              
        currentHP -= 10;
    }
}
