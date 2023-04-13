using Godot;
using System;
using System.Collections.Generic;

public partial class HealthBar : Polygon2D
{
	[Export]
	private Health health;
	[Export]
	private int maxSize;

	private List<int> rightSide;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		rightSide = new List<int>();
		//Yeah i know this is a weird way of doing this but whatever
		for(int i = 0; i < Polygon.Length; i++)
		{
			
			if(Polygon[i].X > 0)
			{
				rightSide.Add(i);
			}
		}
		health.HealthUpdated += _UpdateHealthbar;
		_SetRightSide(maxSize);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _SetRightSide(float width)
	{
		Vector2[] points = Polygon;
		foreach(int index in rightSide)
		{	
			points[index] = new Vector2(width,points[index].Y);
		}
		Polygon = points;
	}

	private void _UpdateHealthbar(float currentHealth)
	{
		float ratio = currentHealth / health.maxHealth;
		_SetRightSide(maxSize * ratio);
	}
}
