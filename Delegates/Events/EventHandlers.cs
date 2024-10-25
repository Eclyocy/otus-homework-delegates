namespace Delegates.Events
{
    public static class EventHandlers
    {
        public static void OnFileFound(object sender, FileArgs args)
        {
            Console.WriteLine($"File found: {args}");
        }
    }
}
