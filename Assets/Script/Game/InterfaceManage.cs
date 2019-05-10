using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManage : MonoBehaviour
{
    public Text name;
    public Text status;
    public Text type;
    public static bool pauseState = false;
    public SpawnManage spawnManage;
    public Button DestroyBT;
    public GameObject PauseScreen;

    private void Start()
    {
        pauseState = false;       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
            PauseScreen.gameObject.SetActive(true);
        }
        //ShowData();
        if (pauseState == false)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }
    public void ShowData()
    {      
        spawnManage = GameObject.Find("Spawn").GetComponent<SpawnManage>();
        SelectManage mouseSelect = GameObject.Find("SelectManage").GetComponent<SelectManage>();
        if (mouseSelect.selected != null)
        {
            if (mouseSelect.selected.tag == "Unit")
            {
                if (spawnManage.buildOn == false)
                {
                    UnitManage unit = mouseSelect.selected.GetComponent<UnitManage>();
                    name.text = "Name: " + unit.Name;
                    if (unit.damage == 0f)
                    {
                        type.text = "General";
                        type.color = Color.green;
                        status.text = "HP: " + unit.currentHP + "/" + unit.maxHP + "  Dig Attack: " + unit.digDamage + "  Speed: " + unit.attackSpeed;
                    }
                    else
                    {
                        type.text = "Attack";
                        type.color = Color.red;
                        status.text = "HP: " + unit.currentHP + "/" + unit.maxHP + "  Attack: " + unit.damage + "  Speed: " + unit.attackSpeed;
                    }
                    name.gameObject.SetActive(true);
                    type.gameObject.SetActive(true);
                    status.gameObject.SetActive(true);
                    DestroyBT.gameObject.SetActive(false);
                }
            }
            else if (mouseSelect.selected.tag == "Building")
            {
                if (spawnManage.buildOn == false)
                {
                    BuildingData building = mouseSelect.selected.GetComponent<BuildingData>();
                    name.text = "Name: " + building.Name;
                    status.text = "HP: " + building.HP + "/" + building.MaxHP;
                    name.gameObject.SetActive(true);
                    type.gameObject.SetActive(false);
                    status.gameObject.SetActive(true);
                    DestroyBT.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            HideData();
        }
    }

    public void HideData()
    {
        name.gameObject.SetActive(false);
        status.gameObject.SetActive(false);
        type.gameObject.SetActive(false);
        DestroyBT.gameObject.SetActive(false);
    }

    public void pauseGame()
    {    
        pauseState = true;  
    }

    public void resumeGame()
    {   
        pauseState = false;    
    }

    public void DestroyBuilding()
    {       
        SelectManage mouseSelect = GameObject.Find("SelectManage").GetComponent<SelectManage>();
        if (mouseSelect.selected.CompareTag("Building"))
        {
            //Debug.Log(mouseSelect.selected);
            mouseSelect.selected.GetComponent<BuildingData>().DestoryBT();
            Destroy(mouseSelect.selected);
            HideData();
        }
    }
}
