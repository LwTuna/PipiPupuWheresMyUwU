using Mirror;
using UnityEngine;

public abstract class Movement : NetworkBehaviour
{

    protected Transform Target;
    public Vector3 MoveVector { get; private set; } = new Vector3(0,0,0);
    protected bool IsSprinting = false;


    public void Move(Character character)
    {
        CalculateMovement(character);
        var position = gameObject.transform.position;
        var newPosition = Vector3.MoveTowards(position, Target.transform.position, (IsSprinting ? character.runspeed:character.speed) * Time.deltaTime);
        
        MoveVector = new Vector3(newPosition.x - position.x,newPosition.y- position.y,IsSprinting ? 1 : 0);

        if (MoveVector.x > 0) character.direction = Character.Direction.East;
        if (MoveVector.x < 0) character.direction = Character.Direction.West;
        if (MoveVector.y < 0) character.direction = Character.Direction.South;
        if (MoveVector.y > 0) character.direction = Character.Direction.North;
        
        
        
        position = newPosition;
        gameObject.transform.position = position;
    }

    protected abstract void CalculateMovement(Character character);
}
