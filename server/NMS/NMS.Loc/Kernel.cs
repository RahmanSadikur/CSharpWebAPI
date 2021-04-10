using Ninject;

namespace NMS.Loc
{
    public class Kernel
    {
        public static IKernel Current { get; set; }

        static Kernel()
        {
            Current = new StandardKernel();

        }
    }
}
