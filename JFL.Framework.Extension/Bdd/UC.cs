using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFL.Framework.Extension
{
    public static class UC
    {
        public static ChainedUc When(bool criteria)
        {
            return new ChainedUc() { TestResult = criteria };
        }

        public static ChainedUc<T> When<T>(bool criteria)
        {
            return new ChainedUc<T>() { TestResult = criteria };
        }
    }

    public class ChainedUc
    {
        public bool TestResult { get; set; }

        public ChainedUc Then(Action action)
        {
            if (TestResult)
            {
                action();
            }
            return this;
        }

        public ChainedUc Otherwise(Action action)
        {
            if (!TestResult)
            {
                action();
            }
            return this;
        }
    }

    public class ChainedUc<T>
    {
        public bool TestResult { get; set; }

        public ChainedUc<T> Then(Action action)
        {
            if (TestResult)
            {
                action();
            }
            return this;
        }

        public ChainedUc<T> Otherwise(Action action)
        {
            if (!TestResult)
            {
                action();
            }
            return this;
        }
    }
}
