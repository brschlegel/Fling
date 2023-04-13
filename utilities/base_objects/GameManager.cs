using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node2D
{
	[Export]
	private Health doorHealth;
	[Export]
	private Node2D spawners;
	[Export]
	private NavigationAgents agents;

	public override void _Ready()
	{
		foreach(Node n in spawners.GetChildren())
		{
			Spawner s = (Spawner)n;
			s.Spawned += _OnSkeletonSpawned;
			s.Spawned += agents.AgentAdded;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _OnSkeletonSpawned(NavRigidbody skeleton)
	{
		ExplodeOnReachedTarget exp = (ExplodeOnReachedTarget)(skeleton.FindChild("Explode"));
		exp.Exploded += _OnSkeletonExploded;
	}

	private void _OnSkeletonExploded(float damage)
	{
		doorHealth.TakeDamage(damage);
	}

	
}
