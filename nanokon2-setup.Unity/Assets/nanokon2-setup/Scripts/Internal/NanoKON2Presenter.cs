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

        [SerializeField] private Slider[] _sliders;
        [SerializeField] private Knob[] _knobs;
        [SerializeField] private Button[] _soloButtons;
        [SerializeField] private Button[] _muteButtons;
        [SerializeField] private Button[] _recButtons;
        [SerializeField] private Button[] _transportButtons;
        [SerializeField] private Button[] _functionButtons;

        void Start()
        {
            #region 値の変化を見る
            NanoKON2Model.instance.guiModel.SliderValueList.ReplaceObservable.Subscribe(replaceEvent => {
                _sliders[replaceEvent.Index].value = replaceEvent.NewValue;
                // Debug.Log(replaceEvent.Index + "番目の値が" + replaceEvent.OldValue + "→" + replaceEvent.NewValue + "に変更");
            }).AddTo(this);

            NanoKON2Model.instance.guiModel.KnobValueList.ReplaceObservable.Subscribe(replaceEvent => {
                _knobs[replaceEvent.Index].SetValue(replaceEvent.NewValue);
                // Debug.Log(replaceEvent.Index + "番目の値が" + replaceEvent.OldValue + "→" + replaceEvent.NewValue + "に変更");
            }).AddTo(this);

            NanoKON2Model.instance.guiModel.SoloButtonValueList.ReplaceObservable.Subscribe(replaceEvent => {

                //押されたなら
                if(replaceEvent.NewValue == 1f)
                {
                    _soloButtons[replaceEvent.Index].SetPressedState();
                }
                else
                {
                    _soloButtons[replaceEvent.Index].SetDefaultState();
                }

                // Debug.Log(replaceEvent.Index + "番目の値が" + replaceEvent.OldValue + "→" + replaceEvent.NewValue + "に変更");
            }).AddTo(this);

            NanoKON2Model.instance.guiModel.MuteButtonValueList.ReplaceObservable.Subscribe(replaceEvent => {

                //押されたなら
                if(replaceEvent.NewValue == 1f)
                {
                    _muteButtons[replaceEvent.Index].SetPressedState();
                }
                else
                {
                    _muteButtons[replaceEvent.Index].SetDefaultState();
                }

                // Debug.Log(replaceEvent.Index + "番目の値が" + replaceEvent.OldValue + "→" + replaceEvent.NewValue + "に変更");
            }).AddTo(this);

            NanoKON2Model.instance.guiModel.RecButtonValueList.ReplaceObservable.Subscribe(replaceEvent => {

                //押されたなら
                if(replaceEvent.NewValue == 1f)
                {
                    _recButtons[replaceEvent.Index].SetPressedState();
                }
                else
                {
                    _recButtons[replaceEvent.Index].SetDefaultState();
                }

                // Debug.Log(replaceEvent.Index + "番目の値が" + replaceEvent.OldValue + "→" + replaceEvent.NewValue + "に変更");
            }).AddTo(this);

            NanoKON2Model.instance.guiModel.TransportButtonValueList.ReplaceObservable.Subscribe(replaceEvent => {

                //押されたなら
                if(replaceEvent.NewValue == 1f)
                {
                    _transportButtons[replaceEvent.Index].SetPressedState();
                }
                else
                {
                    _transportButtons[replaceEvent.Index].SetDefaultState();
                }

                // Debug.Log(replaceEvent.Index + "番目の値が" + replaceEvent.OldValue + "→" + replaceEvent.NewValue + "に変更");
            }).AddTo(this);

            NanoKON2Model.instance.guiModel.FunctionButtonValueList.ReplaceObservable.Subscribe(replaceEvent => {

                //押されたなら
                if(replaceEvent.NewValue == 1f)
                {
                    _functionButtons[replaceEvent.Index].SetPressedState();
                }
                else
                {
                    _functionButtons[replaceEvent.Index].SetDefaultState();
                }

                // Debug.Log(replaceEvent.Index + "番目の値が" + replaceEvent.OldValue + "→" + replaceEvent.NewValue + "に変更");
            }).AddTo(this);
            #endregion

            #region GUIの変化を見る
            foreach (var (slider, idx) in _sliders.Select((slider, idx) => (slider, idx))) //←ここきもい
            {
                slider.OnValueChangedAsObservable()
                    .SubscribeWithState(idx, (x, idx) => {
                        NanoKON2Model.instance.guiModel.SliderValueList.ChangeValue(idx, x);
                    })
                    .AddTo(this);
            }

            foreach (var (knob, idx) in _knobs.Select((knob, idx) => (knob, idx)))
            {
                knob.ObserveEveryValueChanged(knob => knob.value)
                    .SubscribeWithState(idx, (x, idx) => {
                        NanoKON2Model.instance.guiModel.KnobValueList.ChangeValue(idx, x);
                    })
                    .AddTo(this);
            }

            foreach (var (soloButton, idx) in _soloButtons.Select((soloButton, idx) => (soloButton, idx)))
            {
                soloButton.ObserveEveryValueChanged(soloButton => soloButton.value)
                    .SubscribeWithState(idx, (x, idx) => {
                        NanoKON2Model.instance.guiModel.SoloButtonValueList.ChangeValue(idx, x);
                    })
                    .AddTo(this);
            }

            foreach (var (muteButton, idx) in _muteButtons.Select((muteButton, idx) => (muteButton, idx)))
            {
                muteButton.ObserveEveryValueChanged(muteButton => muteButton.value)
                    .SubscribeWithState(idx, (x, idx) => {
                        NanoKON2Model.instance.guiModel.MuteButtonValueList.ChangeValue(idx, x);
                    })
                    .AddTo(this);
            }

            foreach (var (recButton, idx) in _recButtons.Select((recButton, idx) => (recButton, idx)))
            {
                recButton.ObserveEveryValueChanged(recButton => recButton.value)
                    .SubscribeWithState(idx, (x, idx) => {
                        NanoKON2Model.instance.guiModel.RecButtonValueList.ChangeValue(idx, x);
                    })
                    .AddTo(this);
            }

            foreach (var (transportButton, idx) in _transportButtons.Select((transportButton, idx) => (transportButton, idx)))
            {
                transportButton.ObserveEveryValueChanged(transportButton => transportButton.value)
                    .SubscribeWithState(idx, (x, idx) => {
                        NanoKON2Model.instance.guiModel.TransportButtonValueList.ChangeValue(idx, x);
                    })
                    .AddTo(this);
            }

            foreach (var (functionButton, idx) in _functionButtons.Select((functionButton, idx) => (functionButton, idx)))
            {
                functionButton.ObserveEveryValueChanged(functionButton => functionButton.value)
                    .SubscribeWithState(idx, (x, idx) => {
                        NanoKON2Model.instance.guiModel.FunctionButtonValueList.ChangeValue(idx, x);
                    })
                    .AddTo(this);
            }
            #endregion
        }

    }
} 
