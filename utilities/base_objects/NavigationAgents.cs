using Godot;
using System;
using System.Collections.Generic;

public partial class NavigationAgents : Node
{
	public List<Vector2> navPoints = new List<Vector2>();
	private List<NavRigidbody> agents;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	public void Init()
	{
		agents = new List<NavRigidbody>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//GD.Print(agents[0].GlobalPosition);
	}

	public void AgentAdded(NavRigidbody nav)
	{
		agents.Add(nav);
		nav.SetTargetLocation(navPoints[0]);
	}
}
