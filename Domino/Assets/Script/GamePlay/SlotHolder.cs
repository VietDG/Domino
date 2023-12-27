using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHolder : MonoBehaviour
{
    public ItemTitle titleSlot;

    public ItemTitle titles;

    private Queue<ItemTitle> titleQueues = new Queue<ItemTitle>();

    public List<int> idSlot = new List<int>();

    private void Start()
    {
        SpawnSlotTitle();
    }

    /*  public bool CompareIds(int id1, int id2)
      {
          Debug.Log($"Item {id} {ida} ---- Data {id1} {id2}");
          if ((id == id1 && ida == id2) || (id == id2 && ida == id1))
          {
              id = id1;
              ida = id2;
              return true;
          }
          else if (id == id1)
          {
              id = id2;
              ida = id2;
              return true;
          }
          else if (id == id2)
          {
              id = id1;
              ida = id1;
              return true;
          }
          else if (ida == id1)
          {
              id = id2;
              ida = id2;
              return true;
          }
          else if (ida == id2)
          {
              id = id1;
              ida = id1;
              return true;
          }
          return false;
      }*/

    public void SpawnSlotTitle()
    {
        ItemTitle title = Instantiate(titles, this.transform);
        ItemTitleData data = new ItemTitleData(idSlot);
        title.InitTitleData(data);
        AddTitle(title);
        InitSlot(title, 0);
    }

    public void AddItemToSlot(ItemTitle title)
    {
        foreach (var item in title.data.ID)
        {
            if (titleSlot.data.ID[0] == item)
            {
                MoveItemToSlot(title);
                //  InitSlot(title);
                AddTitle(title);
                TitleManager.Instance.items.Remove(title);
                TitleManager.Instance.CheckWin();
                foreach (var item2 in title.data.ID)
                {
                    if (titleSlot.data.ID[0] != item2)
                    {
                        InitSlot(title, item2);
                        break;
                    }
                }
                break;
            }
        }
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

    public void InitSlot(ItemTitle itemTitle, int id)//data slot
    {
        this.titleSlot = itemTitle;
        itemTitle.transform.parent = this.transform;
        this.titleSlot.data.ID[0] = id;
        titleSlot.SetTouch(false);

    }

    public void MoveItemToSlot(ItemTitle itemTitle) // di chuyen vao o
    {
        itemTitle.transform.DOMove(this.transform.position, 0.25f);
    }
}


