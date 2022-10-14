using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStore
{
    public Vector2 ScreenSize { get; private set; } = Vector2.zero;
    public Vector2 FieldSize { get; private set; } = Vector2.zero;

    public float LeftEdge { get; private set; }
    public float RightEdge { get; private set; }
    public float TopEdge { get; private set; }
    public float BottomEdge { get; private set; }


    public void SetScreenSize(Vector2 size, Camera cam)
    {
        ScreenSize = size;
        float width = size.x * 0.9f;
        float height = width * 0.7f;
        if (ScreenSize.y < height)
        {
            height = ScreenSize.y * 0.9f;
            width = height * 1.3f;
        }

        FieldSize = new Vector2(width, height);

        Vector2 pos = cam.ScreenToWorldPoint(FieldSize);
        RightEdge = pos.x;
        TopEdge = pos.y;
        LeftEdge = 0;
        BottomEdge = 0;
    }

    public static DataStore Instance
    {
        get
        {
            if (instance == null) instance = new DataStore();
            return instance;
        }
    }
    private static DataStore instance;
    private DataStore() { }
}

