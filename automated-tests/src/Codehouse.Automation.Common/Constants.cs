namespace Codehouse.Automation.Common
{
    public record Constants
    {
        public static class WaitTimeLimit
        {
            public static int OneSecond => 1;
            public static int TwoSecond => 2;
            public static int ThreeSecond => 3;
            public static int FiveSecond => 5;
            public static int TenSecond => 10;
            public static int TwentySecond => 20;
            public static int ThirtySecond => 30;
            public static int OneMinute => 60;
            public static int TwoMinute => 120;
            public static int ThreeMinute => 180;
        }
        public static IEnumerable<string> ChromeHeadlessArgs => new List<string>
        {
            "--headless=new",
            "--window-size=1680,1050",
        };
    }
}