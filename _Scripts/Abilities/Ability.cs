using System;

public class Ability
{
	public string name { get; set; }
	public string cost { get; set; }

	public Ability (string aName, string aCost)
	{
		name = aName;
		cost = aCost;
	}
}
