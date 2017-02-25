using UnityEngine;
using System.Collections;

public class ParticleAutoDestroy: MonoBehaviour {

	void Start() {
		var particle = GetComponent<ParticleSystem>();
		if (particle) {
			Destroy(gameObject, particle.main.duration + particle.main.startLifetime.constantMax);
		}
	}

}