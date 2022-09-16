using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class moneyCollect_ : MonoBehaviour
{
    
    private GameObject player;
    private Vector3 firtsMoneyPosReference;    
    private List<GameObject> moneys_;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");               
        moneys_ = player.GetComponent<playerController>().moneys;
    }

    
    void Update()
    {
        firtsMoneyPosReference = player.transform.GetChild(0).gameObject.transform.position;
        


        if (moneys_.Count >= 1)
        {
            for (int i = 0; i < moneys_.Count; i++)
            {
                if (i == 0)
                {
        
                    var yEkseni = moneys_[i].gameObject.transform.position.y;
                    var zEkeseni = firtsMoneyPosReference.z + player.transform.GetChild(0).gameObject.GetComponent<Collider>().bounds.size.z / 2 + moneys_[i].gameObject.GetComponent<Collider>().bounds.size.z / 2;
                    moneys_[i].gameObject.transform.position = new Vector3(firtsMoneyPosReference.x, yEkseni, zEkeseni);
                    //Debug.Log("for döngüsü 1.");
                }
                else
                {
                    var yEkseni = moneys_.ElementAt(i).gameObject.transform.position.y;
                    var zEkseni = moneys_.ElementAt(i-1).gameObject.transform.position.z + moneys_.ElementAt(i).gameObject.GetComponent<Collider>().bounds.size.z / 2 + moneys_.ElementAt(i-1).gameObject.GetComponent<Collider>().bounds.size.z / 2;
                    moneys_[i].gameObject.transform.position = new Vector3(Mathf.Lerp(moneys_.ElementAt(i).gameObject.transform.position.x, moneys_.ElementAt(i-1).gameObject.transform.position.x, (5/10f) * Time.deltaTime), yEkseni, zEkseni);
                    //Debug.Log("for döngüsü diðerleri.");
                }
            }
        }


       



    }

   


    private void OnCollisionEnter(Collision collision)
    {
        {
            if ((gameObject.CompareTag("moneyGrubber") || gameObject.CompareTag("takenMoney")) && moneys_.Count >=0 )
            {



                if (collision.gameObject.CompareTag("money") == true )
                {

                    if (moneys_.Count <= 0)
                    {
                        moneys_.Add(collision.gameObject);                        
                        
                        collision.gameObject.tag = "takenMoney";

                        //Debug.Log("ilk para");
                        //Debug.Log("boss'un z ekseninin yarý uzunluðu " + player.transform.GetChild(0).gameObject.GetComponent<Collider>().bounds.size.z / 2);
                        //Debug.Log("ilk toplanan obejenin z ekseninin yarý uzunluðu: " + (collision.gameObject.GetComponent<Collider>().bounds.size.z / 2));
                        
                        StartCoroutine(biggerForWhile());

                        
                    }
                    else if ((moneys_.Count > 0))
                    {
                        moneys_.Add(collision.gameObject);                        
                        collision.gameObject.tag = "takenMoney";                        
                        //Debug.Log("diðer paralar");
                        StartCoroutine(biggerForWhile());

                        
                    }


                }
            }
        }

        
    }

    IEnumerator biggerForWhile()
    {


        if (moneys_.Count >= 0)
        {


            for (int i = 1; i <= moneys_.Count; i++)
            {
                

                moneys_[moneys_.Count - i].gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                yield return new WaitForSeconds(0.05f);
                if ((moneys_.Count - i) >=0 && moneys_[moneys_.Count - i].activeSelf == true)
                {
                    moneys_[moneys_.Count - i].gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                }
                else if ((moneys_.Count - i) >= 0 && moneys_[moneys_.Count - i].activeSelf == false)
                {
                    moneys_[moneys_.Count - i].gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                    continue;
                }

            }
        }

        
        
    }
}
