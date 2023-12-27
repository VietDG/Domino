using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemTitleData
{
    public List<int> ID;

    public ItemTitleData()
    {
        ID = new List<int>();
    }

    public ItemTitleData(List<int> ids)
    {
        this.ID = ids;
    }
}

public class ItemTitle : MonoBehaviour
{
    public ItemTitleData data;

    public bool isMouseDown;

    public Collider2D touchCollider2D;

    [SerializeField] List<SpriteRenderer> _avaLst;

    public Type type;

    private void Start()
    {

    }

    public void InitTitleData(ItemTitleData data, List<Sprite> sprite)
    {
        this.data = data;
        //  TitleManager.Instance.SpawmImgItem(_avaLst, data.ID);

        _avaLst[0].sprite = sprite[data.ID[0]];
        _avaLst[1].sprite = sprite[data.ID[1]];

        if (type == Type.NGANG)
        {
            this.transform.Rotate(0, 0, 90);
        }
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
        // if (TitleManager.Instance.hold.CompareIds(data.ID[0], data.ID[1]))
        //  {
        SlotManager.Instance.AddItemToSlot(this);

        // }
        Debug.LogError("touch");
    }
}
