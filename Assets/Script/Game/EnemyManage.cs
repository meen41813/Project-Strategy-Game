using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManage : MonoBehaviour
{
    public int MaxHP = 200;
    public int CurrentHP;

    public float range = 5;
    public Transform target;
    public float rotateSpeed = 10f;

    public Image HealthBar;

    public float attackSpeed = 2f;
    public float CountAttackSpeed;
    public bool isAttacked = false;


    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = MaxHP;
        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        CountAttackSpeed += Time.deltaTime;

        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;
        transform.rotation= Quaternion.Euler(0f, rotation.y, 0f);
        if(target != null)
        {
            AttackUnit();
        }       

    }

    void AttackUnit()
    {
        UnitManage unit = target.GetComponent<UnitManage>();
        unit.transform.Find("CanvasHP").gameObject.SetActive(true);
        if (CountAttackSpeed >= attackSpeed)
        {
            unit.TakeDamage(30);          
            //Debug.Log(transform.name + ": ATTACK");
            CountAttackSpeed = 0;
        }
        
    }

    void UpdateTarget()
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestUnit = null;
        foreach(GameObject unit in units)
        {
            float distanceToUnit = Vector3.Distance(transform.position, unit.transform.position);
            if (distanceToUnit < shortestDistance)
            {
                shortestDistance = distanceToUnit;
                nearestUnit = unit;
            }
        }
        if (nearestUnit != null && shortestDistance <= range)
        {
            target = nearestUnit.transform;
        }
        else
            target = null;
    }

    public void TakeDamage(int damage)
    {
        if(this.gameObject != null)
        {
            isAttacked = true;
            CurrentHP -= damage;
            if (isAttacked)
            {
                StartCoroutine(ShowDamage());
                isAttacked = false;
            }
            HealthBar.fillAmount = (float)CurrentHP / MaxHP;
            if (CurrentHP <= 0)
            {
                GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
                isAttacked = false;
                Destroy(this.gameObject);
                gameManager.mission2++;
            }
        }
        
    }

    IEnumerator ShowDamage()
    {
        var renderer = GetComponent<Renderer>();
        Color defaultColor = renderer.material.color; 
        renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.005f);
        renderer.material.color = defaultColor;
        //yield return new WaitForSeconds(0.05f);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
