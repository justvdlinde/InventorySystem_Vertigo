using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;

    private void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Enemy") {
            Destroy(gameObject);
        }
    }
}
