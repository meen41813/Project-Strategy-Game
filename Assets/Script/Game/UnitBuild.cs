using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitBuild : MonoBehaviour
{
    public SelectManage selectManage;
    public ResourceManage resourceManage;
    public Text DetailBuildingUnit;
    public GameObject robot;
    public int price;
    
    // Start is called before the first frame update
    void Start()
    {        

    }

    // Update is called once per frame
    void Update()
    {
        selectManage = GameObject.Find("SelectManage").GetComponent<SelectManage>();
        resourceManage = GameObject.Find("ResourceManage").GetComponent<ResourceManage>();
        if(selectManage.selected != null && selectManage.selected.tag == "Building" && robot != null)
        {
            UnitManage unitManage = robot.GetComponent<UnitManage>();
            DetailBuildingUnit.text = "Selected Robot : " + robot.name;
            if (unitManage.Type == "Worker" || unitManage.Type == "Builder")
                price = 1;
            else if (unitManage.Type == "Miner")
                price = 3;
            else if (unitManage.Type == "Melee" || unitManage.Type == "Tank" || unitManage.Type == "Glue")
                price = 5;
            else if (unitManage.Type == "Mortar" || unitManage.Type == "Repair")
                price = 10;


        }
    }
    public void BuildBT()
    {        
        IncDecUnitBuilding incDecUnitBuilding = GameObject.Find("DisplayAmount").GetComponent<IncDecUnitBuilding>();
        if(selectManage.selected != null && robot != null && selectManage.selected.tag =="Building" && selectManage.selected.GetComponent<BuildingData>().Name == "Factory")
        {
            Vector3 pos = selectManage.selected.transform.position;
            //Debug.Log(selectManage.selected.name);
            if (resourceManage.gold >= (incDecUnitBuilding.amount * price))
            {
                for (int i = 0; i < incDecUnitBuilding.amount; i++)
                {
                    pos = Random.insideUnitSphere * 1;
                    Instantiate(robot, pos + selectManage.selected.transform.position, robot.transform.rotation);
                }
                resourceManage.gold -= (incDecUnitBuilding.amount * price);
            }
            else
                return;
        }

    }
}
