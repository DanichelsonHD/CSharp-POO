namespace Namespace
{
    class Secao6
    {
        static Room[] rooms = new Room[10];
        static void Main1(string[] args)
        {
            Console.Write("Quantos quartos serão alugados? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nAluguel #{i + 1}:");
                Room tempRoom = OccupyRoom(i);
                rooms[tempRoom.RoomNumber - 1] = tempRoom; // The array starts from 0-9, but the rooms go from 1-10
            }

            Console.WriteLine("\nQuartos ocupados:");
            for (int i = 0; i < rooms.Length; i++)
                if (rooms[i] != null)
                    Console.WriteLine($"{rooms[i].RoomNumber}: {rooms[i].HolderName}, {rooms[i].Email}");
        }

        static Room OccupyRoom(int i) => new Room
        {
            HolderName = GetInput("Nome: "),
            Email = GetInput("Email: "),
            RoomNumber = GetRoomNumber()
        };

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static int GetRoomNumber()
        {
            while (true)
            {
                int roomNumber = int.Parse(GetInput("Quarto: "));
                if (roomNumber < 1 || roomNumber > 10 || rooms[roomNumber - 1] != null)
                {
                    Console.WriteLine("Número de quarto inválido. Tente novamente.");
                    continue;
                }
                return roomNumber;
            }
        }
    }

    class Room
    {
        public required int RoomNumber { get; set; }
        public required string HolderName { get; set; }
        public required string Email { get; set; }
    }
}