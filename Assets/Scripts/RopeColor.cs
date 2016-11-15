using UnityEngine;
using System.Collections;

public class RopeColor : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
