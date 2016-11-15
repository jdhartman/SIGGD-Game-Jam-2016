using UnityEngine;
using System.Collections;

public class DepthController : MonoBehaviour {


    public Transform player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	    if(player.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z - 1);
        }
        else {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + 1);
        }
	}
}
