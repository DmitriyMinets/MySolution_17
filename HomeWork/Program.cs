namespace HomeWork;

internal class Program
{
    private static void Main(string[] args)
    {
        var file = new FileStream(@"D:\TEST\text.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        var file1 = new FileStream(@"D:\TEST\text1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        var file2 = new FileStream(@"D:\TEST\text2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

        var thred = new Thread(() =>
        {
            var hash = Thread.CurrentThread.GetHashCode();
            var streamReader = new StreamReader(file);
            var result = streamReader.ReadToEnd();
            using (var sw = new StreamWriter(file2))
            {
                Console.WriteLine($"Номер потока - {hash}");
                sw.WriteLine(result);
            }
        });

        thred.Start();
        Thread.Sleep(300);

        thred = new Thread(() =>
        {
            var hash = Thread.CurrentThread.GetHashCode();
            var streamReader = new StreamReader(file1);
            var result = streamReader.ReadToEnd();
            using (var sw = new StreamWriter(@"D:\TEST\text2.txt", true))
            {
                Console.WriteLine($"Номер потока - {hash}");
                sw.WriteLine(result);
            }
        });
        thred.Start();
    }
}