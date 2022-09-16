using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine_Atm : MonoBehaviour
{
    
    private float moneyInAtmCount;

    private GameObject player;
    private List<GameObject> moneys_;  

    private List<GameObject> moneyAtm = new List<GameObject>();
    
    
    

    void Start()
    {
        moneyInAtmCount = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        moneys_ = player.GetComponent<playerController>().moneys;
        
    }

    
    void Update()
    {
        

        if (moneyAtm.Count>0)
        {
            

            var target = gameObject.transform.position;
            target.y = moneyAtm[0].gameObject.transform.position.y;
            target.x = target.x - 20;


            

            for (int i = 0; i < moneyAtm.Count; i++)
            {
                moneyAtm[i].gameObject.transform.position = Vector3.Lerp(moneyAtm[i].gameObject.transform.position, target, Time.deltaTime * 0.5f);

                
                if (moneyAtm[i].gameObject.transform.position.x < playerController.minXLimit + 1)
                {
                    moneyAtm[i].gameObject.SetActive(false);
                    
                }
            }
        }
        

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("takenMoney") && moneys_.Count > 0)
        {

            other.gameObject.tag = "Untagged";
            for (int i = 0; i < moneys_.Count; i++)
            {

                if (other.gameObject.transform.GetChild(0).gameObject.name == "money")
                {

                    if (moneys_[i].gameObject.name == other.gameObject.name)
                    {
                        moneyInAtmCount++;                        
                        TotalMoney.cashInATM = TotalMoney.cashInATM + 1;
                        moneys_.RemoveAt(i);

                        

                        moneyAtm.Add(other.gameObject);
                        
                        
                        
                    }

                }
                if (other.gameObject.transform.GetChild(0).gameObject.name == "goldx")
                {

                    if (moneys_[i].gameObject.name == other.gameObject.name)
                    {
                        moneyInAtmCount = moneyInAtmCount + 2;
                        TotalMoney.cashInATM = TotalMoney.cashInATM + 2;
                        
                        moneys_.RemoveAt(i);


                        

                        moneyAtm.Add(other.gameObject);
                        
                        
                        
                    }

                }

                if (other.gameObject.transform.GetChild(0).gameObject.name == "diamond")
                {

                    if (moneys_[i].gameObject.name == other.gameObject.name)
                    {
                        moneyInAtmCount = moneyInAtmCount + 4;
                        TotalMoney.cashInATM = TotalMoney.cashInATM + 4;
                        moneys_.RemoveAt(i);


                        
                        moneyAtm.Add(other.gameObject);
                        
                        
                        

                    }

                }
            }

            
        }
                
    }

    

    

}
