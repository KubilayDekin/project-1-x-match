using System;

public static class BusSystem
{
	#region Level Actions
	#endregion

	#region Gameplay Actions
	public static Action OnTileMarked;
	public static void CallOnTileMarked() { OnTileMarked?.Invoke(); }

	public static Action OnMatch;
	public static void CallOnMatch() { OnMatch?.Invoke(); }
	#endregion
}
