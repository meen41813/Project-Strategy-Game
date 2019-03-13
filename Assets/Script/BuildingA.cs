using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingA : MonoBehaviour
{
    public GameObject building;
    public bool buildOn = false;
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
        buildOn = true;
        if (buildOn)
        {
            
           
            //Debug.Log("buildOn = " + buildOn);
            
            //Debug.Log(cameraScript.pos);
            
            
            
        }

        //Debug.Log(a.selected);

    }
}
