using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridConstructor : MonoBehaviour
{
	public GameObject tilePrefab;
	public int gridSize;
	public float gap;

	private void Start()
	{
		CreateGrid();
	}

	private void CreateGrid()
	{
		for(int y = 0; y < gridSize; y++)
		{
			for(int x = 0; x < gridSize; x++)
			{
				GameObject newTile = Instantiate(tilePrefab, transform);
				newTile.GetComponent<Tile>().Initialize(x, y);
				newTile.transform.position = new Vector3(x * gap, 0, y * gap);
			}
		}

		RepositionCamera();
	}

	private void RepositionCamera()
	{
		Camera.main.transform.position = new Vector3((gridSize - 1) * gap / 2, (gridSize * 0.3f), (gridSize - 1) * gap / 2);
	}
}
