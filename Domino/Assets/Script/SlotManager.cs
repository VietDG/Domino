using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : SingletonMonoBehaviour<SlotManager>
{
    [SerializeField] SlotHolder _holder;
    [SerializeField] ItemTitle titleSlot;


    private void Start()
    {

    }


    public void AddItemToSlot(ItemTitle title)
    {
        //if ()

        if (titleSlot.type == Type.NGANG)
        {
            Debug.Log("Ngang");
            _holder.MoveItemToSlot(title);
            _holder.AddTitle(title);

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
            return;
        }

        if (titleSlot.type == Type.DOC)
        {
            Debug.Log("Doc");
            foreach (var item in title.data.ID)
            {
                if (titleSlot.data.ID[0] == item)
                {
                    _holder.MoveItemToSlot(title);
                    _holder.AddTitle(title);

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
    }

    public void InitSlot(ItemTitle itemTitle, int id)//data slot
    {
        this.titleSlot = itemTitle;
        itemTitle.transform.parent = this.transform;
        this.titleSlot.data.ID[0] = id;
        titleSlot.InitTitleData(titleSlot.data, TitleManager.Instance._spriteValue);
        titleSlot.SetTouch(false);

    }
}
