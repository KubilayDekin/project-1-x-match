using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public GameObject xSprite;

	[HideInInspector]
	public bool isMarked, isChecked;
	[HideInInspector]
	public int x, y;

	private void OnEnable()
	{
		BusSystem.OnMatch += ResetTile;
	}

	private void OnDisable()
	{
		BusSystem.OnMatch -= ResetTile;
	}

	public void Initialize(int x,int y)
	{
		this.x = x;
		this.y = y;
	}

	private void OnMouseDown()
	{
		if (isMarked)
			return;

		isMarked = true;
		xSprite.SetActive(true);
		BusSystem.CallOnTileMarked();
	}

	public void ResetTile()
	{
		isMarked = false;
		isChecked = false;
		xSprite.SetActive(false);
	}
}
