using System;

public static class BusSystem
{
	#region Level Actions
	#endregion

	#region Gameplay Actions
	public static Action<int,int> OnTileMarked;
	public static void CallOnTileMarked(int x , int y) { OnTileMarked?.Invoke(x, y); }

	public static Action OnMatch;
	public static void CallOnMatch() { OnMatch?.Invoke(); }
	#endregion
}
