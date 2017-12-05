
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameItem
{
	private string itemName;
	/// <summary>
	/// Initializes a new instance of the <see cref="GameItem"/> class.
	/// </summary>
	/// <param name="itemName">Item name.</param>
	public GameItem (string itemName)
	{
		this.itemName = itemName;
	}
	/// <summary>
	/// Games the name of the item.
	/// </summary>
	/// <returns>The item name.</returns>
	public string GameItemName() {
		return this.itemName;

	}
}