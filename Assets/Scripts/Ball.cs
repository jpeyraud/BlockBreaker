using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBall;
	private static bool hasStarted;

	public static bool HasStarted { get { return hasStarted; } }

	// Use this for initialization
	void Start () {
		hasStarted = false;
		paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBall = this.transform.position - paddle.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted) {
            this.transform.position = paddle.transform.position + paddleToBall;

            if (Input.GetMouseButtonDown(0)) {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 5f);
                hasStarted = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
		Vector2 tweak = new Vector2(Random.Range(-0.1f, 0.2f),Random.Range(0f, 0.25f));
		GetComponent<Rigidbody2D>().velocity += tweak;
        if (hasStarted) {
            GetComponent<AudioSource>().Play();
        }
    }
}
