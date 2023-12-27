using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class SlotManager : SingletonMonoBehaviour<SlotManager>
{
    [SerializeField] SlotHolder _holder;
    //  [SerializeField] ItemTitle titleSlot;


    private void Start()
    {

    }


    public void AddItemToSlot(ItemTitle title)
    {
        if (_holder.titleSlot.type == Type.NGANG)
        {
            Debug.Log("Ngang");
            _holder.MoveItemToSlot(title);
            _holder.AddTitle(title);

            TitleManager.Instance.items.Remove(title);
            TitleManager.Instance.CheckWin();
            foreach (var item2 in title.data.ID)
            {
                if (_holder.titleSlot.data.ID[0] != item2)
                {
                    if (_holder.titleSlot.data.ID[0] != item2)
                    {
                        InitSlot(title, item2);
                        break;
                    }
                }
            }
            return;
        }
        if (_holder.titleSlot.type == Type.DOC)
        {
            Debug.Log("Doc");
            foreach (var item in title.data.ID)
            {
                if (_holder.titleSlot.data.ID[0] == item)
                {
                    _holder.MoveItemToSlot(title);
                    _holder.AddTitle(title);

                    TitleManager.Instance.items.Remove(title);
                    TitleManager.Instance.CheckWin();
                    foreach (var item2 in title.data.ID)
                    {
                        if (_holder.titleSlot.data.ID[0] != item2)
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
        _holder.titleSlot = itemTitle;
        itemTitle.transform.parent = _holder.transform;
        _holder.titleSlot.data.ID[0] = id;
        _holder.titleSlot.InitTitleData(_holder.titleSlot.data, TitleManager.Instance._spriteValue);
        _holder.titleSlot.SetTouch(false);
        _holder.CheckPos();

    }
}




