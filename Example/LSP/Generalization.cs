namespace Example.LSP;

public class Generalization
{
    public class A
    {
        private readonly List<string> _messages = new();

        public void M()
        {
            var count = 5;

            foreach (var i in Enumerable.Range(0, count))
            {
                Console.WriteLine(i);
            }

            _messages.AddRange(new []
            {
                "Hello there1",
                "Hello there2",
                "Hello there3",
                "Hello there4",
            });
        }
    }

    public class B
    {
        private string _message;

        public void M()
        {
            var count = 9;

            foreach (var i in Enumerable.Range(0, count))
            {
                Console.WriteLine($"B {i}");
            }

            _message = "Hello there";
        }
    }

    // Refactor to generalized base class:

    public abstract class Base
    {
        private readonly List<string> _messages = new();

        public void M()
        {
            var count = GetCount();

            foreach (var i in Enumerable.Range(0, count))
            {
                ForeachAction(i);
            }

            _messages.AddRange(GetMessages());
        }

        protected abstract int GetCount();
        protected abstract void ForeachAction(int i);
        protected abstract IEnumerable<string> GetMessages();
    }

    public class AGeneralized : Base
    {
        protected override int GetCount()
        {
            return 5;
        }

        protected override void ForeachAction(int i)
        {
            Console.WriteLine(i);
        }

        protected override IEnumerable<string> GetMessages()
        {
            return new[]
            {
                "Hello there1",
                "Hello there2",
                "Hello there3",
                "Hello there4",
            };
        }
    }

    public class BGeneralized : Base
    {
        protected override int GetCount()
        {
            return 9;
        }

        protected override void ForeachAction(int i)
        {
            Console.WriteLine($"B {i}");
        }

        protected override IEnumerable<string> GetMessages()
        {
            return new[]
            {
                "Hello there1"
            };
        }
    }
}