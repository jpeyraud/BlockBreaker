using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseCollider : MonoBehaviour {

    private LevelManager levelManager;

    public void Start() {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        levelManager.looseLevel();
    }
}
