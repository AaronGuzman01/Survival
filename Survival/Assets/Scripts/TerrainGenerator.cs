using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject player;
    public Tile tile;
    private List<Vector3Int> tiles;

    // Start is called before the first frame update
    void Start()
    {
        tiles = new List<Vector3Int>();
        SetTiles();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTiles();
        SetTiles();
    }

    private void UpdateTiles()
    {
        Vector3 tilePos;

        foreach(Vector3Int tile in tiles)
        {
            if(tilemap.HasTile(tile))
            {
                tilePos = tilemap.GetCellCenterWorld(tile);

                if (Vector2.Distance(tilePos, player.transform.position) > 40f)
                {
                    tilemap.SetTile(tile, null);
                }
            }
        }

        tiles.Clear();
    }

    private void SetTiles()
    {
        Vector3Int playerCell = tilemap.WorldToCell(player.transform.position);
        Vector3Int startCell = playerCell - new Vector3Int(20, 20);

        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                if (!tilemap.HasTile(startCell + new Vector3Int(i, j)))
                {
                    tilemap.SetTile(startCell + new Vector3Int(i, j), tile);

                    if (!tiles.Contains(startCell + new Vector3Int(i, j))) {
                        tiles.Add(startCell + new Vector3Int(i, j));
                    }
                }
            }
        }
    }
}
