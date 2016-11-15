using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public Transform player;
	public float snakeSpeed;
	public Vector2 snake;
	public Animator anim;

	void Start() 
	{
		//snake = new Vector2(0, 0);
		anim = GetComponent<Animator>();
		player = GameObject.Find("Player").transform;
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log("Collision");
		Debug.Log(collision.gameObject.name);
		if(collision.collider.name.Contains("Bandit")) 
		{
			Debug.Log("Dead");
	        Destroy(gameObject);
	        DestroyObject(collision.gameObject);
        }
    }
    void Update() 
    {
		
		//Debug.Log(Vector2.Distance(player.transform.position, transform.position));
    	if(Vector2.Distance(player.transform.position, transform.position) < 50) 
    	{
			transform.position = Vector2.MoveTowards(transform.position, player.position, snakeSpeed);	
			anim.speed = 1;
    	}
		else if(Vector2.Distance(player.transform.position, transform.position) > 500) 
    	{
			transform.position = new Vector2(0,0);	
			anim.speed = 0.2f;
    	}
    }	
}
