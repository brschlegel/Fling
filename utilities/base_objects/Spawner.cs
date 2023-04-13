using Godot;
using System;
using System.Collections;

public partial class Spawner : Node2D
{
	[Export]
	private Node spawnParent;
	[Export]
	private PackedScene skeletonPrefab;
	[Export]
	private float timeToSpawn;
	[Export]
	private Node2D location;

	[Signal]
	public delegate void SpawnedEventHandler(NavRigidbody nav);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		WaitToSpawn();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private async void WaitToSpawn()
	{
		await ToSignal(GetTree().CreateTimer(timeToSpawn), "timeout");
		NavRigidbody instance = (NavRigidbody)skeletonPrefab.Instantiate();
		instance.GlobalPosition = location.GlobalPosition;
		spawnParent.AddChild(instance);
		EmitSignal(SignalName.Spawned, instance);
		WaitToSpawn();

	}
}
