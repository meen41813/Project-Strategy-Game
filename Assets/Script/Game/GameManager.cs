using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool haveBuilderBay = false;
    public bool haveRefinery = false;
    public bool haveWarehouse = false; //can duplicate
    public int warehouseNum = 0;
    public bool haveArmory = false;
    public bool haveFrontierLab = false;
    public bool haveLander = false;
    public List<GameObject> BuildBT;
    public List<GameObject> UnitBT;

    public GameObject missionComplete;

    public int mission1 = 0;
    public int mission2 = 0;
    public bool ms1Comp = false;
    public bool ms2Comp = false;
    public Text MS1;
    public Text MS2;


    void Update()
    {
        if (mission1 >= 3)
        {
            MS1.color = Color.green;
            ms1Comp = true;
        }
        if (mission2 >= 3)
        {
            MS2.color = Color.green;
            ms2Comp = true;
        }
        if(ms1Comp && ms2Comp)
        {
            GameObject.Find("Canvas").GetComponent<InterfaceManage>().pauseGame();
            missionComplete.gameObject.SetActive(true);
            GameObject.Find("TimeManage").GetComponent<TimeManage>().ShowTime();
        }
        MS1.text = "- Dig Gold Resource "+mission1+"/3";
        MS2.text = "- Eliminate Enemy " + mission2 + "/3";

        if (haveBuilderBay)
        {
            BuildBT[2].SetActive(true);
            BuildBT[4].SetActive(true);
            BuildBT[5].SetActive(true);
            BuildBT[6].SetActive(true);

            UnitBT[1].SetActive(true);
        }
        else
        {
            BuildBT[2].SetActive(false);
            BuildBT[4].SetActive(false);
            BuildBT[5].SetActive(false);
            BuildBT[6].SetActive(false);

            UnitBT[1].SetActive(false);
        }

        if (haveRefinery)
        {
            UnitBT[2].SetActive(true);
            //unlock MinerBot BT
        }
        else
        {
            UnitBT[2].SetActive(false);
        }

        if (haveArmory)
        {
            UnitBT[3].SetActive(true);
            UnitBT[4].SetActive(true);
            UnitBT[5].SetActive(true);            
        }
        else
        {
            UnitBT[3].SetActive(false);
            UnitBT[4].SetActive(false);
            UnitBT[5].SetActive(false);
        }

        if (haveFrontierLab)
        {
            UnitBT[6].SetActive(true);
            UnitBT[7].SetActive(true);         
        }
        else
        {
            UnitBT[6].SetActive(false);
            UnitBT[7].SetActive(false);
        }
    }
    public void BacktoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
