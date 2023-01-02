using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Events;

namespace W0NYV.nanoKON2
{

    public class NanoKON2Handler : MonoBehaviour
    {

        private const int SLIDER_COUNTS = 8; 
        private const int KNOB_COUNTS = 8; 
        private const int SOLO_BUTTON_COUNTS = 8;
        private const int MUTE_BUTTON_COUNTS = 8;
        private const int REC_BUTTON_COUNTS = 8;
        private const int TRANSPORT_BUTTON_COUNTS = 5;
        private const int FUNCTION_BUTTON_COUNTS = 6;

        private PlayerInput _input;
        [SerializeField] private NanoKON2Model _nanoKON2Model;

        // public List<UnityEvent<float>> onSoloButtonMoved = new List<UnityEvent<float>>();
        // public List<UnityEvent<float>> onMuteButtonMoved = new List<UnityEvent<float>>();
        // public List<UnityEvent<float>> onRecButtonMoved = new List<UnityEvent<float>>();
        // public List<UnityEvent<float>> onTransportButtonMoved = new List<UnityEvent<float>>();
        // public List<UnityEvent<float>> onFunctionButtonMoved = new List<UnityEvent<float>>();

        private void Awake()
        {
            TryGetComponent<PlayerInput>(out _input);
        }

        private void OnEnable() {
            
            //Slider
            for(int i = 0; i < SLIDER_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + i.ToString()].performed += (obj) => 
                    _nanoKON2Model.SliderValueList.ChangeValue(n, obj.ReadValue<float>());
            }

            //Knob
            for(int i = 0; i < KNOB_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (16+n).ToString()].performed += (obj) => 
                    _nanoKON2Model.KnobValueList.ChangeValue(n, obj.ReadValue<float>());
            }

            //SoloButton
            for(int i = 0; i < SOLO_BUTTON_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (32+n).ToString()].performed += (obj) =>
                    _nanoKON2Model.SoloButtonValueList.ChangeValue(n, obj.ReadValue<float>());
            }
            
            //MuteButton
            for(int i = 0; i < MUTE_BUTTON_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (48+n).ToString()].performed += (obj) =>
                    _nanoKON2Model.MuteButtonValueList.ChangeValue(n, obj.ReadValue<float>());
            }

            //RecButton
            for(int i = 0; i < REC_BUTTON_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (64+n).ToString()].performed += (obj) =>
                    _nanoKON2Model.RecButtonValueList.ChangeValue(n, obj.ReadValue<float>());
            }

            //TransportButton
            for(int i = 0; i < TRANSPORT_BUTTON_COUNTS; i++)
            {
                int n = i;
                string[] actionNames = {"Control43", "Control44", "Control42", "Control41", "Control45"};

                _input.actions[actionNames[n]].performed += (obj) =>
                    _nanoKON2Model.TransportButtonValueList.ChangeValue(n, obj.ReadValue<float>());
            }

            //FunctionButton
            for(int i = 0; i < FUNCTION_BUTTON_COUNTS; i++)
            {
                int n = i;
                string[] actionNames = {"Control58", "Control59", "Control46","Control60", "Control61", "Control62"};

                _input.actions[actionNames[n]].performed += (obj) =>
                    _nanoKON2Model.FunctionButtonValueList.ChangeValue(n, obj.ReadValue<float>());
            }
        }

        private void OnDisable() {
            //Slider
            for(int i = 0; i < SLIDER_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + i.ToString()].performed -= (obj) => 
                    _nanoKON2Model.SliderValueList.ChangeValue(n, obj.ReadValue<float>());
            }

            //Knob
            for(int i = 0; i < KNOB_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (16+n).ToString()].performed -= (obj) => 
                    _nanoKON2Model.KnobValueList.ChangeValue(n, obj.ReadValue<float>());
            }

            //SoloButton
            for(int i = 0; i < SOLO_BUTTON_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (32+n).ToString()].performed -= (obj) =>
                    _nanoKON2Model.SoloButtonValueList.ChangeValue(n, obj.ReadValue<float>());
            }

            //MuteButton
            for(int i = 0; i < MUTE_BUTTON_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (48+n).ToString()].performed -= (obj) =>
                    _nanoKON2Model.MuteButtonValueList.ChangeValue(n, obj.ReadValue<float>());
            }

            //RecButton
            for(int i = 0; i < REC_BUTTON_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (64+n).ToString()].performed -= (obj) =>
                    _nanoKON2Model.RecButtonValueList.ChangeValue(n, obj.ReadValue<float>());
            }


            //TransportButton
            for(int i = 0; i < TRANSPORT_BUTTON_COUNTS; i++)
            {
                int n = i;
                string[] actionNames = {"Control43", "Control44", "Control42", "Control41", "Control45"};

                _input.actions[actionNames[n]].performed -= (obj) =>
                    _nanoKON2Model.TransportButtonValueList.ChangeValue(n, obj.ReadValue<float>());
            }

            //FunctionButton
            for(int i = 0; i < FUNCTION_BUTTON_COUNTS; i++)
            {
                int n = i;
                string[] actionNames = {"Control58", "Control59", "Control46","Control60", "Control61", "Control62"};

                _input.actions[actionNames[n]].performed -= (obj) =>
                    _nanoKON2Model.FunctionButtonValueList.ChangeValue(n, obj.ReadValue<float>());
            }
        }
    }
}