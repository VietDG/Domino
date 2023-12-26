using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHolder : MonoBehaviour
{
    public ItemTitle titleSlot;

    public ItemTitle titles;

    private Queue<ItemTitle> titleQueues = new Queue<ItemTitle>();

    public int id, ida;

    public SpriteRenderer _ava, ava1;

    private void Start()
    {
        SpawnSlotTitle();
    }

    public void SpawnSlotTitle()
    {
        ItemTitle title = Instantiate(titles, this.transform);
        ItemTitleData data = new ItemTitleData(id, ida);
        title.InitTitleData(data);
        AddTitle(title);
        InitSlot(title);
    }

    public void AddItemToSlot(ItemTitle title)
    {
        MoveItemToSlot(title);
        InitSlot(title);
        AddTitle(title);
        TitleManager.Instance.items.Remove(title);
        TitleManager.Instance.CheckWin();
    }

    public void AddTitle(ItemTitle obj)// them vao
    {
        titleQueues.Enqueue(obj);
        RemoveTitle();
    }

    public void RemoveTitle()// xoa o sau
    {
        if (titleQueues.Count <= 1) return;
        ItemTitle activeObj = titleQueues.Dequeue();
        activeObj.gameObject.SetActive(false);
    }

    public void InitSlot(ItemTitle itemTitle)//data slot
    {
        this.titleSlot = itemTitle;
        itemTitle.transform.parent = this.transform;
        this.titleSlot.data = itemTitle.data;
        titleSlot.SetTouch(false);

    }

    public void MoveItemToSlot(ItemTitle itemTitle) // di chuyen vao o
    {
        itemTitle.transform.DOMove(this.transform.position, 0.25f);
    }
}


