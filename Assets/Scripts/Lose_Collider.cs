using UnityEngine;
using System.Collections;

public class Lose_Collider : MonoBehaviour {

    public LevelManager levelManager;

    void OnTriggerEnter2D(Collider2D trigger)
    {
        print("Trigger");
        levelManager.LoadLevel("Win");
    }
    void OnCollisionEnter2D(Collision2D Collision)
    {
        print("Collision");
    }
}
