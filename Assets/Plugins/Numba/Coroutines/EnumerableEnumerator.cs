using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Coroutines
{
    internal class EnumerableEnumerator : IEnumerable
    {
        private IEnumerator _enumerator;

        public EnumerableEnumerator(IEnumerator enumerator) => _enumerator = enumerator;

        public IEnumerator GetEnumerator() => _enumerator;
    }
}