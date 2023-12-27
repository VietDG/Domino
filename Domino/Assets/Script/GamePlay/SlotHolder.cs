using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using static UnityEngine.GraphicsBuffer;

public class SlotHolder : MonoBehaviour
{
    public ItemTitle titleSlot;

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
        ItemTitleData data = new ItemTitleData(idSlot);
        titleSlot.InitTitleData(data, TitleManager.Instance._spriteValue);
        AddTitle(titleSlot);
        //  InitSlot(titleSlot, 0);
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

    //public void InitSlot(ItemTitle itemTitle, int id)//data slot
    //{
    //    this.titleSlot = itemTitle;
    //    itemTitle.transform.parent = this.transform;
    //    this.titleSlot.data.ID[0] = id;
    //    titleSlot.SetTouch(false);

    //}

    public void MoveItemToSlot(ItemTitle itemTitle) // di chuyen vao o
    {
        Vector3 target = new Vector3(this.transform.position.x, this.transform.position.y);
        //  itemTitle.transform.DOMove(this.transform.position, 0.25f);

        Vector3 thisPos = this.transform.position;
        float height = (thisPos - target).magnitude / 2;
        Vector3 direc = (thisPos - target).normalized;
        Vector3 topPos = (thisPos + target) / 2 + new Vector3(-direc.y, direc.x) * height;

        itemTitle.transform.DORotate(new Vector3(0, 0, -360), 0.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear).OnComplete(() =>
        {
            //  titleSlot.InitTitleData(titleSlot.data, TitleManager.Instance._spriteValue);

        });
        itemTitle.transform.DOPath(new Vector3[] { thisPos, topPos, target }, 0.6f, PathType.CatmullRom).OnComplete(() =>
        {
        });
    }
}


