using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeTag : MonoBehaviour
{
    public GameObject account;
    public Button nameBtn;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    void Update()
    {
        ColorBlock cb = nameBtn.GetComponent<Button>().colors;
        if (gameObject.tag == "Untagged")
        {
            
            cb.highlightedColor = Color.white;
            nameBtn.colors = cb;
        }
        else if (gameObject.tag == "Selected")
        {
            
            cb.highlightedColor = Color.green;
            nameBtn.colors = cb;
        }
    }
    public void changeTag()
    {
        //when click button
        if (gameObject.tag == "Untagged")
        {           
            gameObject.tag = "Selected";
        }
        else if (gameObject.tag == "Selected")
        {
            gameObject.tag = "Untagged";
        }

    }
   
   
}
