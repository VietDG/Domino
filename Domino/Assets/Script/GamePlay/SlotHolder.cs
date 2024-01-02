using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class SlotHolder : MonoBehaviour
{
    public ItemTitle titleSlot;

    private Queue<ItemTitle> titleQueues = new Queue<ItemTitle>();

    public List<int> idSlot = new List<int>();

    public Transform trans;

    private void Start()
    {
        SpawnSlotTitle();
    }

    public void SpawnSlotTitle()
    {
        ItemTitleData data = new ItemTitleData(idSlot, new Vector2Int(0, 0));
        titleSlot.InitTitleData(data, TitleManager.Instance._spriteValue);
        AddTitle(titleSlot);
        CheckPos();
    }

    public void AddTitle(ItemTitle obj)// them vao
    {
        titleQueues.Enqueue(obj);
        RemoveTitle();
    }

    public void CheckPos()
    {
        if (titleSlot.type == Type.NGANG)
        {
            titleSlot.transform.position = trans.transform.position;
            titleSlot.transform.Rotate(0, 0, 90);
            titleSlot.transform.position += new Vector3(0, 0.5f, 0);
        }
    }

    public void RemoveTitle()// xoa o sau
    {
        if (titleQueues.Count <= 1) return;
        ItemTitle activeObj = titleQueues.Dequeue();
        activeObj.gameObject.SetActive(false);
    }

    public void MoveItemToSlot(ItemTitle itemTitle) // di chuyen vao o
    {
        //  Vector3 target = new Vector3(trans.transform.position.x, trans.transform.position.y);
        itemTitle.transform.DOMove(trans.transform.position, 0.25f);

        //Vector3 thisPos = this.transform.position;
        //float height = (thisPos - target).magnitude / 2;
        //Vector3 direc = (thisPos - target).normalized;
        //Vector3 topPos = (thisPos + target) / 2 + new Vector3(-direc.y, direc.x) * height;

        //itemTitle.transform.DORotate(new Vector3(0, 0, -360), 0.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear).OnComplete(() =>
        //{
        //    //  titleSlot.InitTitleData(titleSlot.data, TitleManager.Instance._spriteValue);

        //});
        //itemTitle.transform.DOPath(new Vector3[] { thisPos, topPos, target }, 0.6f, PathType.CatmullRom).OnComplete(() =>
        //{
        //});
    }

    public void MoveItemNgang(ItemTitle itemTitle)
    {
        itemTitle.transform.DOMove(new Vector3(trans.transform.position.x, trans.position.y + 0.5f), 1f).OnComplete(() =>
        {
            //   InitTitleDataToSlot(itemTitle);

        });
    }

    public void InitTitleDataToSlot(ItemTitle itemTitle)
    {
        titleSlot = itemTitle;
        itemTitle.transform.parent = trans.transform;
        titleSlot.data = itemTitle.data;

        titleSlot.SetTouch(false);
        CheckPos();
    }

    public void RemoveDataFormList(ItemTitle itemTitle, bool isNgang)
    {
        AddTitle(itemTitle);
        TitleManager.Instance.items.Remove(itemTitle);
        if (isNgang)
        {
            MoveItemNgang(itemTitle);
            return;
        }
        MoveItemToSlot(itemTitle);
    }
}


