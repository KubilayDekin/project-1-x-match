using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
	public Tile[,] tiles;

	private void OnEnable()
	{
		BusSystem.OnTileMarked += CheckNeighbourTiles;
	}

	private void OnDisable()
	{
		BusSystem.OnTileMarked -= CheckNeighbourTiles;
	}

	private void CheckNeighbourTiles(int x, int y)
	{
		int arrayLength = tiles.GetLength(0);

		foreach(Tile tile in tiles)
		{
			int markedNeighbourCount = 0;
			List<Tile> matchedTiles = new List<Tile>();

			if (tile.isMarked)
			{
				matchedTiles.Add(tile);

				if (tile.x < arrayLength - 1 && tiles[tile.x + 1, tile.y].isMarked)
				{
					markedNeighbourCount++;
					matchedTiles.Add(tiles[tile.x + 1, tile.y]);
				}

				if (tile.x > 0 && tiles[tile.x - 1, tile.y].isMarked)
				{
					markedNeighbourCount++;
					matchedTiles.Add(tiles[tile.x - 1, tile.y]);
				}

				if (tile.y < arrayLength - 1 && tiles[tile.x, tile.y + 1].isMarked)
				{
					markedNeighbourCount++;
					matchedTiles.Add(tiles[tile.x, tile.y + 1]);
				}

				if (tile.y > 0 && tiles[tile.x, tile.y - 1].isMarked)
				{
					markedNeighbourCount++;
					matchedTiles.Add(tiles[tile.x, tile.y - 1]);
				}

				if (markedNeighbourCount >= 2)
				{
					for(int i = 0; i < matchedTiles.Count; i++)
						matchedTiles[i].ResetTile();

					matchedTiles.Clear();

					break;
				}
			}
		}
	}
}
