using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : SingletonMonoBehaviour<SlotManager>
{
    [SerializeField] SlotHolder _holder;
    //  [SerializeField] ItemTitle titleSlot;


    private void Start()
    {

    }


    public void AddItemToSlot(ItemTitle title)
    {
        /*Debug.Log(IsCheck(title));
        if (IsCheck(title))
        {
            title.type = Type.NGANG;
            _holder.MoveItemToSlot(title);
            _holder.AddTitle(title);

            TitleManager.Instance.items.Remove(title);
            TitleManager.Instance.CheckWin();
            InitSlot(title, title.data.ID[0]);
            return;
        }*/

        if (_holder.titleSlot.type == Type.NGANG)
        {
            Debug.Log("Ngang");
            foreach (var item in title.data.ID)
            {
                if (_holder.titleSlot.data.ID[0] == item || _holder.titleSlot.data.ID[1] == item)
                {
                    _holder.MoveItemToSlot(title);
                    _holder.AddTitle(title);

                    TitleManager.Instance.items.Remove(title);
                    TitleManager.Instance.CheckWin();
                    foreach (var item2 in title.data.ID)
                    {
                        if (_holder.titleSlot.data.ID[0] != item2)
                        {
                            InitSlot(title, title.data.ID);
                            break;
                        }
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
                            InitSlot(title, title.data.ID);
                            break;
                        }
                    }
                    break;
                }
            }
        }

    }

    public void InitSlot(ItemTitle itemTitle, List<int> id)//data slot
    {
        _holder.titleSlot = itemTitle;
        itemTitle.transform.parent = _holder.transform;
        _holder.titleSlot.data.ID = id;
        _holder.titleSlot.InitTitleData(_holder.titleSlot.data, TitleManager.Instance._spriteValue);
        _holder.titleSlot.SetTouch(false);
        _holder.CheckPos();
    }

    private bool IsCheck(ItemTitle itemTitle) // check id 1-2 bằng nhau //
    {
        foreach (int id in _holder.titleSlot.data.ID)
        {
            if (itemTitle.data.ID.Contains(id))
            {
                return true;
            }
        }
        return false;
    }
}




