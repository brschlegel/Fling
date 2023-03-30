using Godot;
using System;
using System.Collections.Generic;

public partial class DetectionBox : Area2D
{
	[Export]
	public HitHandler handler;
	[Export]
	public int priority;
	[Export]
	public Node owner;

	protected List<Node> ownersToIgnore;

	public List<Node> OwnersToIgnore
	{
		get{
			if(ownersToIgnore == null)
			{
				ownersToIgnore = new List<Node>();
			}
			return ownersToIgnore;
		}
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

}
