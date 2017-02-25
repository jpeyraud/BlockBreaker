using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    private float minSceneWidth = 0;
    private float maxSceneWidth = 8;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = new Vector3(Input.mousePosition.x / Screen.width * maxSceneWidth, transform.position.y, transform.position.z);
        newPos.x = Mathf.Clamp(newPos.x, minSceneWidth, maxSceneWidth);
        transform.position = newPos;
	}
}
