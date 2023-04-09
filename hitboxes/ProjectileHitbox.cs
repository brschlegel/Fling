using Godot;
using System;

public partial class ProjectileHitbox : Hitbox
{
	[Export]
	private RigidBody2D rigidbody;
	[Export]
	private float velThreshold = 20;

	public AttackData attackData;

	private float velToDamage = .5f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		attackData = GetNode<AttackData>("AttackData");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _PhysicsProcess(double delta)
    {
		if(rigidbody.LinearVelocity.Length() >= velThreshold)
		{
			Monitoring = true;
			attackData.strength = rigidbody.LinearVelocity.Length() * velToDamage;
		}
		else
		{
			Monitoring = false;
		}
    }
}
