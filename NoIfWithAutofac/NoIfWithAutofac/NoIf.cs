namespace NoIfWithAutofac
{
    public interface INoIf
    {
        string MethodOne(string param1);

        string MethodTwo(string param2);
    }

    public class NoIfOne : INoIf
    {
        public string MethodOne(string param1)
        {
            return "NoIfOne_MethodOne";
        }

        public string MethodTwo(string param2)
        {
            return "NoIfOne_MethodTwo";
        }
    }

    public class NoIfTwo : INoIf
    {
        public string MethodOne(string param1)
        {
            return "NoIfTwo_MethodOne";
        }

        public string MethodTwo(string param2)
        {
            return "NoIfTwo_MethodTwo";
        }
    }

    public class NoIfTest
    {
        
    }
}
