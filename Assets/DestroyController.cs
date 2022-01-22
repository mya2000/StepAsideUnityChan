using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    
    private GameObject unitychan;

    

    private float difference;
    // Start is called before the first frame update
    void Start()
    {
        
        this.unitychan = GameObject.Find("unitychan");

        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, 1, this.unitychan.transform.position.z - difference);
    }

    void OnTriggerEnter(Collider other)
    {
        //è·äQï®Ç…è’ìÀÇµÇΩèÍçá
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "CoinTag")
        {
            Destroy(other.gameObject);
        }
    }

}
