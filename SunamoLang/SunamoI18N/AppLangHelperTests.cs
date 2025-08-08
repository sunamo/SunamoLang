public class AppLangHelperTests
{
    [Fact]
    public void GetLang3Test()
    {
        Langs actual = Langs.cs;

        string input = "cs-CZ";
        Langs expected = Langs.cs;

        actual = AppLangHelper.GetLang3(input);
        Assert.Equal(expected, actual);

        input = "en-us";
        expected = Langs.en;

        actual = AppLangHelper.GetLang3(input);
        Assert.Equal(expected, actual);
    }
}
