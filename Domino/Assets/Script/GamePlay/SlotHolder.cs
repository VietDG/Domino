using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHolder : MonoBehaviour
{
    public ItemTitle titleSlot;

    private Queue<ItemTitle> gameObjectQueue = new Queue<ItemTitle>();

    private void Start()
    {
        // sinh ra 1 item luc dau game
        ItemTitle item = Instantiate(titleSlot, this.transform);
        // ItemTitleData data = new ItemTitleData(1);
        item.SetTouch(false);
    }

    public void AddItemToSlot(ItemTitle title)
    {
        MoveItemToSlot(title);
        InitSlot(title);
        EnqueueGameObject(title);
        ProcessNextGameObject();
        TitleManager.Instance.CheckWin();
    }

    public void EnqueueGameObject(ItemTitle obj)
    {
        gameObjectQueue.Enqueue(obj);
    }

    public void ProcessNextGameObject()
    {
        if (gameObjectQueue.Count <= 1) return;
        ItemTitle activeObj = gameObjectQueue.Dequeue();
        activeObj.gameObject.SetActive(false);
    }

    public void InitSlot(ItemTitle itemTitle)
    {
        this.titleSlot = itemTitle;
        itemTitle.transform.parent = this.transform;
        TitleManager.Instance.items.Remove(itemTitle);
    }

    public void MoveItemToSlot(ItemTitle itemTitle)
    {
        itemTitle.transform.DOMove(this.transform.position, 0.25f);
        //ItemSlot listCheckMatch3Slots = new ItemSlot();
        ////  List<ItemTitle> destroyList = new List<ItemTitle>();
        //Sequence mySequence = DOTween.Sequence();
        //mySequence
        // .Append(itemTitle.transform.DOMove(this.transform.position, 0.125f).SetEase(Ease.Linear).SetDelay(0.5f));
        ////  .Append(listCheckMatch3Slots.itemTitle.transform.DOScale(Vector3.one * 0.25f, 0.125f).SetEase(Ease.Linear));
    }

}


