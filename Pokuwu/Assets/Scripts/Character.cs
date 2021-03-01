using Mirror;

public abstract class Character : NetworkBehaviour
{
    protected Movement _movement;
    public float speed;
    public float runspeed;

    
    public enum Direction
    {
        North,South,East,West
    }

    public Direction direction;
    
    public abstract void Awake();

    public abstract void FixedUpdate();
}
