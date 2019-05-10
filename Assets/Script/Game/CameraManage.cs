using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManage : MonoBehaviour
{
    // Start is called before the first frame update
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;
    public float scrollSpeed = 5f;
    public float zoomIn = 10f;
    public float zoomOut = 20f;
    //public Vector3 pos;

    //public GameObject UI;

    //public GameObject selected;

    // Update is called once per frame
    void Update()
    {
        panCamera();
       //W selectObject();
    }

    private void panCamera()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        else if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        else if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        else if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, zoomIn, zoomOut);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);
        transform.position = pos;
    }
    /*public void selectObject()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.Log(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray,out hitInfo))
            {
                if (hitInfo.transform.tag == "Unit")
                {
                    UnitManage unit = hitInfo.transform.GetComponent<UnitManage>();
                    unit.moveOn = true;
                    selected = hitInfo.transform.gameObject;
                    UI.gameObject.SetActive(true);                 
                }             
                else if(hitInfo.transform.tag == "Ground")
                {
                    pos = hitInfo.point;
                }

            }

        }
        
    }*/


}
