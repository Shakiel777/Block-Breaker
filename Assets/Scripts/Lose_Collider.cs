using UnityEngine;
using System.Collections;

public class Lose_Collider : MonoBehaviour {

    private LevelManager levelManager;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        levelManager.LoadLevel("Lose");
    }
    void OnCollisionEnter2D(Collision2D Collision)
    {
        print("Collision");
    }
}
