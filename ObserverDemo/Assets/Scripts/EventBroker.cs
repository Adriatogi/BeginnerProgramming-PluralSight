using System;

public class EventBroker
{
    public static event Action ProjectileOutofBounds;

    public static void CallProjectileOutofBounds()
    {
        if(ProjectileOutofBounds != null)
        {
            ProjectileOutofBounds();
        }
    }
}
