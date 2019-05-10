using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SelectManage : MonoBehaviour
{

    public GameObject selected;
    public SpawnManage spawnManage;

    public Vector3 pos;
    RaycastHit hitInfo;
    public List<UnitManage> selectedUnits = new List<UnitManage>();
    public bool isDragging = false;
    Vector3 mousePosition;

    public GameObject MarkPoint;

    public GameObject createUnitUI;
    public GameObject openCretar;
    public GameObject closeCretar;
    public GameObject unitSet;
    public GameObject buildingSet;


    private void OnGUI()
    {
        if (isDragging)
        {
            var rect = ScreenHelper.GetScreenRect(mousePosition, Input.mousePosition);
            ScreenHelper.DrawScreenRect(rect, new Color(0.8f,0.8f,0.95f,0.1f));
            ScreenHelper.DrawScreenRectBorder(rect, 1, Color.green);
        }  
    }
    
    void Update()
    {

        
        spawnManage = GameObject.Find("Spawn").GetComponent<SpawnManage>();
        //use pos to placement building
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
        {
            pos = hitInfo.point;
        } 
        
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                pos = hitInfo.point;
                if (hitInfo.transform.CompareTag("Unit"))
                {
                    SelectUnit(hitInfo.transform.GetComponent<UnitManage>(), Input.GetKey(KeyCode.LeftShift));
                    if (selected == null)
                    {
                        selected = hitInfo.transform.gameObject;
                        GameObject.Find("Canvas").GetComponent<InterfaceManage>().ShowData();
                    }
                    else
                    {
                        if (selected.transform.CompareTag("Building"))                       
                            selected.transform.Find("Maker").gameObject.SetActive(false);                       
                        GameObject.Find("Canvas").GetComponent<InterfaceManage>().HideData();
                        selected = null;
                        selected = hitInfo.transform.gameObject;
                        GameObject.Find("Canvas").GetComponent<InterfaceManage>().ShowData();
                    }
                }
                else                
                    isDragging = true;                                       
                
                if (hitInfo.transform.tag == "Building")
                {
                    BuildingData buildingData = hitInfo.transform.GetComponent<BuildingData>();
                    if (selected == null)
                    {
                        selected = hitInfo.transform.gameObject;
                        selected.transform.Find("Maker").gameObject.SetActive(true);
                        GameObject.Find("Canvas").GetComponent<InterfaceManage>().ShowData();
                    }
                    else
                    {
                        selected.transform.Find("Maker").gameObject.SetActive(false);
                        GameObject.Find("Canvas").GetComponent<InterfaceManage>().HideData();
                        selected = null;
                        selected = hitInfo.transform.gameObject;
                        selected.transform.Find("Maker").gameObject.SetActive(true);
                        GameObject.Find("Canvas").GetComponent<InterfaceManage>().ShowData();
                    }
                    if (spawnManage.buildOn == false && buildingData.Name == "Factory")
                    {
                        openCretar.SetActive(false);
                        closeCretar.SetActive(true);
                        createUnitUI.SetActive(true);
                        unitSet.SetActive(true);
                        buildingSet.SetActive(false);
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                DeselectUnits();
                foreach (var selectableObject in FindObjectsOfType<UnitManage>())
                {
                    if (IsWithinSelectionBounds(selectableObject.transform))
                    {
                        SelectUnit(selectableObject.gameObject.GetComponent<UnitManage>(), true);
                    }
                }
                isDragging = false;
            }          
        }      
        if (Input.GetMouseButtonDown(1) && selectedUnits.Count > 0)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                if (hitInfo.transform.CompareTag("Ground"))
                {
                    foreach (var selectableObj in selectedUnits)
                    {                        
                        selectableObj.MoveUnit(hitInfo.point);                        
                    }
                    Destroy(Instantiate(MarkPoint, new Vector3(hitInfo.point.x, 0.1f, hitInfo.point.z), Quaternion.identity), 0.25f);
                }   
                else if (hitInfo.transform.CompareTag("Enemy"))
                {
                    hitInfo.transform.Find("CanvasHP").gameObject.SetActive(true);

                    foreach (var selectableObj in selectedUnits)
                    {
                        //Debug.Log(selectableObj.name);
                        if (selectableObj.Type == "Melee" || selectableObj.Type == "Mortar" || selectableObj.Type == "Tank" || selectableObj.Type == "Glue")
                        {
                            selectableObj.SetNewTarget(hitInfo.transform);
                        }

                        //selectableObj.transform.LookAt(hitInfo.transform.position);
                        /*Vector3 lTargetDir = hitInfo.transform.position - selectableObj.transform.position;

                        selectableObj.transform.rotation = Quaternion.RotateTowards(selectableObj.transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * 5);*/
                    }
                }
                else if (hitInfo.transform.CompareTag("Resource"))
                {
                    foreach (var selectableObj in selectedUnits)
                    {
                        hitInfo.transform.Find("CanvasHP").gameObject.SetActive(true);
                        if (selectableObj.Type == "Worker" || selectableObj.Type == "Miner")
                        {
                            selectableObj.SetDig(hitInfo.transform);
                        }                       
                    }
                }
                else if (hitInfo.transform.CompareTag("BuildingEnemy"))
                {
                    foreach (var selectableObj in selectedUnits)
                    {
                        hitInfo.transform.Find("CanvasHP").gameObject.SetActive(true);
                        if (selectableObj.Type == "Melee" || selectableObj.Type == "Mortar" || selectableObj.Type == "Tank" || selectableObj.Type == "Glue")
                        {
                            selectableObj.SetNewTarget(hitInfo.transform);
                        }                      
                    }
                }
            }
        }
    }   
    private void SelectUnit(UnitManage unit, bool isMultiSelect = false)
    {
        if (!isMultiSelect)
        {
            DeselectUnits();
        }
        
        selectedUnits.Add(unit);
        unit.SetSelected(true);
       

    }

    private void DeselectUnits()
    {
        for(int i = 0; i < selectedUnits.Count; i++)
        {
            //selectedUnits[i].Find("Maker").gameObject.SetActive(false);
            selectedUnits[i].SetSelected(false);
        }
        selectedUnits.Clear();
    }

    private bool IsWithinSelectionBounds(Transform transform)
    {
        if (!isDragging)
        {
            return false;
        }
        var camera = Camera.main;
        var viewportBounds = ScreenHelper.GetViewportBounds(camera, mousePosition, Input.mousePosition);
        return viewportBounds.Contains(camera.WorldToViewportPoint(transform.position));
    }
}
