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

        public List<UnityEvent<float>> onSliderMoved = new List<UnityEvent<float>>();
        public List<UnityEvent<float>> onKnobMoved = new List<UnityEvent<float>>();
        public List<UnityEvent<float>> onSoloButtonMoved = new List<UnityEvent<float>>();
        public List<UnityEvent<float>> onMuteButtonMoved = new List<UnityEvent<float>>();
        public List<UnityEvent<float>> onRecButtonMoved = new List<UnityEvent<float>>();
        public List<UnityEvent<float>> onTransportButtonMoved = new List<UnityEvent<float>>();
        public List<UnityEvent<float>> onFunctionButtonMoved = new List<UnityEvent<float>>();

        private void Awake()
        {

            TryGetComponent<PlayerInput>(out _input);

            //Sliderイベント初期化
            for(int i = 0; i < SLIDER_COUNTS; i++)
            {
                UnityEvent<float> tmpEvent = new UnityEvent<float>();
                onSliderMoved.Add(tmpEvent);
            }

            //Knobイベント初期化
            for(int i = 0; i < KNOB_COUNTS; i++)
            {
                UnityEvent<float> tmpEvent = new UnityEvent<float>();
                onKnobMoved.Add(tmpEvent);
            }

            //SoloButtonイベント初期化
            for(int i = 0; i < SOLO_BUTTON_COUNTS; i++)
            {
                UnityEvent<float> tmpEvent = new UnityEvent<float>();
                onSoloButtonMoved.Add(tmpEvent);
            }

            //MuteButtonイベント初期化
            for(int i = 0; i < MUTE_BUTTON_COUNTS; i++)
            {
                UnityEvent<float> tmpEvent = new UnityEvent<float>();
                onMuteButtonMoved.Add(tmpEvent);
            }

            //RecButtonイベント初期化
            for(int i = 0; i < REC_BUTTON_COUNTS; i++)
            {
                UnityEvent<float> tmpEvent = new UnityEvent<float>();
                onRecButtonMoved.Add(tmpEvent);
            }

            //TransportButtonイベント初期化
            for(int i = 0; i < TRANSPORT_BUTTON_COUNTS; i++)
            {
                UnityEvent<float> tmpEvent = new UnityEvent<float>();
                onTransportButtonMoved.Add(tmpEvent);
            }

            //FunctionButtonイベント初期化
            for(int i = 0; i < FUNCTION_BUTTON_COUNTS; i++)
            {
                UnityEvent<float> tmpEvent = new UnityEvent<float>();
                onFunctionButtonMoved.Add(tmpEvent);
            }
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
            _input.actions["Control32"].performed += (obj) => onSoloButtonMoved[0].Invoke(obj.ReadValue<float>());
            _input.actions["Control33"].performed += (obj) => onSoloButtonMoved[1].Invoke(obj.ReadValue<float>());
            _input.actions["Control34"].performed += (obj) => onSoloButtonMoved[2].Invoke(obj.ReadValue<float>());
            _input.actions["Control35"].performed += (obj) => onSoloButtonMoved[3].Invoke(obj.ReadValue<float>());
            _input.actions["Control36"].performed += (obj) => onSoloButtonMoved[4].Invoke(obj.ReadValue<float>());
            _input.actions["Control37"].performed += (obj) => onSoloButtonMoved[5].Invoke(obj.ReadValue<float>());
            _input.actions["Control38"].performed += (obj) => onSoloButtonMoved[6].Invoke(obj.ReadValue<float>());
            _input.actions["Control39"].performed += (obj) => onSoloButtonMoved[7].Invoke(obj.ReadValue<float>());
            
            //MuteButton
            _input.actions["Control48"].performed += (obj) => onMuteButtonMoved[0].Invoke(obj.ReadValue<float>());
            _input.actions["Control49"].performed += (obj) => onMuteButtonMoved[1].Invoke(obj.ReadValue<float>());
            _input.actions["Control50"].performed += (obj) => onMuteButtonMoved[2].Invoke(obj.ReadValue<float>());
            _input.actions["Control51"].performed += (obj) => onMuteButtonMoved[3].Invoke(obj.ReadValue<float>());
            _input.actions["Control52"].performed += (obj) => onMuteButtonMoved[4].Invoke(obj.ReadValue<float>());
            _input.actions["Control53"].performed += (obj) => onMuteButtonMoved[5].Invoke(obj.ReadValue<float>());
            _input.actions["Control54"].performed += (obj) => onMuteButtonMoved[6].Invoke(obj.ReadValue<float>());
            _input.actions["Control55"].performed += (obj) => onMuteButtonMoved[7].Invoke(obj.ReadValue<float>());

            //RecButton
            _input.actions["Control64"].performed += (obj) => onRecButtonMoved[0].Invoke(obj.ReadValue<float>());
            _input.actions["Control65"].performed += (obj) => onRecButtonMoved[1].Invoke(obj.ReadValue<float>());
            _input.actions["Control66"].performed += (obj) => onRecButtonMoved[2].Invoke(obj.ReadValue<float>());
            _input.actions["Control67"].performed += (obj) => onRecButtonMoved[3].Invoke(obj.ReadValue<float>());
            _input.actions["Control68"].performed += (obj) => onRecButtonMoved[4].Invoke(obj.ReadValue<float>());
            _input.actions["Control69"].performed += (obj) => onRecButtonMoved[5].Invoke(obj.ReadValue<float>());
            _input.actions["Control70"].performed += (obj) => onRecButtonMoved[6].Invoke(obj.ReadValue<float>());
            _input.actions["Control71"].performed += (obj) => onRecButtonMoved[7].Invoke(obj.ReadValue<float>());

            //TransportButton
            _input.actions["Control58"].performed += (obj) => onTransportButtonMoved[0].Invoke(obj.ReadValue<float>());
            _input.actions["Control59"].performed += (obj) => onTransportButtonMoved[1].Invoke(obj.ReadValue<float>());
            _input.actions["Control60"].performed += (obj) => onTransportButtonMoved[2].Invoke(obj.ReadValue<float>());
            _input.actions["Control61"].performed += (obj) => onTransportButtonMoved[3].Invoke(obj.ReadValue<float>());
            _input.actions["Control62"].performed += (obj) => onTransportButtonMoved[4].Invoke(obj.ReadValue<float>());

            //FunctionButton
            _input.actions["Control46"].performed += (obj) => onFunctionButtonMoved[0].Invoke(obj.ReadValue<float>());
            _input.actions["Control43"].performed += (obj) => onFunctionButtonMoved[1].Invoke(obj.ReadValue<float>());
            _input.actions["Control44"].performed += (obj) => onFunctionButtonMoved[2].Invoke(obj.ReadValue<float>());
            _input.actions["Control42"].performed += (obj) => onFunctionButtonMoved[3].Invoke(obj.ReadValue<float>());
            _input.actions["Control41"].performed += (obj) => onFunctionButtonMoved[4].Invoke(obj.ReadValue<float>());
            _input.actions["Control45"].performed += (obj) => onFunctionButtonMoved[5].Invoke(obj.ReadValue<float>());
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
            _input.actions["Control16"].performed -= (obj) => onKnobMoved[0].Invoke(obj.ReadValue<float>());
            _input.actions["Control17"].performed -= (obj) => onKnobMoved[1].Invoke(obj.ReadValue<float>());
            _input.actions["Control18"].performed -= (obj) => onKnobMoved[2].Invoke(obj.ReadValue<float>());
            _input.actions["Control19"].performed -= (obj) => onKnobMoved[3].Invoke(obj.ReadValue<float>());
            _input.actions["Control20"].performed -= (obj) => onKnobMoved[4].Invoke(obj.ReadValue<float>());
            _input.actions["Control21"].performed -= (obj) => onKnobMoved[5].Invoke(obj.ReadValue<float>());
            _input.actions["Control22"].performed -= (obj) => onKnobMoved[6].Invoke(obj.ReadValue<float>());
            _input.actions["Control23"].performed -= (obj) => onKnobMoved[7].Invoke(obj.ReadValue<float>());

            //SoloButton
            _input.actions["Control32"].performed -= (obj) => onSoloButtonMoved[0].Invoke(obj.ReadValue<float>());
            _input.actions["Control33"].performed -= (obj) => onSoloButtonMoved[1].Invoke(obj.ReadValue<float>());
            _input.actions["Control34"].performed -= (obj) => onSoloButtonMoved[2].Invoke(obj.ReadValue<float>());
            _input.actions["Control35"].performed -= (obj) => onSoloButtonMoved[3].Invoke(obj.ReadValue<float>());
            _input.actions["Control36"].performed -= (obj) => onSoloButtonMoved[4].Invoke(obj.ReadValue<float>());
            _input.actions["Control37"].performed -= (obj) => onSoloButtonMoved[5].Invoke(obj.ReadValue<float>());
            _input.actions["Control38"].performed -= (obj) => onSoloButtonMoved[6].Invoke(obj.ReadValue<float>());
            _input.actions["Control39"].performed -= (obj) => onSoloButtonMoved[7].Invoke(obj.ReadValue<float>());

            //MuteButton
            _input.actions["Control48"].performed -= (obj) => onMuteButtonMoved[0].Invoke(obj.ReadValue<float>());
            _input.actions["Control49"].performed -= (obj) => onMuteButtonMoved[1].Invoke(obj.ReadValue<float>());
            _input.actions["Control50"].performed -= (obj) => onMuteButtonMoved[2].Invoke(obj.ReadValue<float>());
            _input.actions["Control51"].performed -= (obj) => onMuteButtonMoved[3].Invoke(obj.ReadValue<float>());
            _input.actions["Control52"].performed -= (obj) => onMuteButtonMoved[4].Invoke(obj.ReadValue<float>());
            _input.actions["Control53"].performed -= (obj) => onMuteButtonMoved[5].Invoke(obj.ReadValue<float>());
            _input.actions["Control54"].performed -= (obj) => onMuteButtonMoved[6].Invoke(obj.ReadValue<float>());
            _input.actions["Control55"].performed -= (obj) => onMuteButtonMoved[7].Invoke(obj.ReadValue<float>());

            //RecButton
            _input.actions["Control64"].performed -= (obj) => onRecButtonMoved[0].Invoke(obj.ReadValue<float>());
            _input.actions["Control65"].performed -= (obj) => onRecButtonMoved[1].Invoke(obj.ReadValue<float>());
            _input.actions["Control66"].performed -= (obj) => onRecButtonMoved[2].Invoke(obj.ReadValue<float>());
            _input.actions["Control67"].performed -= (obj) => onRecButtonMoved[3].Invoke(obj.ReadValue<float>());
            _input.actions["Control68"].performed -= (obj) => onRecButtonMoved[4].Invoke(obj.ReadValue<float>());
            _input.actions["Control69"].performed -= (obj) => onRecButtonMoved[5].Invoke(obj.ReadValue<float>());
            _input.actions["Control70"].performed -= (obj) => onRecButtonMoved[6].Invoke(obj.ReadValue<float>());
            _input.actions["Control71"].performed -= (obj) => onRecButtonMoved[7].Invoke(obj.ReadValue<float>());

            //TransportButton
            _input.actions["Control58"].performed -= (obj) => onTransportButtonMoved[0].Invoke(obj.ReadValue<float>());
            _input.actions["Control59"].performed -= (obj) => onTransportButtonMoved[1].Invoke(obj.ReadValue<float>());
            _input.actions["Control60"].performed -= (obj) => onTransportButtonMoved[2].Invoke(obj.ReadValue<float>());
            _input.actions["Control61"].performed -= (obj) => onTransportButtonMoved[3].Invoke(obj.ReadValue<float>());
            _input.actions["Control62"].performed -= (obj) => onTransportButtonMoved[4].Invoke(obj.ReadValue<float>());
        
            //FunctionButton
            _input.actions["Control46"].performed -= (obj) => onFunctionButtonMoved[0].Invoke(obj.ReadValue<float>());
            _input.actions["Control43"].performed -= (obj) => onFunctionButtonMoved[1].Invoke(obj.ReadValue<float>());
            _input.actions["Control44"].performed -= (obj) => onFunctionButtonMoved[2].Invoke(obj.ReadValue<float>());
            _input.actions["Control42"].performed -= (obj) => onFunctionButtonMoved[3].Invoke(obj.ReadValue<float>());
            _input.actions["Control41"].performed -= (obj) => onFunctionButtonMoved[4].Invoke(obj.ReadValue<float>());
            _input.actions["Control45"].performed -= (obj) => onFunctionButtonMoved[5].Invoke(obj.ReadValue<float>());
        }
        
        private void Start() {

            //SoloButton
            onSoloButtonMoved[0].AddListener(val => Debug.Log("SoloButton 0: " + val));
            onSoloButtonMoved[1].AddListener(val => Debug.Log("SoloButton 1: " + val));
            onSoloButtonMoved[2].AddListener(val => Debug.Log("SoloButton 2: " + val));
            onSoloButtonMoved[3].AddListener(val => Debug.Log("SoloButton 3: " + val));
            onSoloButtonMoved[4].AddListener(val => Debug.Log("SoloButton 4: " + val));
            onSoloButtonMoved[5].AddListener(val => Debug.Log("SoloButton 5: " + val));
            onSoloButtonMoved[6].AddListener(val => Debug.Log("SoloButton 6: " + val));
            onSoloButtonMoved[7].AddListener(val => Debug.Log("SoloButton 7: " + val));

            //MuteButton
            onMuteButtonMoved[0].AddListener(val => Debug.Log("MuteButton 0: " + val));
            onMuteButtonMoved[1].AddListener(val => Debug.Log("MuteButton 1: " + val));
            onMuteButtonMoved[2].AddListener(val => Debug.Log("MuteButton 2: " + val));
            onMuteButtonMoved[3].AddListener(val => Debug.Log("MuteButton 3: " + val));
            onMuteButtonMoved[4].AddListener(val => Debug.Log("MuteButton 4: " + val));
            onMuteButtonMoved[5].AddListener(val => Debug.Log("MuteButton 5: " + val));
            onMuteButtonMoved[6].AddListener(val => Debug.Log("MuteButton 6: " + val));
            onMuteButtonMoved[7].AddListener(val => Debug.Log("MuteButton 7: " + val));

            //RecButton
            onRecButtonMoved[0].AddListener(val => Debug.Log("RecButton 0: " + val));
            onRecButtonMoved[1].AddListener(val => Debug.Log("RecButton 1: " + val));
            onRecButtonMoved[2].AddListener(val => Debug.Log("RecButton 2: " + val));
            onRecButtonMoved[3].AddListener(val => Debug.Log("RecButton 3: " + val));
            onRecButtonMoved[4].AddListener(val => Debug.Log("RecButton 4: " + val));
            onRecButtonMoved[5].AddListener(val => Debug.Log("RecButton 5: " + val));
            onRecButtonMoved[6].AddListener(val => Debug.Log("RecButton 6: " + val));
            onRecButtonMoved[7].AddListener(val => Debug.Log("RecButton 7: " + val));

            //TransportButton
            onTransportButtonMoved[0].AddListener(val => Debug.Log("TransportButton 0: " + val));
            onTransportButtonMoved[1].AddListener(val => Debug.Log("TransportButton 1: " + val));
            onTransportButtonMoved[2].AddListener(val => Debug.Log("TransportButton 2: " + val));
            onTransportButtonMoved[3].AddListener(val => Debug.Log("TransportButton 3: " + val));
            onTransportButtonMoved[4].AddListener(val => Debug.Log("TransportButton 4: " + val));

            //FunctionButton
            onFunctionButtonMoved[0].AddListener(val => Debug.Log("FunctionButton 0: " + val));
            onFunctionButtonMoved[1].AddListener(val => Debug.Log("FunctionButton 1: " + val));
            onFunctionButtonMoved[2].AddListener(val => Debug.Log("FunctionButton 2: " + val));
            onFunctionButtonMoved[3].AddListener(val => Debug.Log("FunctionButton 3: " + val));
            onFunctionButtonMoved[4].AddListener(val => Debug.Log("FunctionButton 4: " + val));
            onFunctionButtonMoved[5].AddListener(val => Debug.Log("FunctionButton 5: " + val));
        }
    }
}