using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : Movement
{
    
    
    private InputMaster _inputMaster;
    private Player _player;

    public void Awake()
    {
        Target = new GameObject("Target").transform;
        _player = GetComponent<Player>();
        _inputMaster = new InputMaster();
        _inputMaster.Player.Sprint.performed += ctx => Sprint(ctx.ReadValue<float>()); 

    }


    protected override void CalculateMovement(Character character) 
    {

        var move = _inputMaster.Player.Move.ReadValue<Vector2>();
        
        if (Vector3.Distance(_player.transform.position, Target.position) <= .05f)
        {
            Character.Direction directionToMove = character.direction;
            if (move.x > 0) directionToMove = Character.Direction.East;
            if (move.x < 0) directionToMove = Character.Direction.West;
            if (move.y < 0) directionToMove = Character.Direction.South;
            if (move.y > 0) directionToMove = Character.Direction.North;


            if (directionToMove == character.direction)
            {
                if (Mathf.Abs(move.x) > 0f)
                {
                    Target.position += new Vector3(move.x > 0f ? 1 : -1, 0f, 0f);
                }
                else if (Mathf.Abs(move.y) > 0f)
                {
                    Target.position += new Vector3(0f, move.y > 0f ? 1 : -1, 0f);
                }
            }
            
            character.direction = directionToMove;
            
            
        }

    }
        
    
    private void Sprint(float f)
    {
        IsSprinting = f> 0;
    }
    
    public void OnEnable()
    {
        _inputMaster.Enable();
    }

    public void OnDisable()
    {
        _inputMaster.Disable();
    }
}
