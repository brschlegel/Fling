using Godot;
using System;

public partial class Hurtbox : DetectionBox
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AreaEntered += _OnAreaEnter;
	}

	private void _OnAreaEnter(Area2D area)
	{	
		if(area is Hitbox)
		{
			HitboxManager.instance.RegisterHit(area as Hitbox, this);
		}
	}
}
