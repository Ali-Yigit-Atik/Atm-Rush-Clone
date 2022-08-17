using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;




public class obstacles : MonoBehaviour
{
    private GameObject player;
    private List<GameObject> moneys_;
    float ZPositionOld;
    private float axeStartAngle;
    private bool goBack = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moneys_ = player.GetComponent<playerController>().moneys;
        if (gameObject.CompareTag("axe"))
        {
            axeStartAngle = gameObject.transform.rotation.z;
        }
    }


    private void Update()
    {
        if (playerController.isHitObstacle && goBack ==true)
        {


            Debug.Log("ZPositionOld" + ZPositionOld);

            var target = gameObject.transform.position;
            target.x = player.transform.position.x;
            target.y = player.transform.position.y;

            player.transform.position = Vector3.MoveTowards(player.transform.position, target + new Vector3(0, 0, -9), Time.deltaTime * 8f);



            if (Mathf.Abs(gameObject.transform.position.z - player.transform.position.z) >= 7)
            {
                playerController.isHitObstacle = false;
                goBack = false;
                Debug.Log("sznjasfkjafjknaj");

            }
        }

        if (gameObject.CompareTag("axe"))
        {
        
        
            
        
            //float angle = (Mathf.Sin(Time.time) * 45); //tweak this to change frequency
            float angle = Mathf.PingPong(Time.time*50, 90);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        
        
        
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (gameObject.CompareTag("obstacle") )
        {
            Debug.Log("obstacle �al���or");
            
            if (collision.gameObject.CompareTag("takenMoney") && moneys_.Count > 0)
            {
                Debug.Log("takenMoney �al���or");
                

                var moneyOrder = 0;
                for (int i = 0; i < moneys_.Count; i++)
                {
                    if (moneys_[i].gameObject.name == collision.gameObject.name)
                    {
                        Debug.Log(" for d�g�s� obstacle �al���or");
                        moneyOrder = i;
                        
                    }
                    
                }

                if (moneys_[moneyOrder].gameObject == moneys_[(moneys_.Count - 1)])
                {

                    moneys_[moneyOrder].gameObject.tag = "Untagged";
                    moneys_.RemoveAt(moneyOrder);
                    collision.gameObject.SetActive(false);
                    
                }
                else if (moneys_[moneyOrder].gameObject != moneys_[(moneys_.Count - 1)])
                {
                    Debug.Log(" for d�g�s� moneys_[i].gameObject != moneys_[(moneys_.Count - 1)] �al���or");
                    for (int j = moneyOrder; j < moneys_.Count; j++)
                    {
                        moneys_[j].gameObject.tag = "Untagged";
                        var x = Random.Range(0, 2);

                        if (x == 2)
                        {
                            collision.gameObject.SetActive(false);
                            moneys_.RemoveAt(j);
                        }
                        else if (x == 1 || x==0)
                        {
                            
                            
                            
                            GameObject oldGameObject = moneys_[j].gameObject;
                            
                            moneys_.RemoveAt(j);

                            

                            var XPosition = playerController.midOfRoad + Random.Range(-3f, 3f);
                            var ZPosition = gameObject.transform.position.z + Random.Range(5, 8f);

                            if (XPosition < playerController.minXLimit)
                            {
                                XPosition = playerController.minXLimit;
                            }
                            if (XPosition > playerController.maxXLimit)
                            {
                                XPosition = playerController.maxXLimit;
                            }

                            oldGameObject.gameObject.transform.position = new Vector3(XPosition, oldGameObject.gameObject.transform.position.y, ZPosition);

                            oldGameObject.tag = "money";

                        }

                        
                    }
                }
            }

            if (collision.gameObject.CompareTag("moneyGrubber"))
            {

                playerController.isHitObstacle = true;
                goBack = true;
                ZPositionOld = player.transform.position.z;

            }

        }

       
    }

   
}
