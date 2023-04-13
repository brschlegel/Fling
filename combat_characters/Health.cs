using Godot;
using System;

public partial class Health : Node
{
	[Export]
	public float currentHealth;
	[Export]
	public float maxHealth;
	[Export]
	public Node root;

	[Signal]
	public delegate void DiedEventHandler();
	[Signal]
	public delegate void HealthUpdatedEventHandler(float currentHealth);

	public override void _Ready()
	{
		currentHealth = maxHealth;
	}

	public float TakeDamage(float damage)
	{
		currentHealth -= damage;
		if(currentHealth < 0)
		{
			currentHealth = 0;
			Die();
		}

		EmitSignal(SignalName.HealthUpdated, currentHealth);
		GD.Print("Oofy Ouchie that hurt by this much: " + damage + " and my health is now: " + currentHealth);
		return currentHealth;
	}

	public void Die()
	{
		EmitSignal(SignalName.Died);
		root.QueueFree();
	}
}
