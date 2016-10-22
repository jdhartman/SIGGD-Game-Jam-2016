using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;

    Rigidbody2D rb2D;

	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);
        rb2D.velocity = moveDir;
	}
}
