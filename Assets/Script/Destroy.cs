using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    public GameObject account;
    
    public void destroySelf()
    {
        Destroy(account);
    }
}
