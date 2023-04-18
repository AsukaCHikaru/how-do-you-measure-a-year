using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableActionItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    GameObject gameObjectForDrag;
    Vector3 worldPosition;

    public void OnBeginDrag(PointerEventData eventData) {
        GameObject thisGameObject = this.gameObject;
        gameObjectForDrag = Instantiate(thisGameObject, transform.position, transform.rotation, transform.parent);
    }

    public void OnDrag(PointerEventData eventData) {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        if (gameObjectForDrag != null) {
            gameObjectForDrag.transform.localPosition = new Vector3(worldPosition.x, worldPosition.y, 0);
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        Destroy(gameObjectForDrag);
    }
}
