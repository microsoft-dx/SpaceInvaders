using UnityEngine;
using System.Collections;

public class CollumnManager : MonoBehaviour {
    int monsters = 5;
	public float speed = 5;
	public int moveLeft	= 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var pos = transform.position;
		pos.x += moveLeft * speed * Time.deltaTime;
		transform.position = pos;
	}
	
	public void MonsterDied()
	{
        monsters--;
        if(monsters==0)
        {
            Destroy(this.gameObject);
            FindObjectOfType<GameMaster>().CollumnDied(
                int.Parse(
                    gameObject.name                     [7].ToString()
                    )
                );
        }
    }
}
