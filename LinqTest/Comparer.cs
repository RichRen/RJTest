using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    public static class Equality<T>
    {
        public static IEqualityComparer<T> CreateComparer<V>(Func<T, V> keySelector)
        {
            return new CommonEqualityComparer<V>(keySelector);
        }
        public static IEqualityComparer<T> CreateComparer<V>(Func<T, V> keySelector, IEqualityComparer<V> comparer)
        {
            return new CommonEqualityComparer<V>(keySelector, comparer);
        }

        class CommonEqualityComparer<V> : IEqualityComparer<T>
        {
            private Func<T, V> keySelector;
            private IEqualityComparer<V> comparer;

            public CommonEqualityComparer(Func<T, V> keySelector, IEqualityComparer<V> comparer)
            {
                this.keySelector = keySelector;
                this.comparer = comparer;
            }
            public CommonEqualityComparer(Func<T, V> keySelector)
                : this(keySelector, EqualityComparer<V>.Default)
            { }

            public bool Equals(T x, T y)
            {
                return comparer.Equals(keySelector(x), keySelector(y));
            }
            public int GetHashCode(T obj)
            {
                return comparer.GetHashCode(keySelector(obj));
            }
        }
    }

    public static class Comparison<T>
    {
        public static IComparer<T> CreateComparer<V>(Func<T, V> keySelector)
        {
            return new CommonComparer<V>(keySelector);
        }
        public static IComparer<T> CreateComparer<V>(Func<T, V> keySelector, IComparer<V> comparer)
        {
            return new CommonComparer<V>(keySelector, comparer);
        }

        class CommonComparer<V> : IComparer<T>
        {
            private Func<T, V> keySelector;
            private IComparer<V> comparer;

            public CommonComparer(Func<T, V> keySelector, IComparer<V> comparer)
            {
                this.keySelector = keySelector;
                this.comparer = comparer;
            }
            public CommonComparer(Func<T, V> keySelector)
                : this(keySelector, Comparer<V>.Default)
            { }

            public int Compare(T x, T y)
            {
                return comparer.Compare(keySelector(x), keySelector(y));
            }
        }
    }
}
