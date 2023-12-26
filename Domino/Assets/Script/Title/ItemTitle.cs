using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemTitleData
{
    public int id1;
    public int id2;

    public ItemTitleData() { }

    public ItemTitleData(int id1, int id2) { this.id1 = id1; this.id2 = id2; }


}

public class ItemTitle : MonoBehaviour
{
    public ItemTitleData data;

    public bool isMouseDown;

    public Collider2D touchCollider2D;

    [SerializeField] SpriteRenderer _ava1, _ava2;

    public Type type;

    private void Start()
    {
        TitleManager.Instance.SpawmImgItem(_ava1, _ava2, data.id1, data.id2);
    }

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
        //if (TitleManager.Instance.hold.CompareIds(data.id1, data.id2))
        //{
        TitleManager.Instance.hold.AddItemToSlot(this);
        //  }
        Debug.LogError("touch");
    }
}
