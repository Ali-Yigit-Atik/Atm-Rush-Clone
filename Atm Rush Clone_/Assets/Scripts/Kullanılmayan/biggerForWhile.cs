using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biggerForWhile : MonoBehaviour
{
    public bool isNeedToBeBigger = false;

    private GameObject player;
    private List<GameObject> moneys_;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moneys_ = player.GetComponent<playerController>().moneys;
    }

    private void Update()
    {
        if(isNeedToBeBigger == true)
        {
            StartCoroutine(biggerForWhile_());
        }
    }

    IEnumerator biggerForWhile_()
    {





        //isNeedToBeBigger = false;
        //
        //
        //gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);        
        //yield return new WaitForSeconds(0.05f);        
        //gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

        for (int i = 0; i < moneys_.Count; i++)
        {
    
            //var Xscale = moneys_[i].gameObject.transform.localScale.x * scaleFactor;
            //var Ysacle = moneys_[i].gameObject.transform.localScale.y * scaleFactor;
            //var Zscale = moneys_[i].gameObject.transform.localScale.z * scaleFactor;
            //
            //var XscaleOld = moneys_[i].gameObject.transform.localScale.x / scaleFactor;
            //var YsacleOld = moneys_[i].gameObject.transform.localScale.y / scaleFactor;
            //var ZscaleOld = moneys_[i].gameObject.transform.localScale.z / scaleFactor;
    
            moneys_[moneys_.Count -i-1].gameObject.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
            yield return new WaitForSeconds(0.05f);
            moneys_[moneys_.Count-i-1].gameObject.transform.localScale = new Vector3(0.75f,0.75f,0.75f);
        }


    }
}
