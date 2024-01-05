//상점 미구현....
namespace text_RPG
{
    internal class Program
    {
        static Character _player;
        static Item[] _items;

        static void Main(string[] args)
        {
            string playerName = WhenGameStart();
            
            Console.WriteLine("이동합니다.");
            
            GameDataSetting(playerName);
            Village(playerName);

        }

        static string WhenGameStart()
        {
            string playerName = "";
            int answerCount = 0;
            int nameAnswer;
            int readyAnswer;
            bool answerCheck = false;
            bool answerCheck2 = false;

            
            
            

            return playerName;
        }

        static void Village(string playerName)
        {
            bool answerCheck3 = false;
            int villageChoice;
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine("\n");
            while (!answerCheck3)
            {
                Console.WriteLine("1. 상태창 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine();
                Console.Write("입력:");
                if (int.TryParse(Console.ReadLine(), out villageChoice))
                {
                    if (villageChoice == 1)
                    {
                        DisplayMyInfo(playerName);
                        answerCheck3 = true;
                    }
                    else if (villageChoice == 2)
                    {
                        DisplayInventory(playerName);
                        answerCheck3 = true;
                    }
                    else if (villageChoice == 3)
                    {
                        DisplayShop(playerName);
                        answerCheck3 = true;
                    }//else if 3번 상점만들기
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다.");
                        answerCheck3 = false;
                    }
                }
            }
        }

        static void GameDataSetting(string playerName)
        {
            // 캐릭터 정보 세팅
            _player = new Character("핫챤", "전사", 1, 10, 5, 100, 1500);

            // 아이템 정보 세팅
            _items = new Item[10];
            AddItem(new Item("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷", 0, 0, 3, 0, 300));
            AddItem(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검", 1, 2, 0, 0, 200));
       
            AddItem(new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창", 1, 5, 0, 0, 400));
       
            
        }
        static void DisplayMyInfo(string playerName)
        {
            Console.Clear();

            
            
            Console.WriteLine("상태 보기");
            
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.WriteLine();

            
            
            Console.WriteLine($"Lv.{_player.Level}");
            
            Console.WriteLine($"{_player.Name}({_player.Job})");
            int bonusAtk = getSumBonusAtk();
            Console.WriteLine($"공격력 : {_player.Atk + bonusAtk}");
            int bonusDef = getSumBonusDef();
            Console.WriteLine($"방어력 : {_player.Def + bonusDef}");
            int bonusHp = getSumBonusHp();
            Console.WriteLine($"체력 : {_player.Hp + bonusHp}");
            
            Console.WriteLine($"Gold : {_player.Gold} G");
            

            Console.WriteLine();
            Console.WriteLine("0.나가기");
            

            Console.Write("입력해 주세요:");

            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    Village(playerName);
                    break;

            }
        }
        private static int getSumBonusAtk()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (_items[i].IsEquiped) sum += _items[i].Atk;
            }
            return sum;
        }

        private static int getSumBonusDef()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (_items[i].IsEquiped) sum += _items[i].Def;
            }
            return sum;
        }

        private static int getSumBonusHp()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (_items[i].IsEquiped) sum += _items[i].Hp;
            }
            return sum;
        }
        

        static void DisplayInventory(string playerName) // 인벤토리
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리");
            Console.ResetColor();
            Console.WriteLine("보유중인 아이템을 볼 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("\n");
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                _items[i].PrintItemStatDescription();
            }
            Console.WriteLine("\n");
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write("입력해 주세요:");
            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    Village(playerName);
                    break;

                case 1:
                    Console.Clear();
                    ManagementInventory(playerName);
                    break;
            }
        }
        static void DisplayShop(string playerName) { //상점
            
        }
        static void ManagementInventory(string playerName)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("장착관리");
            Console.ResetColor();
            Console.WriteLine("보유중인 아이템을 장착 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("\n");
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                _items[i].PrintItemStatDescription(true, i + 1); // 1, 2, 3에 매핑하기 위해 +1
            }
            Console.WriteLine("\n");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write("입력해 주세요:");
            int keyInput = CheckValidInput(0, Item.ItemCnt);

            switch (keyInput)
            {
                case 0:
                    DisplayInventory(playerName);
                    break;
                default:
                    ToggleEquipStatus(keyInput - 1); // 유저가 입력하는건 1, 2, 3 : 실제 배열에는 0, 1, 2...
                    ManagementInventory(playerName);
                    break;
            }
        }
        static void AddItem(Item item)
        {
            if (Item.ItemCnt == 10) return;
            _items[Item.ItemCnt] = item;
            Item.ItemCnt++;
        }
        static void ToggleEquipStatus(int idx)
        {
            _items[idx].IsEquiped = !_items[idx].IsEquiped;
        }
        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
                Console.WriteLine();
                Console.Write("다시 입력해 주세요:");
            }
        }
    }


    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
    public class Item
    {
        public string Name { get; }
        public string Description { get; }

        // 개선포인트 : Enum 활용
        public int Type { get; }

        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }

        public int Gold { get; }
        public bool IsEquiped { get; set; }

        public static int ItemCnt = 0;

        public Item(string name, string description, int type, int atk, int def, int hp, int gold, bool isEquiped = false)
        {
            Name = name;
            Description = description;
            Type = type;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
            IsEquiped = isEquiped;
        }
        public void PrintItemStatDescription(bool withNumber = false, int idx = 0)
        {
            Console.Write("- ");
            // 장착관리 전용
            if (withNumber)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("{0} ", idx);
                Console.ResetColor();
            }
            if (IsEquiped)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("E");
                Console.ResetColor();
                Console.Write("]");
                Console.Write(PadRightForMixedText(Name, 9));
            }
            else Console.Write(PadRightForMixedText(Name, 12));

            Console.Write(" | ");

            if (Atk != 0) Console.Write($"공격력 {(Atk >= 0 ? "+" : "")}{Atk} ");
            if (Def != 0) Console.Write($"방어력 {(Def >= 0 ? "+" : "")}{Def} ");
            if (Hp != 0) Console.Write($"체력 {(Hp >= 0 ? "+" : "")}{Hp}");

            Console.Write(" | ");

            Console.WriteLine(Description);
        }

        public static int GetPrintableLength(string str)
        {
            int length = 0;
            foreach (char c in str)
            {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2; // 한글과 같은 넓은 문자에 대해 길이를 2로 취급
                }
                else
                {
                    length += 1; // 나머지 문자에 대해 길이를 1로 취급
                }
            }

            return length;
        }

        public static string PadRightForMixedText(string str, int totalLength)
        {
            int currentLength = GetPrintableLength(str);
            int padding = totalLength - currentLength;
            return str.PadRight(str.Length + padding);
        }

    }
}
