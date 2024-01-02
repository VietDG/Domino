using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public enum Type
{
    NONE,
    NGANG,
    DOC
}

public class TitleManager : SingletonMonoBehaviour<TitleManager>
{
    public ItemTitle titlePrefab;

    public Transform Main;

    public SlotHolder hold;

    public List<Sprite> _spriteValue;

    public Tilemap tileMap;

    //public Tile tile;

    public List<ItemTitle> items = new List<ItemTitle>();

    public List<ItemTitleData> dataTitle = new List<ItemTitleData>();

    private void Start()
    {
        SpawnTitle();
    }

    public void SpawnTitle()// sinh ra data
    {
        tileMap.GetComponent<TilemapRenderer>().enabled = false;

        for (int y = tileMap.cellBounds.yMax; y >= tileMap.cellBounds.yMin; y--)
        {
            for (int x = tileMap.cellBounds.xMin; x < tileMap.cellBounds.xMax; x++)
            {
                if (tileMap.HasTile(new Vector3Int(x, y, 0)))
                {
                    int rd = Random.Range(0, _spriteValue.Count);
                    int rd1 = Random.Range(0, _spriteValue.Count);

                    List<int> id = new List<int> { rd, rd1 };
                    ItemTitle item = Instantiate(titlePrefab, Vector3.zero, Quaternion.identity, Main);

                    ItemTitleData data = new ItemTitleData(id, new Vector2Int(x, y));
                    //     tileMap.SetTile(new Vector3Int(data.pos.x, data.pos.y), tile);
                    item.SetPosTitle(new Vector3(data.pos.x, data.pos.y, 0));

                    item.InitTitleData(data, _spriteValue);
                    items.Add(item);
                    item.gameObject.name = $"{rd}--{rd1}";

                    if (data.pos.x > 0)
                    {
                        item.SetPosTitle(new Vector3(data.pos.x + 1f * (data.pos.x) / 2, data.pos.y, 0));
                    }
                    if (data.pos.x < 0)
                    {
                        item.SetPosTitle(new Vector3(data.pos.x - 1f * (-data.pos.x) / 2, data.pos.y, 0));
                    }

                    //if (data.pos.y > 0)
                    //{
                    //    item.SetPosTitle(new Vector3(data.pos.x, data.pos.y + 1f * (data.pos.y) / 2, 0));
                    //}
                    //if (data.pos.y < 0)
                    //{
                    //    item.SetPosTitle(new Vector3(data.pos.x, data.pos.y - 1f * (-data.pos.y) / 2, 0));
                    //}
                }
            }
        }
    }

    public void CheckWin()
    {
        if (items.Count == 0)
        {
            Debug.LogError("Win");
        }
    }

    private int _height = 1;
    [SerializeField] private int _width = 1;

    public void InitPos()
    {

    }
}
