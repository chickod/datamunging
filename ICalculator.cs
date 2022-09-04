using System.Collections.Generic;

namespace SLCU3
{
    public interface ICalculator<T>
    {
        T? GetSmallestInterval(List<T> values);
    }
}
