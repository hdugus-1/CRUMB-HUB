using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Rendering;
using static UnityEngine.InputSystem.DefaultInputActions;

public class SelectGamepad : MonoBehaviour
{
    public List<GameObject> players;

    private void OnEnable()
    {
        ReadOnlyArray<Gamepad> gamepads = Gamepad.all;
        
        // todo: Replace this with something safe and tidy
        Debug.Assert(gamepads.Count >= players.Count);
        
        for (int i = 0; i < players.Count; i++)
        {
            InputUser user = InputUser.PerformPairingWithDevice(gamepads[i].device, new InputUser());
            
            PlayerInput player = players[i].GetComponent<PlayerInput>();
            
            // HACK: Unpair user from automatically spawned user. 
            InputUser playerUser = player.user;
            if (playerUser != null && playerUser.valid)
            {
                playerUser.UnpairDevices();
            }

            var actions = player.actions;
            actions.Enable();
            user.AssociateActionsWithUser(actions);
        }
    }
}
