using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSwapper : MonoBehaviour
{
    public Tilemap tilemap;

    public Tile grass;
    public Tile stone;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3Int gridPos = tilemap.WorldToCell(mousePos);

            Debug.Log(gridPos);

            if (tilemap.GetTile(gridPos) == stone)
            {
                Debug.Log("This is stone, turn me into grass");
                tilemap.SetTile(gridPos, grass);
            }
            else if (tilemap.GetTile(gridPos) == null)
            {
                Debug.Log("the sky");
            }
            else
            {
                Debug.Log("this is grass, turn me into stone");
                tilemap.SetTile(gridPos, stone);
            }
        }
    }
}
