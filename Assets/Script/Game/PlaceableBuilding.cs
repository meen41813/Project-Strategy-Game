using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableBuilding : MonoBehaviour
{
    public List<Collider> colliders = new List<Collider>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Building" || other.tag == "Unit")
        {
            colliders.Add(other);
        }
    }
    void OnTriggerExit(Collider other)
    {


        if (other.tag == "Building" || other.tag == "Unit")
        {
            colliders.Remove(other);
        }
    }
}
