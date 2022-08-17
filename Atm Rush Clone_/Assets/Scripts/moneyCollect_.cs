using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class moneyCollect_ : MonoBehaviour
{
    //public List<GameObject> moneys = new List<GameObject>();
    private GameObject player;
    private Vector3 firtsMoneyPosReference;
    private int sweepSpeed;
    private List<GameObject> moneys_;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sweepSpeed = player.GetComponent<playerController>().sweepSpeed;
        //firtsMoneyPosReference = player.transform.GetChild(0).gameObject.GetComponent<Collider>().bounds.center;
        moneys_ = player.GetComponent<playerController>().moneys;
    }

    // Update is called once per frame
    void Update()
    {
        firtsMoneyPosReference = player.transform.GetChild(0).gameObject.transform.position;
        //Debug.Log("firtsMoneyPosReference: " + firtsMoneyPosReference);


        if (moneys_.Count >= 1)
        {
            for (int i = 0; i < moneys_.Count; i++)
            {
                if (i == 0)
                {
        
                    var yEkseni = moneys_[i].gameObject.transform.position.y;
                    var zEkeseni = firtsMoneyPosReference.z + player.transform.GetChild(0).gameObject.GetComponent<Collider>().bounds.size.z / 2 + moneys_[i].gameObject.GetComponent<Collider>().bounds.size.z / 2;
                    moneys_[i].gameObject.transform.position = new Vector3(firtsMoneyPosReference.x, yEkseni, zEkeseni);
                    Debug.Log("for döngüsü 1.");
                }
                else
                {
                    var yEkseni = moneys_.ElementAt(i).gameObject.transform.position.y;
                    var zEkseni = moneys_.ElementAt(i-1).gameObject.transform.position.z + moneys_.ElementAt(i).gameObject.GetComponent<Collider>().bounds.size.z / 2 + moneys_.ElementAt(i-1).gameObject.GetComponent<Collider>().bounds.size.z / 2;
                    moneys_[i].gameObject.transform.position = new Vector3(Mathf.Lerp(moneys_.ElementAt(i).gameObject.transform.position.x, moneys_.ElementAt(i-1).gameObject.transform.position.x, (5/10f) * Time.deltaTime), yEkseni, zEkseni);
                    Debug.Log("for döngüsü diðerleri.");
                }
            }
        }


        //if (moneys_.Count > 0)
        //{
        //    for(int i )
        //}



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
                        //moneys.Add(collision.gameObject);
                        //collision.gameObject.transform.position = new Vector3(firtsMoneyPosReference.x, collision.gameObject.transform.position.y, firtsMoneyPosReference.z + (player.transform.GetChild(0).gameObject.GetComponent<Collider>().bounds.size.z / 2) + (collision.gameObject.GetComponent<Collider>().bounds.size.z / 2));
                        moneys_.Add(collision.gameObject);
                        //collision.gameObject.GetComponent<Collider>().isTrigger = true;
                        //collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        Debug.Log("ilk para");
                        collision.gameObject.tag = "takenMoney";
                        Debug.Log("boss'ýn z ekseninin yarý uzunluðu " + player.transform.GetChild(0).gameObject.GetComponent<Collider>().bounds.size.z / 2);
                        Debug.Log("ilk toplanan obejenin z ekseninin yarý uzunluðu: " + (collision.gameObject.GetComponent<Collider>().bounds.size.z / 2));
                        //collision.transform.parent = player.transform;
                        StartCoroutine(biggerForWhile());

                        //collision.gameObject.GetComponent<biggerForWhile>().isNeedToBeBigger = true;
                    }
                    else if ((moneys_.Count > 0))
                    {
                        //collision.gameObject.transform.position = new Vector3(moneys_.ElementAt(moneys_.Count - 1).gameObject.transform.position.x, collision.gameObject.transform.position.y, moneys_.ElementAt(moneys_.Count - 1).gameObject.transform.position.z + (collision.gameObject.GetComponent<Collider>().bounds.size.z / 2) + (moneys_.ElementAt(moneys_.Count - 1).gameObject.GetComponent<Collider>().bounds.size.z / 2));
                        moneys_.Add(collision.gameObject);
                        //collision.gameObject.GetComponent<Collider>().isTrigger = true;
                        //collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        collision.gameObject.tag = "takenMoney";
                        //collision.transform.parent = player.transform;
                        Debug.Log("diðer paralar");
                        StartCoroutine(biggerForWhile());

                        //collision.gameObject.GetComponent<biggerForWhile>().isNeedToBeBigger = true;
                    }


                }
            }
        }

        
    }

    IEnumerator biggerForWhile()
    {
        
        //var scaleFactor = 1.5f;
        
        
        for(int i =1; i<=moneys_.Count; i++)
        {
    
            //var Xscale = moneys_[i].gameObject.transform.localScale.x * scaleFactor;
            //var Ysacle = moneys_[i].gameObject.transform.localScale.y * scaleFactor;
            //var Zscale = moneys_[i].gameObject.transform.localScale.z * scaleFactor;
            //
            //var XscaleOld = moneys_[i].gameObject.transform.localScale.x / scaleFactor;
            //var YsacleOld = moneys_[i].gameObject.transform.localScale.y / scaleFactor;
            //var ZscaleOld = moneys_[i].gameObject.transform.localScale.z / scaleFactor;
    
            moneys_[moneys_.Count -i].gameObject.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
            yield return new WaitForSeconds(0.05f);
            if(moneys_[moneys_.Count - i].activeSelf == true)
            {
                moneys_[moneys_.Count - i].gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            }
            else if(moneys_[moneys_.Count - i].activeSelf == false)
            {
                moneys_[moneys_.Count - i].gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                continue;
            }
            
        }

        
        
    }
}
