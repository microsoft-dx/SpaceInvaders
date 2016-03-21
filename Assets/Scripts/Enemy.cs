using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float radius;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var bullet=FindObjectOfType<Bullet>();
        if (bullet == null)
            return;
        float x = bullet.transform.position.x - transform.position.x;
        float y = bullet.transform.position.y - transform.position.y;


        if(x*x+y*y<radius*radius)
        {
            Destroy(gameObject);
            Destroy(bullet.gameObject);
            transform.parent.GetComponent<CollumnManager>().MonsterDied();
        }
        
	}
}
