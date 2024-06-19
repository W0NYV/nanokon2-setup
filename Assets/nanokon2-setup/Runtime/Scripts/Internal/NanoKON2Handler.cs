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

        private PlayerInput _input;

        private void Awake()
        {
            TryGetComponent<PlayerInput>(out _input);
        }

        private void OnEnable() {
            
            //Slider
            for(int i = 0; i < ControllerCounts.SLIDER_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + i.ToString()].performed += (obj) => 
                {
                    NanoKON2Model.instance.guiModel.SliderValueList.ChangeValue(n, obj.ReadValue<float>());
                    NanoKON2Model.instance.model.SliderValueList.ChangeValue(n, obj.ReadValue<float>());
                };
            }

            //Knob
            for(int i = 0; i < ControllerCounts.KNOB_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (16+n).ToString()].performed += (obj) => 
                {
                    NanoKON2Model.instance.guiModel.KnobValueList.ChangeValue(n, obj.ReadValue<float>());
                    NanoKON2Model.instance.model.KnobValueList.ChangeValue(n, obj.ReadValue<float>());
                };
            }

            //SoloButton
            for(int i = 0; i < ControllerCounts.SOLO_BUTTON_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (32+n).ToString()].performed += (obj) => 
                {
                    NanoKON2Model.instance.guiModel.SoloButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                    NanoKON2Model.instance.model.SoloButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                };
            }
            
            //MuteButton
            for(int i = 0; i < ControllerCounts.MUTE_BUTTON_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (48+n).ToString()].performed += (obj) =>
                {
                    NanoKON2Model.instance.guiModel.MuteButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                    NanoKON2Model.instance.model.MuteButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                };
            }

            //RecButton
            for(int i = 0; i < ControllerCounts.REC_BUTTON_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (64+n).ToString()].performed += (obj) =>
                {
                    NanoKON2Model.instance.guiModel.RecButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                    NanoKON2Model.instance.model.RecButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                };
            }

            //TransportButton
            for(int i = 0; i < ControllerCounts.TRANSPORT_BUTTON_COUNTS; i++)
            {
                int n = i;
                string[] actionNames = {"Control43", "Control44", "Control42", "Control41", "Control45"};

                _input.actions[actionNames[n]].performed += (obj) =>
                {
                    NanoKON2Model.instance.guiModel.TransportButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                    NanoKON2Model.instance.model.TransportButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                };

            }

            //FunctionButton
            for(int i = 0; i < ControllerCounts.FUNCTION_BUTTON_COUNTS; i++)
            {
                int n = i;
                string[] actionNames = {"Control58", "Control59", "Control46","Control60", "Control61", "Control62"};

                _input.actions[actionNames[n]].performed += (obj) =>
                {
                    NanoKON2Model.instance.guiModel.FunctionButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                    NanoKON2Model.instance.model.FunctionButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                };
            }
        }

        private void OnDisable() {
                        //Slider
            for(int i = 0; i < ControllerCounts.SLIDER_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + i.ToString()].performed -= (obj) => 
                {
                    NanoKON2Model.instance.guiModel.SliderValueList.ChangeValue(n, obj.ReadValue<float>());
                    NanoKON2Model.instance.model.SliderValueList.ChangeValue(n, obj.ReadValue<float>());
                };
            }

            //Knob
            for(int i = 0; i < ControllerCounts.KNOB_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (16+n).ToString()].performed -= (obj) => 
                {
                    NanoKON2Model.instance.guiModel.KnobValueList.ChangeValue(n, obj.ReadValue<float>());
                    NanoKON2Model.instance.model.KnobValueList.ChangeValue(n, obj.ReadValue<float>());
                };
            }

            //SoloButton
            for(int i = 0; i < ControllerCounts.SOLO_BUTTON_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (32+n).ToString()].performed -= (obj) => 
                {
                    NanoKON2Model.instance.guiModel.SoloButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                    NanoKON2Model.instance.model.SoloButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                };
            }
            
            //MuteButton
            for(int i = 0; i < ControllerCounts.MUTE_BUTTON_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (48+n).ToString()].performed -= (obj) =>
                {
                    NanoKON2Model.instance.guiModel.MuteButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                    NanoKON2Model.instance.model.MuteButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                };
            }

            //RecButton
            for(int i = 0; i < ControllerCounts.REC_BUTTON_COUNTS; i++)
            {
                int n = i;
                _input.actions["Control" + (64+n).ToString()].performed -= (obj) =>
                {
                    NanoKON2Model.instance.guiModel.RecButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                    NanoKON2Model.instance.model.RecButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                };
            }

            //TransportButton
            for(int i = 0; i < ControllerCounts.TRANSPORT_BUTTON_COUNTS; i++)
            {
                int n = i;
                string[] actionNames = {"Control43", "Control44", "Control42", "Control41", "Control45"};

                _input.actions[actionNames[n]].performed -= (obj) =>
                {
                    NanoKON2Model.instance.guiModel.TransportButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                    NanoKON2Model.instance.model.TransportButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                };

            }

            //FunctionButton
            for(int i = 0; i < ControllerCounts.FUNCTION_BUTTON_COUNTS; i++)
            {
                int n = i;
                string[] actionNames = {"Control58", "Control59", "Control46","Control60", "Control61", "Control62"};

                _input.actions[actionNames[n]].performed -= (obj) =>
                {
                    NanoKON2Model.instance.guiModel.FunctionButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                    NanoKON2Model.instance.model.FunctionButtonValueList.ChangeValue(n, obj.ReadValue<float>());
                };
            }
        }
    }
}