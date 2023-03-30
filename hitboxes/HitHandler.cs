using Godot;
using System;

public abstract partial class HitHandler : Node
{
	public abstract void ReceiveHit(HitEvent e);

	public void ProcessHit(HitEvent e)
	{
		if (e.hitbox == null || e.hurtbox == null)
		{
			return;
		}
		ReceiveHit(e);
	}
}
