using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private TitleManager _titleManager;
    public TitleManager TitleManager => _titleManager;
    public Camera _camera;


    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        InitScreen();
    }

    private void InitScreen()
    {
        // Đặt tỷ lệ khung hình của camera.
        var (center, size) = CalculateOrthoSize();
        _camera.transform.position = center;
        _camera.orthographicSize = size;
        // _pointTrans.transform.position = new Vector3(0, _camera.orthographicSize - 13.65f, 0);
    }

    private (Vector3 center, float size) CalculateOrthoSize()
    {
        var bounds = new Bounds();

        foreach (var col in FindObjectsOfType<Collider>())
        {
            bounds.Encapsulate(col.bounds);
        }
        bounds.Expand(5.6f);

        var vertical = bounds.size.y * _camera.pixelWidth / _camera.pixelHeight;
        var horizontal = bounds.size.x * _camera.pixelHeight / _camera.pixelWidth;

        var size = Mathf.Max(horizontal, vertical) * 0.5f;
        var center = bounds.center + new Vector3(0, 0, -10);

        return (center, size);
    }

}

