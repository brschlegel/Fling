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
		//agent.TargetReached += _OnTargetReached;

		agent.TargetDesiredDistance = distanceThreshold;
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 desiredLocation = agent.GetNextPathPosition();
		
		Vector2 force = move.GetForce((desiredLocation - GlobalPosition).Normalized(), LinearVelocity, Mass);
		ApplyCentralForce(force);
		if(agent.DistanceToTarget() <= distanceThreshold)
		{
			_OnTargetReached();
		}
	  
	}

	public void SetTargetLocation(Vector2 location, bool startMoving = true)
	{
		agent.TargetPosition = location;

    }

    private void _OnTargetReached()
    {
        GD.Print("Target Reached");
        moving = false;
        EmitSignal(SignalName.TargetReached);
    }










}
