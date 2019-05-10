using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GoldManage : MonoBehaviour
{
    public ResourceManage resourceManage;
    public Image HPBar;
    public int maxHP = 100;
    public int HP;

    void Start()
    {
        HP = maxHP;
        resourceManage = GameObject.Find("ResourceManage").GetComponent<ResourceManage>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void DestroyObj()
    {
        
    }
    public void takeDamage(int damage)
    {
        HP -= damage;
        HPBar.fillAmount = (float)HP / maxHP;
        if(HP <= 0)
        {
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.mission1++;
            resourceManage.gold += 10;
            Destroy(this.gameObject);
        }
    }
}
