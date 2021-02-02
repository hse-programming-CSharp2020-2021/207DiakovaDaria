using System;

namespace CW4
{
    public class PlayIsStartedEventArgs : EventArgs
    {
        public int SoundNumber { get; set; }
    }
    public class Bandmaster
    {
        Random rnd = new Random();
        public event EventHandler<PlayIsStartedEventArgs> StartEvent;
        public void StartPlay()
        {
            StartEvent?.Invoke(this, new PlayIsStartedEventArgs() { SoundNumber = rnd.Next(2, 6) });
        }
    }
    public abstract class OrchestraPlayer
    {
        public string Name { get; set; }
        public abstract void PlayIsStartedEventHandler(object sender, PlayIsStartedEventArgs e);
    }
    public class Violinist : OrchestraPlayer
    {
        public override void PlayIsStartedEventHandler(object sender, PlayIsStartedEventArgs e)
        {
            Console.WriteLine($"Violinist {Name} plays composition {e.SoundNumber}: La-la!");
        }
    }
    public class Hornist : OrchestraPlayer
    {
        public override void PlayIsStartedEventHandler(object sender, PlayIsStartedEventArgs e)
        {
            Console.WriteLine($"Hornist {Name} plays composition {e.SoundNumber}: Du-du-du!");
        }
    }
    class Program
    {
        public static string NameGenerate()
        {
            Random rnd = new Random();
            string name = "";
            int nick_length = rnd.Next(1, 16);
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < nick_length; i++)
            {
                name += chars[rnd.Next(chars.Length)];
            }
            return name;
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Bandmaster master = new Bandmaster();
            OrchestraPlayer[] orc = new OrchestraPlayer[10];
            for (int i = 0; i < 10; i++)
            {
                int player = rnd.Next(0, 2);
                if (player == 1)
                {
                    orc[i] = new Violinist() { Name = NameGenerate() };
                }
                else
                {
                    orc[i] = new Hornist() { Name = NameGenerate() };
                }
                master.StartEvent += orc[i].PlayIsStartedEventHandler;
            }
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) && n < 0)
            {
                Console.WriteLine("Неверный ввод!");
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                master.StartPlay();
            }
        }
    }
}
