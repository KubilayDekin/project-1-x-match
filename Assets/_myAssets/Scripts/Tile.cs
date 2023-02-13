using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public GameObject xSprite;

	private int x;
	private int y;

	public void Initialize(int x,int y)
	{
		this.x = x;
		this.y = y;
	}

	private void OnMouseDown()
	{
		xSprite.SetActive(true);
	}
}
