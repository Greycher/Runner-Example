using System.Collections.Generic;
using UnityEngine;

namespace Runner_Example {
    public class MonoBehaviourPool<T> where T : IPoolableMonoBehaviour {
        private readonly Stack<T> _stack;
        private readonly Transform _parent;
        private readonly T _prefab;

        public MonoBehaviourPool(T prefab) {
            _stack = new Stack<T>();
            _parent = new GameObject($"{typeof(T).Name} Pool").transform;
            _prefab = prefab;
        }

        public T Spawn() {
            T t;
            if (_stack.Count > 0) {
                t = _stack.Pop();
                t.transform.SetParent(null);
                t.gameObject.SetActive(true);
            }
            else {
                t = Create();
            }

            return t;
        }

        private T Create() {
            var t = UnityEngine.Object.Instantiate(_prefab);
            t.OnDespawnSignal += () => Push(t);
            return t;
        }

        private void Push(T t) {
            t.gameObject.SetActive(false);
            t.transform.SetParent(_parent);
            _stack.Push(t);
        }
    }
}