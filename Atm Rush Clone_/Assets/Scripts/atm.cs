using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class atm : MonoBehaviour
{
    public TextMeshProUGUI moneyInAtm;
    private float moneyInAtmCount;

    private GameObject player;
    private List<GameObject> moneys_;
    private bool atmNeedToMove =false;
    private float atmTarget;

    void Start()
    {
        moneyInAtmCount = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        moneys_ = player.GetComponent<playerController>().moneys;
        atmTarget = gameObject.transform.position.y + 0.15f - gameObject.GetComponent<Collider>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        moneyInAtm.text = moneyInAtmCount.ToString();

        if (atmNeedToMove)
        {
            var Ysize = gameObject.GetComponent<Collider>().bounds.size.y;
            
            //var Yposition = Mathf.Lerp(transform.position.y, (transform.position.y) - Ysize, Time.deltaTime * 10);
            gameObject.transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, (transform.position.y+0.15f) - Ysize, Time.deltaTime*10), transform.position.z);
            Debug.Log("atm çalýþýyor");
            
            if(gameObject.transform.position.y <= atmTarget)
            {
                atmNeedToMove = false;
            }
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("takenMoney") && moneys_.Count>0)
        {

            other.gameObject.tag = "Untagged";
            for (int i = 0; i < moneys_.Count; i++)
            {

                if (other.gameObject.transform.GetChild(0).gameObject.name == "money")
                {
                    
                    if(moneys_[i].gameObject.name == other.gameObject.name)
                    {
                        moneyInAtmCount++;
                        moneys_[i].gameObject.SetActive(false);
                        moneys_.RemoveAt(i);

                        //var Xposition = Mathf.Lerp(other.gameObject.transform.position.x, (transform.position.x) , Time.deltaTime * 10);
                        //var Zposition = Mathf.Lerp(other.gameObject.transform.position.z, (transform.position.z) , Time.deltaTime * 10);
                        //other.gameObject.transform.position = new Vector3(Xposition, other.gameObject.transform.position.y, Zposition);

                        //other.gameObject.SetActive(false);
                        TotalMoney.cashInATM = TotalMoney.cashInATM + 1;
                    }

                }
                if (other.gameObject.transform.GetChild(0).gameObject.name == "goldx")
                {
                    
                    if (moneys_[i].gameObject.name == other.gameObject.name)
                    {
                        moneyInAtmCount = moneyInAtmCount + 2;
                        moneys_[i].gameObject.SetActive(false);
                        //other.gameObject.SetActive(false);
                        moneys_.RemoveAt(i);
                        

                        //var Xposition = Mathf.Lerp(other.gameObject.transform.position.x, (transform.position.x), Time.deltaTime * 10);
                        //var Zposition = Mathf.Lerp(other.gameObject.transform.position.z, (transform.position.z), Time.deltaTime * 10);
                        //other.gameObject.transform.position = new Vector3(Xposition, other.gameObject.transform.position.y, Zposition);

                        TotalMoney.cashInATM = TotalMoney.cashInATM + 2;
                        //other.gameObject.SetActive(false);
                    }

                }

                if (other.gameObject.transform.GetChild(0).gameObject.name == "diamond")
                {
                    
                    if (moneys_[i].gameObject.name == other.gameObject.name)
                    {
                        moneyInAtmCount = moneyInAtmCount + 4;
                        moneys_[i].gameObject.SetActive(false);
                        moneys_.RemoveAt(i);

                        //var Xposition = Mathf.Lerp(other.gameObject.transform.position.x, (transform.position.x), Time.deltaTime * 10);
                        //var Zposition = Mathf.Lerp(other.gameObject.transform.position.z, (transform.position.z), Time.deltaTime * 10);
                        //other.gameObject.transform.position = new Vector3(Xposition, other.gameObject.transform.position.y, Zposition);

                        TotalMoney.cashInATM = TotalMoney.cashInATM + 4;
                        //other.gameObject.SetActive(false);
                    }

                }
            }
            
        }

        if(other.gameObject == player.gameObject.transform.GetChild(0).gameObject)
        {
            atmNeedToMove = true;
        }
    }
}
