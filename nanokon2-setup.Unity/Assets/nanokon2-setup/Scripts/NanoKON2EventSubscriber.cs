using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;

namespace W0NYV.nanoKON2
{
    public class NanoKON2EventSubscriber : MonoBehaviour
    {
        [SerializeField] private SubscribeObject[] subscribeObjects;

        private void Start() {

            foreach (var subscribeObject in subscribeObjects)
            {
                switch (subscribeObject.controller)
                {
                    case Controller.SLIDER:

                        if(subscribeObject.index >= ControllerCounts.SLIDER_COUNTS)
                        {
                            subscribeObject.index = ControllerCounts.SLIDER_COUNTS-1;
                        }
                        else if(subscribeObject.index < 0)
                        {
                            subscribeObject.index = 0;
                        }

                        NanoKON2Model.instance.SliderValueList.ReplaceObservable
                        .Subscribe(replaceEvent => {
                            if(subscribeObject.index == replaceEvent.Index)
                            {
                                subscribeObject.uniEvent.Invoke(replaceEvent.NewValue);
                            }
                        }).AddTo(this);
                        break;
                    
                    case Controller.KNOB:
                        NanoKON2Model.instance.KnobValueList.ReplaceObservable.Subscribe(replaceEvent => {
                            if(subscribeObject.index == replaceEvent.Index)
                            {
                                subscribeObject.uniEvent.Invoke(replaceEvent.NewValue);
                            }
                        }).AddTo(this);
                        break;

                    case Controller.SOLO_BUTTON:
                        NanoKON2Model.instance.SoloButtonValueList.ReplaceObservable.Subscribe(replaceEvent => {
                            if(subscribeObject.index == replaceEvent.Index)
                            {
                                subscribeObject.uniEvent.Invoke(replaceEvent.NewValue);
                            }
                        }).AddTo(this);
                        break;

                    case Controller.MUTE_BUTTON:
                        NanoKON2Model.instance.MuteButtonValueList.ReplaceObservable.Subscribe(replaceEvent => {
                            if(subscribeObject.index == replaceEvent.Index)
                            {
                                subscribeObject.uniEvent.Invoke(replaceEvent.NewValue);
                            }
                        }).AddTo(this);
                        break;

                    case Controller.REC_BUTTON:
                        NanoKON2Model.instance.RecButtonValueList.ReplaceObservable.Subscribe(replaceEvent => {
                            if(subscribeObject.index == replaceEvent.Index)
                            {
                                subscribeObject.uniEvent.Invoke(replaceEvent.NewValue);
                            }
                        }).AddTo(this);
                        break;

                    case Controller.TRANSPORT_BUTTON:
                        NanoKON2Model.instance.TransportButtonValueList.ReplaceObservable.Subscribe(replaceEvent => {
                            if(subscribeObject.index == replaceEvent.Index)
                            {
                                subscribeObject.uniEvent.Invoke(replaceEvent.NewValue);
                            }
                        }).AddTo(this);
                        break;

                    case Controller.FUNCTION_BUTTON:
                        NanoKON2Model.instance.FunctionButtonValueList.ReplaceObservable.Subscribe(replaceEvent => {
                            if(subscribeObject.index == replaceEvent.Index)
                            {
                                subscribeObject.uniEvent.Invoke(replaceEvent.NewValue);
                            }
                        }).AddTo(this);
                        break;
                }
            }
        
        }

    }
}

