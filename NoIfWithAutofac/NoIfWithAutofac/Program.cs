using System;
using Autofac;

namespace NoIfWithAutofac
{
    class Program
    {

        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            if (args == null) throw new ArgumentNullException(nameof(args));
            var builder = new ContainerBuilder();

            builder.RegisterInstance(new NoIfOne()).Named<INoIf>("1");
            builder.RegisterInstance(new NoIfTwo()).Named<INoIf>("2");

            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                for (var i = 1; i < 3; i++)
                {
                    var classInstance = scope.ResolveNamed<INoIf>(i.ToString());
                    Console.WriteLine(classInstance.MethodOne("aaa"));
                    Console.WriteLine(classInstance.MethodTwo("bbb"));
                }
                Console.ReadLine();
            }
        }
    }
}
