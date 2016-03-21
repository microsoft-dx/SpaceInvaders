using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    GameObject monster;
    public int colSize;
    public bool[] coll;
    public int right;
    public int left;

    void Awake()
    {
        Screen.SetResolution(500, 500, false);


        monster = Resources.Load<GameObject>("Monster");
        coll = new bool[colSize];
        for (int i = 0; i < colSize; i++)
        {
            CreateColumn(i);
            coll[i] = true;
        }
        left = 0;
        right = colSize - 1;

    }

    void CreateColumn(int i)
    {
        var collumn = new GameObject("Collumn" + i);
        collumn.AddComponent<CollumnManager>();
        float width=0;
        for(int y=0;y<5;y++)
        {
            var active=Instantiate(monster) as GameObject;
            var height = active.GetComponent<SpriteRenderer>().bounds.extents.y*2;
            width= active.GetComponent<SpriteRenderer>().bounds.extents.x * 2;
            active.transform.parent = collumn.transform;
            var pos = active.transform.position;
            pos.y = (5 - y*1.2f) * height;
            pos.x = 0;
            pos.z = 0;
            active.transform.position = pos;
        }
        var colPos = collumn.transform.position;
        colPos.y = 0;
        colPos.x = ((colSize*1.2f - 1) / 2 - i*1.2f) * width*-1.5f;
        colPos.z = 0;
        collumn.transform.position = colPos;
        
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CollumnManager [] coloana = FindObjectsOfType<CollumnManager> ();
		for (int i = 0; i < coloana.Length; i++) {
				var posit = coloana[i].transform.position;
				var limit = Camera.main.orthographicSize * Camera.main.aspect;
				var renderer = monster.GetComponent<SpriteRenderer>();
				var bound = renderer.bounds.extents.x;

				posit.x = Mathf.Clamp (posit.x, -limit + bound, limit - bound);
				coloana[i].transform.position = posit;

				if (posit.x == limit - bound || posit.x == -limit + bound) {
							for (int j = 0; j < coloana.Length; j++) 	
								coloana[j].moveLeft *= -1;
						}
		}
		if(left==-1)
		{
			Debug.Log("You WON!");
		}
	}

    public void CollumnDied(int i)
    {
        coll[i] = false;
        left = -1;
        for(int y=0;y<colSize;y++)
        {
            if(coll[y]==true)
            {
                left = y;
                break;
            }
        }
        for (int y = colSize-1; y >= 0; y--)
        {
            if (coll[y] == true)
            {
                right = y;
                break;
            }
        }
    }
}
