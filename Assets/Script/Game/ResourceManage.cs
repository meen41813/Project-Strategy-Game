using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManage : MonoBehaviour
{
    [SerializeField]
    private Text goldDisplay;
    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private int amountPerSec = 1;

    public int gold = 0;
    public int maxGold = 100;
    public bool canGene = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoldIncRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        maxGold = 100 * (1+ gameManager.warehouseNum);
        if (gold >= maxGold)
            gold = maxGold;
        goldDisplay.text = "Gold : " + gold + " / " + maxGold;       
    }
       
    IEnumerator GoldIncRoutine()
    {        
        gold += amountPerSec;
        yield return new WaitForSeconds(1f);
        StartCoroutine(GoldIncRoutine2());
    }
    IEnumerator GoldIncRoutine2()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(GoldIncRoutine());
    }

}

