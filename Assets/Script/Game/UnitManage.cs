using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class UnitManage : MonoBehaviour
{

    public Text nameText;
    public Text HPText;

    public string Name;
    public int maxHP;
    public float attackRange;
    public float attackSpeed;
    public float CountAttackSpeed;

    public int digDamage;
    public int damage;
    public float time;
    public int currentHP;
    public Image HPBar;
    public bool isAttacked = false;
    
    public string Type;

    public bool moveOn = false;

    //public GameObject selected;
    public SelectManage  selectUnit;
    public EnemyManage enemyManage;
    public BuildingData enemyBuilding;

    public LayerMask whatCanbeClickOn;
    public NavMeshAgent myAgent;
    public RaycastHit hitInfo;
    public Transform currentTarget;
  

    void Start()
    {
        selectUnit = GameObject.Find("SelectManage").GetComponent<SelectManage>();
        myAgent = this.gameObject.GetComponent<NavMeshAgent>();
       
        if (Type == "Worker" || Type == "Builder")
        {
            maxHP = 100;
            attackRange = 3;
            damage = 0;
            attackSpeed = 1;
            digDamage = 10;
        }
        else if(Type == "Miner")
        {
            maxHP = 200;
            attackRange = 3;
            damage = 0;
            attackSpeed = 1;
            digDamage = 30;

        }
        else if (Type == "Melee")
        {
            maxHP = 300;
            attackRange = 3;
            damage = 20;
            attackSpeed = 1;
        }
        else if (Type == "Tank")
        {
            maxHP = 200;
            attackRange = 5;
            damage = 30;
            attackSpeed = 2;
        }
        else if (Type == "Mortar")
        {
            maxHP = 100;
            attackRange = 8;
            damage = 50;
            attackSpeed = 4;
        }
        else if (Type == "Repair")
        {
            maxHP = 200;
            attackRange = 3;
            damage = 0;
            attackSpeed = 2;
        }
        else if (Type == "Glue")
        {
            maxHP = 200;
            attackRange = 5;
            damage = 10;
            attackSpeed = 2;
        }
        currentHP = maxHP;
    }

    void Update()
    {
        CountAttackSpeed += Time.deltaTime;
        //Debug.Log(attackSpeed);
        if (currentTarget != null)
        {
            myAgent.destination = currentTarget.position;
            if (currentTarget.CompareTag("Enemy") || currentTarget.CompareTag("BuildingEnemy"))           
            {
                enemyManage = currentTarget.GetComponent<EnemyManage>();
                enemyBuilding = currentTarget.GetComponent<BuildingData>();

                Vector3 lTargetDir = currentTarget.position - transform.position;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * 1);
                float distanceAttack = (currentTarget.position - transform.position).magnitude;
                if(distanceAttack <= myAgent.stoppingDistance)
                {                   
                    Attack(currentTarget);   
                }
            }    
            else if (currentTarget.CompareTag("Resource"))
            {
                float distance = (currentTarget.position - transform.position).magnitude;
                if (distance <= myAgent.stoppingDistance)
                {
                    if (CountAttackSpeed >= attackSpeed)
                    {
                        currentTarget.GetComponent<GoldManage>().takeDamage(digDamage);
                        CountAttackSpeed = 0;
                    }
                }
            }
        }
    }

    public void MoveUnit(Vector3 dest)
    {
        currentTarget = null;
        myAgent.stoppingDistance = 1;
        myAgent.destination = dest;
    }
    
    public void SetSelected(bool isSelected)
    {
        transform.Find("Maker").gameObject.SetActive(isSelected);
        //transform.Find("CanvasHP").gameObject.SetActive(isSelected);
    }

    public void SetNewTarget(Transform enemy)
    {
        currentTarget = enemy;
        myAgent.stoppingDistance = attackRange;
    }

    public void Attack(Transform enemy)
    {
        if(CountAttackSpeed >= attackSpeed)
        {
            if (enemy.CompareTag("Enemy"))
                enemyManage.TakeDamage(damage);
            else
                enemyBuilding.takeDamage(damage);
            //Debug.Log(transform.name + ": ATTACK");
            CountAttackSpeed = 0;
        }       
    }

    public void TakeDamage(int damage)
    {
        isAttacked = true;
        currentHP -= damage;
        if (isAttacked)
            StartCoroutine(ShowDamage());
        HPBar.fillAmount = (float)currentHP / maxHP;
        isAttacked = false;
        if (currentHP <= 0)
        {
            isAttacked = false;
            Destroy(this.gameObject);
            GameObject.Find("SelectManage").GetComponent<SelectManage>().selectedUnits.Remove(this.gameObject.GetComponent<UnitManage>());
        }
    }

    IEnumerator ShowDamage()
    {
        var renderer = GetComponent<Renderer>();
        Color defaultColor = renderer.material.color;
        renderer.material.color = Color.blue;
        yield return new WaitForSeconds(0.005f);
        renderer.material.color = defaultColor;
        //yield return new WaitForSeconds(0.05f);
    }

    public void SetDig(Transform resource)
    {
        currentTarget = resource;
        myAgent.stoppingDistance = 3;
        myAgent.destination = currentTarget.position;
    }


    
}
