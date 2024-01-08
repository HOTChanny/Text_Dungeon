/*게임시작화면
 * 1. 상태보기 / 2. 인벤토리 / 3. 상점
 * 1. 상태보기
 * 캐릭터의 정보 표시
 * 레벨 , 닉네임, 공격력, 방어력, 체력, 골드
 * 0누르면 나가기
 * 
 *2. 인벤토리
 *아이템 목록
 *1. 장착관리 0. 나가기
 *1 누르면
 *보유중인 아이템 관리
 *아이템 목록 뜨게
 *방어력 높이는 아이템 장착하면 정보에서 방어력+ 되게
 *0 누르면 나가기
 *
 *3. 상점
 *보유골드 보여줘야함
 *살수있는 아이템 목록
 *1아이템구매 0 나가기
 *이미 구매한 아이템이면 구매안됨
 *돈 없으면 구매안도미
 */

    
internal class program {

        private static Character player;
    static void Main(string[] args)
    {
        GameDataSetting();
        DisplayGameIntro();
        
        DisplayShop();
    }

    static void GameDataSetting()
    {
        // 캐릭터 정보 세팅
        player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);
        // 아이템 정보 세팅
    }
    static void DisplayGameIntro()
    {
        Console.Title = "TEXT_RPG";
        Console.Clear();


        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. 상태 보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine("3. 상점");
        Console.WriteLine();
        Console.ResetColor();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write(">>");
        Console.ResetColor();
        

        int input = CheckValidInput(1, 3);
        switch (input)
            {
            case 1:                        
                DisplayMyInfo();
                break;
            case 2:
                DisplayInventory();
                break;
            case 3:
                DisplayShop();
                break;
        }
    }
    static void DisplayMyInfo()
    {
        Console.Clear();

        Console.WriteLine("상태보기");
        Console.WriteLine("캐릭터의 정보르 표시합니다.");
        Console.WriteLine();
        Console.WriteLine($"Lv.{player.Level}");
        Console.WriteLine($"{player.Name}({player.Job})");
        Console.WriteLine($"공격력 :{player.Atk}");
        Console.WriteLine($"방어력 : {player.Def}");
        Console.WriteLine($"체력 : {player.Hp}");
        Console.WriteLine($"Gold : {player.Gold} G");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, 0);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
        }
    }
    static void DisplayInventory()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("인벤토리");
        Console.ResetColor();
        Console.WriteLine("보유중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");

        Console.WriteLine();
        Console.WriteLine("0. 장착관리");
        Console.WriteLine("1. 나가기");

        int input = CheckValidInput(0, 1);
        switch (input)
        {
            case 0:
                Console.Clear();
                Console.WriteLine("소지한 장비가 없습니다.");
                Console.WriteLine("곧 인벤토리로 이동합니다");
                Thread.Sleep(1500);
                DisplayInventory();
                break;
            case 1:
                DisplayGameIntro();
                break;
        }
    }
    static void DisplayShop()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("상점");
        Console.ResetColor();
        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
        Console.WriteLine();
        Console.WriteLine("[보유골드]");
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
