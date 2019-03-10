using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUnit : MonoBehaviour
{
    //public GameObject unit;
    // Start is called before the first frame update
    public GameObject a;
    
    void Start()
    {
       
        
    }

    // Update is called once per frame
    public void clickBT()
    {
        CameraManage cameraScript = GameObject.Find("Main Camera").GetComponent<CameraManage>();
        UnitManage  unit = cameraScript.selected.GetComponent<UnitManage>();
        //Debug.Log(a.selected);
         if (cameraScript.selected)
         {
            unit.Attacked();
         }
    }
}
