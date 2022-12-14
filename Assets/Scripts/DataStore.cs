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
    public float HorizontalBatPos { get; private set; }
    public float VerticalBatPos { get; set; }

    public Vector3 BatScale { get; set; }


    public void SetScreenSize(Vector2 size, Camera cam)
    {
        ScreenSize = size;
        float width = size.x * 0.9f;
        float height = width * 0.7f;
        if (ScreenSize.y < height)
        {
            height = size.y * 0.9f;
            width = height * 1.3f;
        }

        Vector2 fsize = new Vector2(width + (size.x * 0.5f), height + (size.y * 0.5f));
         

        FieldSize = cam.ScreenToWorldPoint(fsize);
        FieldSize *= 0.9f;

        RightEdge = FieldSize.x * 0.5f;
        TopEdge = FieldSize.y * 0.5f;
        LeftEdge = -RightEdge;
        BottomEdge = -TopEdge;
        HorizontalBatPos = LeftEdge + 0.7f + (BatScale.x * 0.5f);
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

