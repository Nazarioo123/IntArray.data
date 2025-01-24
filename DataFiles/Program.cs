using System.IO;
using System.Text;

namespace DataFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("введіть числа (n):");
             int n = int.Parse(Console.ReadLine());

            // я можливо не так зрозумів завдання, якшо не так то я перероблю 

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Веддіть число {i + 1 }: ");
                numbers[i] = int.Parse(Console.ReadLine()); 

            }
            Console.WriteLine("Ваш масив :");
            foreach (int number in numbers)
            {
                Console.WriteLine(number + " ");

            }
            string dirreectoryPath = @"c:\HomeTask";
            string filePath = Path.Combine(dirreectoryPath, "intArray.data");

            Directory.CreateDirectory(dirreectoryPath);

            using (BinaryWriter writer = new BinaryWriter(File.Create(filePath)))
            {
                foreach (int number in numbers) {
                    writer.Write(number); }

            }
            Console.WriteLine($"Файл створен-масив записано: {filePath}");

            int[] readNumbers;
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                int lenght = (int)(reader.BaseStream.Length / sizeof(int));
                readNumbers = new int[lenght];

                for (int i = 0; i < readNumbers.Length; i++)
                {
                    readNumbers[i] = reader.ReadInt32();

                }


            }
            Console.WriteLine("Масив:");
            foreach (int number in readNumbers)
            {  Console.WriteLine(number + " "); }
        }
       
        
    }        
}
