using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalMoney : MonoBehaviour
{
    public TextMeshProUGUI currentMoneyText;
    private float currentMoney;
    public static float cashInATM =0;
    public static bool inPortal = false;
    private int oldMoneyCount;

    private GameObject player;
    private List<GameObject> moneys_;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moneys_ = player.GetComponent<playerController>().moneys;
        currentMoney = moneys_.Count;
    }

    // Update is called once per frame
    void Update()
    {

        currentMoneyText.text = currentMoney.ToString();

        if ((oldMoneyCount != moneys_.Count || inPortal ==true) && moneys_.Count>0)
        {
            currentMoney = cashInATM;

            for (int i = 0; i < moneys_.Count; i++)
            {
                if (moneys_[i].gameObject.transform.GetChild(0).gameObject.name == "money")
                {
                    currentMoney++;
                }
                if (moneys_[i].gameObject.transform.GetChild(0).gameObject.name == "goldx")
                {
                    currentMoney = currentMoney + 2;
                }
                if (moneys_[i].gameObject.transform.GetChild(0).gameObject.name == "diamond")
                {
                    currentMoney = currentMoney + 4;
                }
            }
            oldMoneyCount = moneys_.Count;
            inPortal = false;
        }
        else if(moneys_.Count <= 0)
        {
            currentMoney = cashInATM;
        }
    }
}
