namespace lab2
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            input:
                Console.Write("Введіть 8-розрядне бінарне число: ");
                string binary = Console.ReadLine();
                if (!IsBinary(binary))
                {
                    Console.WriteLine("Некоректні дані, очікується 8-розрядне бінарне число.");
                    goto input;
                }
            Console.WriteLine($"Додатковий код: {DirectToAdditional(binary)}");
        }
        static bool IsBinary(string binary)
        {
            // Перевірка на кількість розрядів
            if (binary.Length != 8)
                return false;
            // Перевірка на бінарність
            foreach (var i in binary)
            {
                if (i != '0' && i != '1')
                    return false;
            }
            return true;
        }
        static string DirectToAdditional(string binary)
        {
            // Перевірка чи додане число чи від'ємне
            if (binary[0] == '0')
                return binary;

            // Заміна елементів на обернені їм значення
            string inverted = "";
            inverted += binary[0];
            for (int i = 1; i < binary.Length; i++)
            {
                inverted += binary[i] == '0' ? '1' : '0';
            }
            string additional = AddOne(inverted);
            return additional;
        }
        static string AddOne(string inverted)
        {
            char[] binarr = inverted.ToCharArray();
            int carry = 1;

            // Йдемо з кінця для додавання 1
            for (int i = binarr.Length - 1; i >= 0; i--)
            {
                // 1 + 1 = 0^1; 1 + 0 = 1
                if (binarr[i] == '1' && carry == 1)
                    binarr[i] = '0';
                else if (binarr[i] == '0' && carry == 1)
                {
                    binarr[i] = '1';
                    carry = 0;
                }
                if (carry == 0)
                    break;
            }
            return new string(binarr);
        }
    }
}