using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SlotScript : MonoBehaviour, IDropHandler
{
    public int id;
    public Color startColor;

    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("Item Dropped");
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<DragAndDrop>().id == id)
            {
                GetComponent<Image>().color = Color.green;
                Debug.Log("Correct!");
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
            }
            else
            {

                GetComponent<Image>().color = Color.red;
                Debug.Log("Wrong!");
                eventData.pointerDrag.GetComponent<DragAndDrop>().ResetPosition();
            }
        }
    }

}
