using UnityEngine;
using System.Collections;

public class bulletCreate : MonoBehaviour {

	void OnBecameInvisible()
  {
     DestroyObject(gameObject);
  }

	


}
