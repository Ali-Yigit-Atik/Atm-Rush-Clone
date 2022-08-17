using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private bool isMoved = false;
    public int sweepSpeed =5;
    public int  speed =5;
    private Collider roadCollider;
    public static float minXLimit;
    public static float maxXLimit;
    public static float midOfRoad;
    public static bool isHitObstacle = false;
    public List<GameObject> moneys = new List<GameObject>();

    void Start()
    {
        roadCollider = GameObject.FindGameObjectWithTag("road").GetComponent<Collider>();
        midOfRoad = roadCollider.bounds.center.x;
        minXLimit = roadCollider.bounds.center.x - roadCollider.bounds.size.x/2;
        maxXLimit = roadCollider.bounds.center.x + roadCollider.bounds.size.x / 2;
        //moneys = null;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && isHitObstacle ==false)
        {
            isMoved = true;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitPosition, 100))
            {
                Vector3 SweepPosition = hitPosition.point;

                SweepPosition.y = transform.position.y;
                SweepPosition.z = transform.position.z;

               
                var playerPos = transform.position;

                playerPos = Vector3.MoveTowards(gameObject.transform.position, SweepPosition, Time.deltaTime * sweepSpeed);

                playerPos.x = Mathf.Clamp(playerPos.x, minXLimit, maxXLimit);

                transform.position = playerPos;

            }
        }

        if (isMoved && isHitObstacle == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * speed);
        }
        
    }
}
