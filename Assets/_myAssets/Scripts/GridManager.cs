using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
	public Tile[,] tiles;

	private HashSet<Tile> matchedTiles = new HashSet<Tile>();

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

			if (tile.isMarked)
			{
				if (tile.x < arrayLength - 1 && tiles[tile.x + 1, tile.y].isMarked)
				{
					markedNeighbourCount++;
				}

				if (tile.x > 0 && tiles[tile.x - 1, tile.y].isMarked)
				{
					markedNeighbourCount++;
				}

				if (tile.y < arrayLength - 1 && tiles[tile.x, tile.y + 1].isMarked)
				{
					markedNeighbourCount++;
				}

				if (tile.y > 0 && tiles[tile.x, tile.y - 1].isMarked)
				{
					markedNeighbourCount++;
				}

				if (markedNeighbourCount >= 2)
				{
					FindAllMatchedTiles(tile);
					break;
				}
			}
		}
	}

	private void FindAllMatchedTiles(Tile matchedTile)
	{
		int arrayLength = tiles.GetLength(0);

		matchedTiles.Add(matchedTile);

		matchedTile.isChecked = true;

		if (matchedTile.x < arrayLength - 1 && tiles[matchedTile.x + 1, matchedTile.y].isMarked && !tiles[matchedTile.x + 1, matchedTile.y].isChecked)
		{
			matchedTiles.Add(tiles[matchedTile.x + 1, matchedTile.y]);
			FindAllMatchedTiles(tiles[matchedTile.x + 1, matchedTile.y]);
		}

		if (matchedTile.x > 0 && tiles[matchedTile.x - 1, matchedTile.y].isMarked && !tiles[matchedTile.x - 1, matchedTile.y].isChecked)
		{
			matchedTiles.Add(tiles[matchedTile.x - 1, matchedTile.y]);
			FindAllMatchedTiles(tiles[matchedTile.x - 1, matchedTile.y]);
		}

		if (matchedTile.y < arrayLength - 1 && tiles[matchedTile.x, matchedTile.y + 1].isMarked && !tiles[matchedTile.x, matchedTile.y + 1].isChecked)
		{
			matchedTiles.Add(tiles[matchedTile.x, matchedTile.y + 1]);
			FindAllMatchedTiles(tiles[matchedTile.x, matchedTile.y + 1]);
		}

		if (matchedTile.y > 0 && tiles[matchedTile.x, matchedTile.y - 1].isMarked && !tiles[matchedTile.x, matchedTile.y - 1].isChecked)
		{
			matchedTiles.Add(tiles[matchedTile.x, matchedTile.y - 1]);
			FindAllMatchedTiles(tiles[matchedTile.x, matchedTile.y - 1]);
		}

		foreach(Tile tile in matchedTiles)
		{
			tile.ResetTile();
		}

		matchedTiles.Clear();
	}
}
