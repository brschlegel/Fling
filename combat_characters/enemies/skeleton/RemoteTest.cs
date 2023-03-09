using Godot;
using System;

public partial class RemoteTest : RemoteTransform2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GD.Print("Local position: " + Position);
		GD.Print("Global Position: " + GlobalPosition);
		GD.Print("REMOTE PATH: " + RemotePath);
		GD.Print("Parental Position: " + ((Node2D)GetNode(RemotePath)).Position);
	}
}
