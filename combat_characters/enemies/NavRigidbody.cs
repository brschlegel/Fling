using Godot;
using System;

public partial class NavRigidbody : RigidBody2D
{
	[Signal]
	public delegate void TargetReachedEventHandler();
	[Signal]
	public delegate void PathChangedEventHandler();

	[Export]
	private float distanceThreshold;

	private NavigationAgent2D agent;
	private PhysicsMovement move;
	private bool moving = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		agent = GetNode<NavigationAgent2D>("NavigationAgent2D");
		move = GetNode<PhysicsMovement>("PhysicsMovement");
		agent.TargetReached += _OnTargetReached;

		agent.TargetDesiredDistance = distanceThreshold;
	}

	public override void _PhysicsProcess(double delta)
	{
			Vector2 desiredLocation = agent.GetNextPathPosition();
			GD.Print("Taret pos: " + agent.TargetPosition);
			GD.Print()
			GD.Print(desiredLocation);
			Vector2 force = move.GetForce((desiredLocation - Position).Normalized(), LinearVelocity, Mass);
			ApplyCentralForce(force);
		
	  
	}

	public void SetTargetLocation(Vector2 location, bool startMoving = true)
	{
		agent.SetTargetPosition(location);
		moving = startMoving;
	}

	private void _OnTargetReached()
	{
		if (moving)
		{
			moving = false;
			//EmitSignal(SignalName.);
		}
	}

   








}
