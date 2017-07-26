using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    private Paddle paddle;

    private bool hasStarted = false;
    private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
            // lock the ball relative to the paddle
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
            // waiting for mouse click to launch
            if (Input.GetMouseButtonDown(0))
            {
                print(" Mouse Clicked, launch ball");
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
        if (hasStarted)
        {
            if (this.transform.position.x >= 15.85f)
            {
                this.transform.position = new Vector2(15.80f, this.transform.position.y);
            }
            else if (this.transform.position.x <= 0.15f)
            {
                this.transform.position = new Vector2(0.20f, this.transform.position.y);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted)
        {
            if (collision.gameObject.tag != "Breakable")
            {
                GetComponent<AudioSource>().Play();
            }

            // moved vector tweak directly to paddle only for velocity adjust
            if (collision.gameObject.tag == "Paddle")
            {  
                // GetComponent<Rigidbody2D>().velocity += tweak;
                // print("paddle tweak" + tweak);
            }
        }
        GetComponent<Rigidbody2D>().velocity += tweak;
        print("paddle tweak" + tweak);
    }
}
