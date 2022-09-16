using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleMoney : MonoBehaviour
{
    
    public GameObject gold;
    public GameObject diamond;
    private GameObject newMoney;

    private int goldNameCount=0;
    private int diamondNameCount=0;

    private GameObject player;
    private List<GameObject> moneys_;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moneys_ = player.GetComponent<playerController>().moneys;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("takenMoney") && moneys_.Count>0)
        {

            for (int i = 0; i < moneys_.Count; i++)
            {

                if (other.gameObject.transform.GetChild(0).gameObject.name == "money")
                {
                    if(moneys_[i].gameObject.name == other.gameObject.name)
                    {

                        goldNameCount++;

                        

                         
                        newMoney = Instantiate(gold, other.gameObject.transform.position, Quaternion.identity);
                        moneys_[i].gameObject.SetActive(false); 
                        moneys_[i] = null;
                        
                        moneys_[i] = newMoney;
                        moneys_[i].gameObject.name = "Gold_inst_" + goldNameCount.ToString();

                        StartCoroutine(notChangeForWhile(moneys_[i]));
                        StartCoroutine(biggerForWhile(moneys_[i].gameObject));
                        
                    }

                }
                if (other.gameObject.transform.GetChild(0).gameObject.name == "goldx")
                {
                    if (moneys_[i].gameObject.name == other.gameObject.name)
                    {
                        diamondNameCount++;

                        
                        
                        
                        newMoney = Instantiate(diamond, other.gameObject.transform.position, Quaternion.identity);
                        moneys_[i].gameObject.SetActive(false);
                        moneys_[i] = null;
                        
                        moneys_[i] = newMoney;

                        moneys_[i].gameObject.name = "Diamond_inst_" + diamondNameCount.ToString();

                        StartCoroutine(notChangeForWhile(moneys_[i]));
                        StartCoroutine(biggerForWhile(moneys_[i].gameObject));
                        
                    }

                }
            }

            TotalMoney.inPortal = true;
        }
    }

    IEnumerator notChangeForWhile(GameObject money)
    {
        money.gameObject.tag = "Untagged";
        yield return new WaitForSeconds(0.5f);
        
         
            
        money.gameObject.tag = "takenMoney";
        
    
    
    }
    
    
    IEnumerator biggerForWhile(GameObject a)
    {
    
                      
    
            a.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            yield return new WaitForSeconds(0.05f);
            a.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        
    
    }
}
