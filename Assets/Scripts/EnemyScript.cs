using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public Transform player;
	public float snakeSpeed;
	public Vector2 snake;
	public Animator anim;

	private float someScale;

	void Start() 
	{
		//snake = new Vector2(0, 0);
		anim = GetComponent<Animator>();
		player = GameObject.Find("Player").transform;
		someScale = transform.localScale.x;
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log("Collision");
		Debug.Log(collision.gameObject.name);
		if(collision.collider.name.Contains("Player")) 
		{
			Debug.Log("Dead");
	        
	        DestroyObject(collision.gameObject);
			Destroy(gameObject);
        }
    }
    void Update() 
    {
		
		//Debug.Log(Vector2.Distance(player.transform.position, transform.position));
    	if(Vector2.Distance(player.transform.position, transform.position) < 50) 
    	{
    		if(transform.position.x > player.position.x) 
    		{
				transform.localScale = new Vector2(someScale, transform.localScale.y);	
    		}
    		else 
    		{
				transform.localScale = new Vector2(-someScale, transform.localScale.y);
    		}
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
