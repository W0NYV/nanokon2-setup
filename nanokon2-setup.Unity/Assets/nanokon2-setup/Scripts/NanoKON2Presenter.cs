using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace W0NYV.nanoKON2
{
    public class NanoKON2Presenter : MonoBehaviour
    {

        [SerializeField] private NanoKON2Model _nanoKON2Model;
        [SerializeField] private Slider[] _sliders;
        [SerializeField] private Knob[] _knobs;

        void Start()
        {
            //値の変化を見る
            _nanoKON2Model.SliderValueList.ReplaceObservable.Subscribe(replaceEvent => {
                _sliders[replaceEvent.Index].value = replaceEvent.NewValue;
                Debug.Log(replaceEvent.Index + "番目の値が" + replaceEvent.OldValue + "→" + replaceEvent.NewValue + "に変更");
            }).AddTo(this);

            _nanoKON2Model.KnobValueList.ReplaceObservable.Subscribe(replaceEvent => {
                _knobs[replaceEvent.Index].SetValue(replaceEvent.NewValue);
                Debug.Log(replaceEvent.Index + "番目の値が" + replaceEvent.OldValue + "→" + replaceEvent.NewValue + "に変更");
            }).AddTo(this);

            //UIの変化を見る
            foreach (var (slider, idx) in _sliders.Select((slider, idx) => (slider, idx))) //←ここきもい
            {
                slider.OnValueChangedAsObservable()
                    .SubscribeWithState(idx, (x, idx) => {
                        _nanoKON2Model.SliderValueList.ChangeValue(idx, x);
                    })
                    .AddTo(this);
            }

            foreach (var (knob, idx) in _knobs.Select((knob, idx) => (knob, idx)))
            {
                knob.ObserveEveryValueChanged(knob => knob.value)
                    .SubscribeWithState(idx, (x, idx) => {
                        _nanoKON2Model.KnobValueList.ChangeValue(idx, x);
                    })
                    .AddTo(this);
            }
        }

    }
} 
