using Godot;
using System;

public partial class HitHandlerDamage : HitHandler
{
	[Export]
	public Health health;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

    public override void ReceiveHit(HitEvent e)
    {
        AttackData data = e.hitbox.GetNode<AttackData>("AttackData");
		if(data != null)
		{
			health.TakeDamage(data.strength);
		}
    }
}
