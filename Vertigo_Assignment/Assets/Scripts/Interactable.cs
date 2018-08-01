using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;
    public Transform interactionTransform;

    private bool isFocus = false;
    private bool hasInteracted = false;
    private Transform player;

    private void Update() {
        if (isFocus && !hasInteracted) {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius) {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact() {
    }

    public void OnFocused (Transform playerTransform) {
        isFocus = true;
        player = playerTransform;
    }

    public void OnDefocused() {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected() {
        if (interactionTransform == null) {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);  
    }

}
