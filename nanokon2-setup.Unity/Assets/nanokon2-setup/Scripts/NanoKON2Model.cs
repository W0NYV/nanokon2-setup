using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace W0NYV.nanoKON2
{
    public class NanoKON2Model : MonoBehaviour
    {
        private const int SLIDER_COUNTS = 8; 
        private const int KNOB_COUNTS = 8; 
        private const int SOLO_BUTTON_COUNTS = 8;
        private const int MUTE_BUTTON_COUNTS = 8;
        private const int REC_BUTTON_COUNTS = 8;
        private const int TRANSPORT_BUTTON_COUNTS = 5;
        private const int FUNCTION_BUTTON_COUNTS = 6;

        private FloatReactiveCollection _sliderValueList = new FloatReactiveCollection(SLIDER_COUNTS);
        public FloatReactiveCollection SliderValueList
        {
            get => _sliderValueList;
        }

        private FloatReactiveCollection _knobValueList = new FloatReactiveCollection(KNOB_COUNTS);
        public FloatReactiveCollection KnobValueList
        {
            get => _knobValueList;
        }

    } 
}