using Godot;
using System;
using System.Collections.Generic;

public class HitEvent
{
	public Hitbox hitbox;
	public Hurtbox hurtbox;
	public HitEvent(Hitbox hit, Hurtbox hurt)
	{
		this.hitbox = hit;
		this.hurtbox = hurt;
	}
}


//This whole system is ripped right from When Push Comes to Shove
//Good thing its my own code!
public partial class HitboxManager : Node
{
	private Dictionary<Node, List<HitEvent>> hitEvents;

	public static HitboxManager instance;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		hitEvents = new Dictionary<Node, List<HitEvent>>();
		instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CallDeferred("_SendHits");
	}


	

	public void RegisterHit(Hitbox hitbox, Hurtbox hurtbox)
	{
		if(!hitEvents.ContainsKey(hurtbox.owner))
        {
            hitEvents.Add(hurtbox.owner, new List<HitEvent>());
        }
        hitEvents[hurtbox.owner].Add(new HitEvent(hitbox, hurtbox));
	}

	private void _SendHits()
	{
		 if(hitEvents.Count > 0)
        {
            foreach(Node owner in hitEvents.Keys)
            {
                HitEvent currentEvent = null;
                foreach(HitEvent e in hitEvents[owner])
                {
                    //If hurtbox and hitbox have same owner, do not send event
                    if(e.hurtbox.owner != null && e.hurtbox.owner == e.hitbox.owner)
                    {
                        continue;
                    }
                    //If the hitbox or hurtbox ignores the other's owner, do not send event
                    if(e.hitbox.OwnersToIgnore.Contains(e.hurtbox.owner) || e.hurtbox.OwnersToIgnore.Contains(e.hitbox.owner))
                    {
                        continue;
                    }
                    //Check hurtbox priority
                    if(currentEvent == null || currentEvent.hurtbox.priority < e.hurtbox.priority)
                    {
                        currentEvent = e;
                    }

                    //Check hitbox priority, only relevant if current best event and event being checked have same hurtbox
                    if(currentEvent.hurtbox == e.hurtbox && e.hitbox.priority > currentEvent.hitbox.priority)
                    {
                        currentEvent = e;
                    }
                }
                //If we have an event to send...
                if(currentEvent != null)
                {
                    //Send it
                    currentEvent.hurtbox.handler.ProcessHit(currentEvent);
                    if(currentEvent.hitbox.handler != null)
                    {
                        currentEvent.hitbox.handler.ProcessHit(currentEvent);
                    }
                }
            }
        }
		hitEvents.Clear();
	}

	

}

