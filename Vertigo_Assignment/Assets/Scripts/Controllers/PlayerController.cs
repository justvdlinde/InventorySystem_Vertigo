using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    private Camera cam;
    private PlayerMotor motor;
    private GunController gun;
    private FlashlightController flashLight;

    public LayerMask movementMask;
    public Interactable focus;


    private void Start () {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
	}

    private void Update () {
        //Check if inventory is not opened
        if (EventSystem.current.IsPointerOverGameObject()) { 
            return;
        }

        //Check if a gun is equipped
        if (EquipmentManager.instance.gun != null) {
            gun = EquipmentManager.instance.gun;
            EquipmentManager.instance.gun = null;
        }

        // Left mousebutton input
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask)) {
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }

        //Right mousebutton input
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null) {
                    SetFocus(interactable);
                }
                else if (gun != null) {
                    gun.isFiring = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(1)) {
            if (gun != null) {
                gun.isFiring = false;
            }
        }
    }

    private void SetFocus(Interactable newFocus) {
        if (newFocus != focus) {
            if (focus != null) { 
                focus.OnDefocused();
            }

            focus = newFocus;
            motor.MoveToPoint(newFocus.transform.position);
        }

        newFocus.OnFocused(transform);
    }

    private void RemoveFocus() {
        if (focus != null) {
            focus.OnDefocused();
        }
        focus = null;
    }
}
