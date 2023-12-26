using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class ItemTitleData
{
    public int id;

    public ItemTitleData() { }

    public ItemTitleData(int id) { this.id = id; }

}

public class ItemTitle : MonoBehaviour
{
    public ItemTitleData data;

    public bool isMouseDown;

    public Collider2D touchCollider2D;

    public void InitTitleData(ItemTitleData data)
    {
        this.data = data;
    }

    public void OnMouseDown()
    {
        isMouseDown = true;
        TouchItem();
    }

    public void OnMouseUp()
    {
        if (isMouseDown)
        {
            isMouseDown = false;
        }
    }

    public void SetTouch(bool isTouch)
    {
        touchCollider2D.enabled = isTouch;
    }

    public void TouchItem()
    {
        TitleManager.Instance.hold.AddItemToSlot(this);
        TitleManager.Instance.items.Remove(this);
        //GameManager.Instance.TitleManager.hold.AddItemToSlot(this);
        //GameManager.Instance.TitleManager.items.Remove(this);
    }
}
