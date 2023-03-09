using Godot;
using System;

public partial class PhysicsMovement : Node
{
	[Export]
	public float maxSpeed;
	[Export]
	public float acceleration;
	[Export]
	public float maxAccelerationForce;


	//Velocity that input wants to achieve, persists somewhat between inputs
	private Vector2 goalVel;
	//www.youtube.com/watch?v=qdskE8PJy6Q&ab_channel=ToyfulGames
	public Vector2 GetForce(Vector2 unitMove, Vector2 currentVelocity, float mass)
	{
		//When turning 180 degrees, it takes twice as long to slow down to zero, and then speed back up in the other direction
        // when compared to running from a standstill
        //The animation curve scales the acceleration from 1-2 based on the dot product (how far away the current velocity is from the desired velocity)
		float velDot = unitMove.Dot(goalVel.Normalized());
		float accel = acceleration * _GetTurningModifier(velDot);
		
		//We want to move at max speed of our input
		Vector2 desiredVel = unitMove * maxSpeed;

		//Move goal velocity towards desired by amount allowed by acceleration
		goalVel = goalVel.MoveToward(desiredVel, accel * (float)GetPhysicsProcessDeltaTime());

		Vector2 needAccel = (goalVel - currentVelocity) / (float)GetPhysicsProcessDeltaTime();

		needAccel = needAccel.LimitLength(maxAccelerationForce * _GetTurningModifier(velDot));
		return needAccel * mass;
	}

	private float _GetTurningModifier(float dot)
	{	
		if(dot <= 0)
		{
			//Idea here is to ramp from (-1,2) to (0,1) in a way that eases into both
			return 2 * Mathf.Pow(dot, 3) + 3 * Mathf.Pow(dot, 2)  + 1;
		}
		else 
		{
			return 1;
		}
	}
}
