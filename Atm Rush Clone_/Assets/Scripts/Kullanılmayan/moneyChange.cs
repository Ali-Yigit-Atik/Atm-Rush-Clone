using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyChange : MonoBehaviour
{
    public GameObject gold;
    public GameObject diamond;

    private GameObject player;
    private List<GameObject> moneys_;

    public bool isNeedchange = false;
    public bool isToBeGold = false;
    public bool isToBeDiamond = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moneys_ = player.GetComponent<playerController>().moneys;
    }

    private void Update()
    {
        if (isToBeGold && isNeedchange)
        {
            for (int i = 0; i < moneys_.Count; i++)
            {


                if (moneys_[i].gameObject.name == gameObject.name)
                {
                    GameObject newMoney;
                    newMoney = Instantiate(gold, gameObject.transform.position, Quaternion.identity);
                    
                    moneys_[i] = null;
                    //other.gameObject.SetActive(false);
                    moneys_[i] = newMoney;
                    StartCoroutine(notChangeForWhile(moneys_[i]));
                    StartCoroutine(biggerForWhile(moneys_[i].gameObject));
                    moneys_[i].gameObject.SetActive(false);
                }
            }
        }

        if (isToBeDiamond && isNeedchange)
        {
            for (int i = 0; i < moneys_.Count; i++)
            {


                if (moneys_[i].gameObject.name == gameObject.name)
                {
                    GameObject newMoney;
                    newMoney = Instantiate(diamond, gameObject.transform.position, Quaternion.identity);

                    moneys_[i] = null;
                    //other.gameObject.SetActive(false);
                    moneys_[i] = newMoney;
                    StartCoroutine(notChangeForWhile(moneys_[i]));
                    StartCoroutine(biggerForWhile(moneys_[i].gameObject));
                    moneys_[i].gameObject.SetActive(false);
                }
            }
        }
    }

    IEnumerator notChangeForWhile(GameObject money)
    {
        money.gameObject.tag = "Untagged";
        yield return new WaitForSeconds(0.5f);

        //foreach(var a in moneys_) //  bugdan kaçýnmak için obje hala listede mi diye teyidini yaptým
        //{
        //    if(a.gameObject.name == money.gameObject.name)
        //    {
        //        money.gameObject.tag = "takenMoney";
        //    }
        //}




        money.gameObject.tag = "takenMoney";



    }


    IEnumerator biggerForWhile(GameObject a)
    {



        a.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        yield return new WaitForSeconds(0.08f);
        a.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);


    }
}
