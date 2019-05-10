using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingA : MonoBehaviour
{
    public GameObject building;
    public SpawnManage spawnManage;
    public SelectManage selectBuild;
    public BuildingPlacement buildingPlacement;
    public BuildingData buildingData;
    public GameManager gameManager;
    

    public int price;

    void Start()
    {
        spawnManage = GameObject.Find("Spawn").GetComponent<SpawnManage>();
        selectBuild = GameObject.Find("SelectManage").GetComponent<SelectManage>();
        buildingPlacement =GameObject.Find("Main Camera Game").GetComponent<BuildingPlacement>();
        buildingData = building.GetComponent<BuildingData>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }
    public void clickBT()
    {
        /*if(buildingData.Name == "Builder Bay" &&)
        {

        }*/

        //what can create

        if(buildingData.Rank == "L" )
        {                                 
            if ((buildingData.Name == "Builder Bay" && gameManager.haveBuilderBay == false) || buildingData.Name != "Builder Bay")
            {
                spawnManage.Building = building;
                spawnManage.buildOn = true;
                buildingPlacement.SetBuilding(building);               
            }          
        }

        /*if(buildingData.Name == "Builder Bay" && gameManager.haveBuilderBay == false)
        {
            spawnManage.Building = building;
            //selectBuild.SelectBuilding = building;
            spawnManage.buildOn = true;
            buildingPlacement.SetBuilding(building);
        }*/

        if(buildingData.Rank == "H" && gameManager.haveBuilderBay == true )
        {
            if (buildingData.Name == "Builder Bay" && gameManager.haveBuilderBay == false)
            {
                spawnManage.Building = building;
                //selectBuild.SelectBuilding = building;
                spawnManage.buildOn = true;
                buildingPlacement.SetBuilding(building);
            }
            if (buildingData.Name == "Refinery" && gameManager.haveRefinery == false)
            {
                spawnManage.Building = building;
                //selectBuild.SelectBuilding = building;
                spawnManage.buildOn = true;
                buildingPlacement.SetBuilding(building);
            }
            if (buildingData.Name == "Armory" && gameManager.haveArmory == false)
            {
                spawnManage.Building = building;
                //selectBuild.SelectBuilding = building;
                spawnManage.buildOn = true;
                buildingPlacement.SetBuilding(building);
            }
            if (buildingData.Name == "Frontier Lab" && gameManager.haveFrontierLab == false)
            {
                spawnManage.Building = building;
                //selectBuild.SelectBuilding = building;
                spawnManage.buildOn = true;
                buildingPlacement.SetBuilding(building);
            }
            
        }
       

    }
}
