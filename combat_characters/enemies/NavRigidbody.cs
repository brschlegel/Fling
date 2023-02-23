using Godot;
using System;

public partial class NavRigidbody : RigidBody2D
{
	private NavigationAgent2D agent;
	private float maxSpeed = 40;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		agent = GetNode<NavigationAgent2D>("NavigationAgent2D");
	}

    public override void _PhysicsProcess(double delta)
    {
		Vector2 desiredLocation = agent.GetNextLocation();

		LinearVelocity = (desiredLocation - Position).Normalized() * maxSpeed;
    }
}
