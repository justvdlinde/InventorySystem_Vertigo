using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton
    public static EquipmentManager instance;

    private void Awake() {
        instance = this;
    }

    #endregion

    private Equipment[] currentEquipment;
    private GameObject[] currentMeshes;
    private Inventory inventory;
    private Ammo ammo;

    public  GunController gun;

    public delegate void OnEquipmentChange(Equipment newItem, Equipment oldItem);
    public OnEquipmentChange onEquipmentChanged;

    private void Start() {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new GameObject[numSlots];
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.U)) {
            UnequipAll();
        }
    }

    public void Equip(Equipment newItem) {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null) {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
            Destroy(currentMeshes[slotIndex].gameObject);
        }

        if (onEquipmentChanged != null) {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        GameObject newMesh = Instantiate<GameObject>(newItem.go);
        newMesh.transform.parent = inventory.slots[(int)newItem.equipSlot].transform;
        newMesh.transform.position = inventory.slots[(int)newItem.equipSlot].transform.position;
        newMesh.transform.rotation = inventory.slots[(int)newItem.equipSlot].transform.rotation;
        currentMeshes[slotIndex] = newMesh;

        if ((int)newItem.equipSlot == 1) {
            gun = newMesh.GetComponent<GunController>();

            if (newMesh.GetComponent<Throwable>()) {
                currentEquipment[1] = null;
            }
        }

        if ((int)newItem.equipSlot == 2) {
            inventory.Remove(oldItem);
            ammo = newMesh.GetComponent<Ammo>();
            ammo.AddAmmo();
        }
    }

    public void Unequip (int slotIndex) {
        if (currentEquipment[slotIndex] != null) {
            if (currentMeshes[slotIndex] != null) {
                Destroy(currentMeshes[slotIndex].gameObject);
            }
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null) {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll() {
        for (int i = 0; i < currentEquipment.Length; i++) {
            Unequip(i);
        }
    }
}
