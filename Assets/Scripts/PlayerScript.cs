using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    public float time;
    public float bulletSpeed;
    public Rigidbody2D bullet;

    private Animator animator;
    Rigidbody2D rb2D;

    private float someScale;
    private bool shoot;
    private Vector2 bulletX;
   
    

    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        someScale = transform.localScale.x;
        //bullet = Resources.Load("Bullet") as GameObject;
    }

    public IEnumerator isShooting()
    {
        shoot = true;
        yield return new WaitForSeconds(time); // waits 3 seconds
        shoot = false; // will make the update method pick up 
    }


    private void Animate()
    { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("playerShoot");
            shoot = true;
            StartCoroutine(isShooting());
         	
            if(transform.localScale.x < 0) 
            {
				bulletX = new Vector2(transform.position.x, transform.position.y);
	            Rigidbody2D bulletClone = Instantiate(bullet, bulletX, transform.rotation) as Rigidbody2D;
	            bulletClone.velocity = new Vector3(-bulletSpeed, 0, transform.position.z);
	            Debug.Log("Bullet");
            }
            else 
            {
				bulletX = new Vector2(transform.position.x + 15, transform.position.y);
				Rigidbody2D bulletClone = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody2D;
	            bulletClone.velocity = new Vector3(bulletSpeed, 0, transform.position.z);
	            Debug.Log("Bullet");
            }


        }
        else if (rb2D.velocity.x != 0 || rb2D.velocity.y != 0)
        {
            animator.SetTrigger("playerWalk");
        }
        else
        {
            animator.SetTrigger("playerIdle");
        }

        if (rb2D.velocity.x > 0)
        {
            transform.localScale = new Vector2(someScale, transform.localScale.y);
        }

        else if (rb2D.velocity.x < 0)
        {
            transform.localScale = new Vector2(-someScale, transform.localScale.y);
        }

        

    }
	
	void Update () {
        Animate();
        if (!shoot)
        {
            Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);
            rb2D.velocity = moveDir;
        }
        else
        {
            rb2D.velocity = new Vector2(0,0);
        }
        //Debug.Log(animator.GetAnimatorTransitionInfo(0).IsName("playerShoot"));
        
      

    }
}
