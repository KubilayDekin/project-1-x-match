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
		int markedNeighbourCount = 0;
		int arrayLength = tiles.GetLength(0);

		if (x < arrayLength - 1 && tiles[x + 1, y].isMarked)
		{
			markedNeighbourCount++;
		}

		if (x > 0 && tiles[x - 1, y].isMarked)
		{
			markedNeighbourCount++;
		}

		if (y < arrayLength - 1 && tiles[x, y + 1].isMarked)
		{
			markedNeighbourCount++;
		}

		if (y > 0 && tiles[x, y - 1].isMarked)
		{
			markedNeighbourCount++;
		}

		if (markedNeighbourCount > 2)
		{
			BusSystem.CallOnMatch();
		}

	}
}
