﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable {

    private PlayerManager playerManager;
    private CharacterStats myStats;

    private void Start() {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }

    public override void Interact() {
        base.Interact();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Bullet_Shell") {
            CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
            if (playerCombat != null) {
                playerCombat.Attack(myStats);
            }
        }
    }
}
