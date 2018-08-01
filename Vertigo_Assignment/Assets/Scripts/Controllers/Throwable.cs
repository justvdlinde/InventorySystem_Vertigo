using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Throwable : MonoBehaviour {

    public float thrust = 10f;

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            transform.SetParent(null);
            rb.AddForce((transform.up * thrust) + (transform.forward * thrust));
            GetComponent<Throwable>().enabled = false;
        }
    }

}
