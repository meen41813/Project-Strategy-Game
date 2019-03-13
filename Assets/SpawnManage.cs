using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManage : MonoBehaviour
{
    public GameObject buildBT;
    public GameObject camera;
    public GameObject Building;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        BuildingA build = buildBT.GetComponent<BuildingA>();
        CameraManage cam = camera.GetComponent<CameraManage>();
        if(Input.GetMouseButtonDown(0) && build.buildOn == true)
        {
            Debug.Log(cam.pos);
            Instantiate(Building, cam.pos, Quaternion.identity);
            build.buildOn = false;
        }
    }
}
