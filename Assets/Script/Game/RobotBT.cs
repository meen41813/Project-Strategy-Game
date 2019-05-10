using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBT : MonoBehaviour
{
    public GameObject Robot;
    public UnitBuild unitBuild;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickBT()
    {
        
        unitBuild = GameObject.Find("UnitSet").GetComponent<UnitBuild>();
        //Debug.Log(unitBuild);
        unitBuild.robot = Robot;
    }
}
