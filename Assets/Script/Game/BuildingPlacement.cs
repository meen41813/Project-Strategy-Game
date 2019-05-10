using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BuildingPlacement : MonoBehaviour
{
    private PlaceableBuilding placeableBudiling;
    private Transform currentBuilding;
    public GameObject selectManage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    
        SelectManage s = selectManage.GetComponent<SelectManage>(); 
        if (currentBuilding != null)
        {
            NavMeshObstacle obstacle = currentBuilding.GetComponent<NavMeshObstacle>();
            //Debug.Log(obstacle);
            obstacle.enabled = false;
            currentBuilding.position = new Vector3(s.pos.x,currentBuilding.transform.position.y, s.pos.z);
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                Destroy(currentBuilding.gameObject); 
            }
        }   
    }

    public bool IsLegalPosition()
    {
        if(placeableBudiling.colliders.Count > 0)
        {
            return false;
        }
        return true;
    }

    public void SetBuilding(GameObject Build)
    {
        currentBuilding = ((GameObject)Instantiate(Build)).transform;
        placeableBudiling = currentBuilding.GetComponent<PlaceableBuilding>();
    }
}
