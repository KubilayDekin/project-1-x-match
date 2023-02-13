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

	private void CheckNeighbourTiles()
	{
		int arrayLength = tiles.GetLength(0);

		foreach(Tile tile in tiles)
		{
			int markedNeighbourCount = 0;

			int x = tile.x;
			int y = tile.y;

			if (tile.isMarked)
			{
				if (x < arrayLength - 1 && tiles[x + 1, y].isMarked)
					markedNeighbourCount++;

				if (x > 0 && tiles[x - 1, y].isMarked)
					markedNeighbourCount++;

				if (y < arrayLength - 1 && tiles[x, y + 1].isMarked)
					markedNeighbourCount++;

				if (y > 0 && tiles[x, y - 1].isMarked)
					markedNeighbourCount++;

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

		int x = matchedTile.x;
		int y = matchedTile.y;

		if (x < arrayLength - 1 && tiles[x + 1, y].isMarked && !tiles[x + 1, y].isChecked)
		{
			matchedTiles.Add(tiles[x + 1, matchedTile.y]);
			FindAllMatchedTiles(tiles[x + 1, matchedTile.y]);
		}

		if (x > 0 && tiles[x - 1, y].isMarked && !tiles[x - 1, y].isChecked)
		{
			matchedTiles.Add(tiles[x - 1, y]);
			FindAllMatchedTiles(tiles[x - 1, y]);
		}

		if (matchedTile.y < arrayLength - 1 && tiles[x, y + 1].isMarked && !tiles[x, y + 1].isChecked)
		{
			matchedTiles.Add(tiles[x, y + 1]);
			FindAllMatchedTiles(tiles[x, y + 1]);
		}

		if (matchedTile.y > 0 && tiles[x, y - 1].isMarked && !tiles[x, y - 1].isChecked)
		{
			matchedTiles.Add(tiles[x, y - 1]);
			FindAllMatchedTiles(tiles[x, y - 1]);
		}

		foreach(Tile tile in matchedTiles)
		{
			tile.ResetTile();
		}

		matchedTiles.Clear();
	}
}
