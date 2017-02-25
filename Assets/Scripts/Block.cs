using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block: MonoBehaviour {

	public GameObject particle;
    public int timesHit;
    public Sprite[] hitSprites;
	public AudioClip crack;

    private LevelManager levelManager;
    private int maxHit;

    // Use this for initialization
    void Start () {
        timesHit = 0;
        maxHit = hitSprites.Length + 1;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.brickCreated();
	}

    private void OnCollisionEnter2D(Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.3f);
		
        timesHit++;
        if (timesHit >= maxHit) {
			handleBrickDestroyed();
		}
        else {
			updateSprite();
		}
    }

	private void handleBrickDestroyed() {
		GameObject smoke = Instantiate(particle, transform.position, Quaternion.identity);
		ParticleSystem.MainModule particleMain = smoke.GetComponent<ParticleSystem>().main;
		particleMain.startColor = new ParticleSystem.MinMaxGradient(gameObject.GetComponent<SpriteRenderer>().color);
		smoke.GetComponent<ParticleSystem>().Play();
		
		levelManager.brickDestroyed();
		Destroy(gameObject);
	}

	private void updateSprite() {
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]) {
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else {
			Debug.LogError("Sprite missing at index: " + spriteIndex);
		}
	}
}
