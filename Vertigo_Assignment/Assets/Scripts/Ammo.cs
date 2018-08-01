using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    public List<int> curAmmo = new List<int>();
    public int maxAmmo = 20;

    public void AddAmmo() {
        for (int i = curAmmo.Count; i < maxAmmo; i++) {
            curAmmo.Add(1);
        }
    }

    public void RemoveAmmo() {
        if (curAmmo.Count >= 0) {
            curAmmo.Remove(1);
        }
    }
}
