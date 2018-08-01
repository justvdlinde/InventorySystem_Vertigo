using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour {

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            Light flashLight = GetComponentInChildren<Light>();
            if (flashLight.intensity > 1) {
                flashLight.intensity = 0;
            }
            else {
                flashLight.intensity = 2;
            }
        }
    }
}
