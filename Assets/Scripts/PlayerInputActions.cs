//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""bec84181-af82-4e4c-8087-b37675fa9bf7"",
            ""actions"": [
                {
                    ""name"": ""Item1"",
                    ""type"": ""Button"",
                    ""id"": ""b267775c-0e50-4d79-8d1f-bf1f1ad76fb4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Item2"",
                    ""type"": ""Button"",
                    ""id"": ""9b5b1c42-e6f3-40c1-971e-34eb277fd287"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Item3"",
                    ""type"": ""Button"",
                    ""id"": ""23c1348b-8a5a-4d25-af65-651b173f945d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Item4"",
                    ""type"": ""Button"",
                    ""id"": ""ae4efece-c0b2-490f-bc7b-1a80803006db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2b2432e9-ed87-47a9-85ad-cc5a4b7a71d4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""938ac7d5-f956-4072-9023-fdd4b01012bd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6865f834-2498-4636-8e05-703940048ff8"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""695ce294-d86f-4a2d-bf3e-92f0bd00621e"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Item1 = m_Player.FindAction("Item1", throwIfNotFound: true);
        m_Player_Item2 = m_Player.FindAction("Item2", throwIfNotFound: true);
        m_Player_Item3 = m_Player.FindAction("Item3", throwIfNotFound: true);
        m_Player_Item4 = m_Player.FindAction("Item4", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Item1;
    private readonly InputAction m_Player_Item2;
    private readonly InputAction m_Player_Item3;
    private readonly InputAction m_Player_Item4;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Item1 => m_Wrapper.m_Player_Item1;
        public InputAction @Item2 => m_Wrapper.m_Player_Item2;
        public InputAction @Item3 => m_Wrapper.m_Player_Item3;
        public InputAction @Item4 => m_Wrapper.m_Player_Item4;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Item1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem1;
                @Item1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem1;
                @Item1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem1;
                @Item2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem2;
                @Item2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem2;
                @Item2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem2;
                @Item3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem3;
                @Item3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem3;
                @Item3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem3;
                @Item4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem4;
                @Item4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem4;
                @Item4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem4;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Item1.started += instance.OnItem1;
                @Item1.performed += instance.OnItem1;
                @Item1.canceled += instance.OnItem1;
                @Item2.started += instance.OnItem2;
                @Item2.performed += instance.OnItem2;
                @Item2.canceled += instance.OnItem2;
                @Item3.started += instance.OnItem3;
                @Item3.performed += instance.OnItem3;
                @Item3.canceled += instance.OnItem3;
                @Item4.started += instance.OnItem4;
                @Item4.performed += instance.OnItem4;
                @Item4.canceled += instance.OnItem4;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnItem1(InputAction.CallbackContext context);
        void OnItem2(InputAction.CallbackContext context);
        void OnItem3(InputAction.CallbackContext context);
        void OnItem4(InputAction.CallbackContext context);
    }
}
