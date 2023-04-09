using Godot;
using System;

public partial class HitEventSplitter : HitHandler
{
    public override void ReceiveHit(HitEvent e)
    {
        foreach(Node n in GetChildren())
		{
			if(n is HitHandler)
			{
				((HitHandler)n).ProcessHit(e);
			}
		}
    }
}
