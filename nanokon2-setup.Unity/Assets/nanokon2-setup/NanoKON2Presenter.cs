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

        void Start()
        {
            _nanoKON2Model.SliderValueList.ReplaceObservable.Subscribe(replaceEvent => {
                _sliders[replaceEvent.Index].value = replaceEvent.NewValue;
                Debug.Log(replaceEvent.Index + "番目の値が" + replaceEvent.OldValue + "→" + replaceEvent.NewValue + "に変更");
            }).AddTo(this);

            foreach (var (slider, idx) in _sliders.Select((slider, idx) => (slider, idx))) //←ここきもい
            {
                slider.OnValueChangedAsObservable()
                    .SubscribeWithState(idx, (x, idx) => {
                        _nanoKON2Model.SliderValueList.ChangeValue(idx, x);
                    })
                    .AddTo(this);
            }
        }

    }
} 
