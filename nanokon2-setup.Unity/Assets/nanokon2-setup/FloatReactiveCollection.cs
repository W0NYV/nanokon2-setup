using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace W0NYV.nanoKON2
{
    public class FloatReactiveCollection
    {
        private readonly ReactiveCollection<float> _reactiveCollection;

        public List<float> ValueList => _reactiveCollection.ToList();

        public IObservable<CollectionReplaceEvent<float>> ReplaceObservable => _reactiveCollection.ObserveReplace();

        public FloatReactiveCollection(int count)
        {
            _reactiveCollection = new ReactiveCollection<float>();
            for(int i = 0; i < count; i++)
            {
                _reactiveCollection.Add(0f);
            }
        }

        public void ChangeValue(int index, float value)
        {
            _reactiveCollection[index] = value;
        }
    }
}