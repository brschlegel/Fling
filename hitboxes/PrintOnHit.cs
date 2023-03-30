using Godot;
using System;

public partial class PrintOnHit : HitHandler
{
    public override void ReceiveHit(HitEvent e)
    {
        GD.Print("itsa me being hit");
    }
}
