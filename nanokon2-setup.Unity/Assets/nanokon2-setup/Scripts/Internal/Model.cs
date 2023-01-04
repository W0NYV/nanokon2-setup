using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace W0NYV.nanoKON2
{
    public class Model
    {
        public FloatReactiveCollection _sliderValueList = new FloatReactiveCollection(ControllerCounts.SLIDER_COUNTS);
        public FloatReactiveCollection SliderValueList
        {
            get => _sliderValueList;
        }

        private FloatReactiveCollection _knobValueList = new FloatReactiveCollection(ControllerCounts.KNOB_COUNTS);
        public FloatReactiveCollection KnobValueList
        {
            get => _knobValueList;
        }

        private FloatReactiveCollection _soloButtonValueList = new FloatReactiveCollection(ControllerCounts.SOLO_BUTTON_COUNTS);
        public FloatReactiveCollection SoloButtonValueList
        {
            get => _soloButtonValueList;
        }

        private FloatReactiveCollection _muteButtonValueList = new FloatReactiveCollection(ControllerCounts.MUTE_BUTTON_COUNTS);
        public FloatReactiveCollection MuteButtonValueList
        {
            get => _muteButtonValueList;
        }

        private FloatReactiveCollection _recButtonValueList = new FloatReactiveCollection(ControllerCounts.REC_BUTTON_COUNTS);
        public FloatReactiveCollection RecButtonValueList
        {
            get => _recButtonValueList;
        }

        private FloatReactiveCollection _transportButtonValueList = new FloatReactiveCollection(ControllerCounts.TRANSPORT_BUTTON_COUNTS);
        public FloatReactiveCollection TransportButtonValueList
        {
            get => _transportButtonValueList;
        }

        private FloatReactiveCollection _functionButtonValueList = new FloatReactiveCollection(ControllerCounts.FUNCTION_BUTTON_COUNTS);
        public FloatReactiveCollection FunctionButtonValueList
        {
            get => _functionButtonValueList;
        }
    }
}
