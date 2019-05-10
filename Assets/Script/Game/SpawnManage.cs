using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;
public class SpawnManage : MonoBehaviour
{
    //public GameObject buildBT;
    public GameObject select;
    public GameObject Building;
    public GameObject Resorce;
    private BuildingPlacement buildingPlacement;

    public bool buildOn = false;

    void Start()
    {
        

    }

    void Update()
    {
        ResourceManage resource = Resorce.GetComponent<ResourceManage>();
        SelectManage sel = select.GetComponent<SelectManage>();
        if(buildOn == false)
        {
            GameObject.Find("Canvas").GetComponent<InterfaceManage>().ShowData();
        }
        else
            GameObject.Find("Canvas").GetComponent<InterfaceManage>().HideData();


        if (Building != null)
        {
            buildingPlacement = GameObject.Find("Main Camera Game").GetComponent<BuildingPlacement>();
            BuildingData buildingData = Building.GetComponent<BuildingData>();
            NavMeshObstacle obstacle = Building.GetComponent<NavMeshObstacle>();
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            if (Input.GetMouseButtonDown(0) && buildOn == true)
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;                

                if (resource.gold >= buildingData.price)
                {
                    if (buildingPlacement.IsLegalPosition())
                    {
                        Instantiate(Building, new Vector3(sel.pos.x, Building.transform.position.y, sel.pos.z),Building.transform.rotation);
                        obstacle.enabled = true;
                        resource.gold -= buildingData.price;
                        if(buildingData.Name == "Builder Bay")
                        {
                            gameManager.haveBuilderBay = true;
                        }
                        if (buildingData.Name == "Refinery")
                        {
                            gameManager.haveRefinery= true;
                        }
                        if (buildingData.Name == "Armory")
                        {
                            gameManager.haveArmory = true;
                        }
                        if (buildingData.Name == "Frontier Lab")
                        {
                            gameManager.haveFrontierLab = true;
                        }
                        if(buildingData.Name == "Warehouse")
                        {
                            gameManager.warehouseNum++;
                        }
                        buildOn = false;
                    }
                }
                else
                    buildOn = false;
                
                
            }
            if (Input.GetMouseButtonDown(1) && buildOn == true)
            {
                buildOn = false;

            }
        }
    }
}

