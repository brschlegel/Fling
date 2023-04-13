using Godot;
using System;

public partial class ExplodeOnReachedTarget : Node2D
{
	[Export]
	private NavRigidbody nav;
	[Export]
	private float damage;
	[Signal]
	public delegate void ExplodedEventHandler(float damage);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		nav.TargetReached += Explode;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void Explode()
	{
		EmitSignal(SignalName.Exploded, damage);
		GD.Print("we be exploding");
		nav.QueueFree();
	}
}
