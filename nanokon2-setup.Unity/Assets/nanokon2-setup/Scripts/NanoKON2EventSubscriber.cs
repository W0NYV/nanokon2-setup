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

                        NanoKON2Model.instance.model.SliderValueList.ReplaceObservable.Subscribe(replaceEvent => 
                        {

                            if(subscribeObject.index == replaceEvent.Index)
                            {
                                subscribeObject.uniEvent.Invoke(replaceEvent.NewValue);
                            }
                        }).AddTo(this);
                        break;
                    
                    case Controller.KNOB:
                        
                        if(subscribeObject.index >= ControllerCounts.KNOB_COUNTS)
                        {
                            subscribeObject.index = ControllerCounts.KNOB_COUNTS-1;
                        }
                        else if(subscribeObject.index < 0)
                        {
                            subscribeObject.index = 0;
                        }

                        NanoKON2Model.instance.model.KnobValueList.ReplaceObservable.Subscribe(replaceEvent => 
                        {
                            if(subscribeObject.index == replaceEvent.Index)
                            {
                                subscribeObject.uniEvent.Invoke(replaceEvent.NewValue);
                            }
                        }).AddTo(this);
                        break;

                    case Controller.SOLO_BUTTON:

                        if(subscribeObject.index >= ControllerCounts.SOLO_BUTTON_COUNTS)
                        {
                            subscribeObject.index = ControllerCounts.SOLO_BUTTON_COUNTS-1;
                        }
                        else if(subscribeObject.index < 0)
                        {
                            subscribeObject.index = 0;
                        }

                        NanoKON2Model.instance.model.SoloButtonValueList.ReplaceObservable.Subscribe(replaceEvent => 
                        {
                            if(subscribeObject.index == replaceEvent.Index)
                            {
                                subscribeObject.uniEvent.Invoke(replaceEvent.NewValue);
                            }
                        }).AddTo(this);
                        break;

                    case Controller.MUTE_BUTTON:

                        if(subscribeObject.index >= ControllerCounts.MUTE_BUTTON_COUNTS)
                        {
                            subscribeObject.index = ControllerCounts.MUTE_BUTTON_COUNTS-1;
                        }
                        else if(subscribeObject.index < 0)
                        {
                            subscribeObject.index = 0;
                        }

                        NanoKON2Model.instance.model.MuteButtonValueList.ReplaceObservable.Subscribe(replaceEvent => 
                        {
                            if(subscribeObject.index == replaceEvent.Index)
                            {
                                subscribeObject.uniEvent.Invoke(replaceEvent.NewValue);
                            }
                        }).AddTo(this);
                        break;

                    case Controller.REC_BUTTON:

                        if(subscribeObject.index >= ControllerCounts.REC_BUTTON_COUNTS)
                        {
                            subscribeObject.index = ControllerCounts.REC_BUTTON_COUNTS-1;
                        }
                        else if(subscribeObject.index < 0)
                        {
                            subscribeObject.index = 0;
                        }

                        NanoKON2Model.instance.model.RecButtonValueList.ReplaceObservable.Subscribe(replaceEvent => 
                        {
                            if(subscribeObject.index == replaceEvent.Index)
                            {
                                subscribeObject.uniEvent.Invoke(replaceEvent.NewValue);
                            }
                        }).AddTo(this);
                        break;

                    case Controller.TRANSPORT_BUTTON:

                        if(subscribeObject.index >= ControllerCounts.TRANSPORT_BUTTON_COUNTS)
                        {
                            subscribeObject.index = ControllerCounts.TRANSPORT_BUTTON_COUNTS-1;
                        }
                        else if(subscribeObject.index < 0)
                        {
                            subscribeObject.index = 0;
                        }

                        NanoKON2Model.instance.model.TransportButtonValueList.ReplaceObservable.Subscribe(replaceEvent => 
                        {
                            if(subscribeObject.index == replaceEvent.Index)
                            {
                                subscribeObject.uniEvent.Invoke(replaceEvent.NewValue);
                            }
                        }).AddTo(this);
                        break;

                    case Controller.FUNCTION_BUTTON:

                        if(subscribeObject.index >= ControllerCounts.FUNCTION_BUTTON_COUNTS)
                        {
                            subscribeObject.index = ControllerCounts.FUNCTION_BUTTON_COUNTS-1;
                        }
                        else if(subscribeObject.index < 0)
                        {
                            subscribeObject.index = 0;
                        }

                        NanoKON2Model.instance.model.FunctionButtonValueList.ReplaceObservable.Subscribe(replaceEvent => 
                        {
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

