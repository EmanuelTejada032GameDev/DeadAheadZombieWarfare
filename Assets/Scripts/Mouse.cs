// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Mouse.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Mouse : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Mouse()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Mouse"",
    ""maps"": [
        {
            ""name"": ""MouseActions"",
            ""id"": ""fbe16515-687b-48d0-b0fd-ee613a22bf53"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""4f893c39-a00a-47e9-9cab-07d5829e38e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""PassThrough"",
                    ""id"": ""10d9b375-1986-488d-9e07-8ae0c21b5d22"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f5a62da9-56cd-477a-9af1-a61163c3c559"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32517697-e9d9-4d4d-a1ae-c9088afcf054"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MouseActions
        m_MouseActions = asset.FindActionMap("MouseActions", throwIfNotFound: true);
        m_MouseActions_Click = m_MouseActions.FindAction("Click", throwIfNotFound: true);
        m_MouseActions_Position = m_MouseActions.FindAction("Position", throwIfNotFound: true);
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

    // MouseActions
    private readonly InputActionMap m_MouseActions;
    private IMouseActionsActions m_MouseActionsActionsCallbackInterface;
    private readonly InputAction m_MouseActions_Click;
    private readonly InputAction m_MouseActions_Position;
    public struct MouseActionsActions
    {
        private @Mouse m_Wrapper;
        public MouseActionsActions(@Mouse wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_MouseActions_Click;
        public InputAction @Position => m_Wrapper.m_MouseActions_Position;
        public InputActionMap Get() { return m_Wrapper.m_MouseActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActionsActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActionsActions instance)
        {
            if (m_Wrapper.m_MouseActionsActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_MouseActionsActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_MouseActionsActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_MouseActionsActionsCallbackInterface.OnClick;
                @Position.started -= m_Wrapper.m_MouseActionsActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_MouseActionsActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_MouseActionsActionsCallbackInterface.OnPosition;
            }
            m_Wrapper.m_MouseActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
            }
        }
    }
    public MouseActionsActions @MouseActions => new MouseActionsActions(this);
    public interface IMouseActionsActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
    }
}
