namespace OOPTest
{
    public class BaseClass
    {
        public virtual int GetSomeValue(string path, int quantity)
        {
            return 100;
        }
    }

    // Перший рівень успадкування
    public class DerivedClass1 : BaseClass
    {
        public override int GetSomeValue(string path, int quantity)
        {
            return 200;
        }
    }

    // Другий рівень успадкування
    public class DerivedClass2 : DerivedClass1
    {
        public override int GetSomeValue(string path, int quantity)
        {
            return 300;
        }
    }
}