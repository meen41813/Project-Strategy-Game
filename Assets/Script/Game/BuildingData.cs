using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingData : MonoBehaviour
{
    public string Name;
    public string Rank;
    public bool IsBlue;
    public int price;
    public int MaxHP;
    public int HP;

    public Image HPBar;
    // Start is called before the first frame update
    void Start()
    {       
        if (Name == "Lander")
            MaxHP = 2000;
        else if (Name == "Warehouse")
            MaxHP = 500;
        else
            MaxHP = 1000;
        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void takeDamage(int damage)
    {
        HP -= damage;
        HPBar.fillAmount = (float)HP / MaxHP;
        if(HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void DestoryBT()
    {
        ResourceManage resourceManage = GameObject.Find("ResourceManage").GetComponent<ResourceManage>();
        resourceManage.gold += this.gameObject.GetComponent<BuildingData>().price;
        GameObject.Find("Canvas").GetComponent<InterfaceManage>().HideData();

        if (this.gameObject.GetComponent<BuildingData>().Name == "Builder Bay")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().haveBuilderBay = false;
        }
        if (this.gameObject.GetComponent<BuildingData>().Name == "Armory")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().haveArmory = false;

        }
        if (this.gameObject.GetComponent<BuildingData>().Name == "Frontier Lab")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().haveFrontierLab = false;

        }
        if (this.gameObject.GetComponent<BuildingData>().Name == "Refinery")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().haveRefinery = false;

        }
        if (this.gameObject.GetComponent<BuildingData>().Name == "Warehouse")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().warehouseNum--;
        }
        //Destroy(this.gameObject);

    }
}
