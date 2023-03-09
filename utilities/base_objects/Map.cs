using Godot;
using System;
using System.Collections;

public partial class Map : TileMap
{
	private Node navPointParent;
	private NavigationAgents agents;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	
		navPointParent = GetNode<Node>("NavPoints");
		agents = GetNode<NavigationAgents>("NavigationAgents");
	
		foreach(Node2D n in navPointParent.GetChildren())
		{
			agents.navPoints.Add(n.Position);
		}
			agents.Init();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
