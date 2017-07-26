using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {


    // private int maxHits;
    public AudioClip BrickHit;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;
    // Use this for initialization
    void Start ()
    {
        isBreakable = (this.tag == "Breakable");
        // keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnCollisionExit2D(Collision2D col)
    {
        AudioSource.PlayClipAtPoint(BrickHit, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }

    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }else
        {
            Debug.LogError("Brick Sprite Missing");
        }
    }

}
