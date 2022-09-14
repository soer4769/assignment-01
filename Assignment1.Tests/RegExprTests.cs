namespace Assignment1.Tests;

using Xunit;
using Assignment1;

public class RegExprTests
{
    [Fact]
    public void Splitline_return_array_of_all_words()
    {
        //Arrange
        string[] arrayOfLines = { "Hej med dig", "hvad hedder du","jeg hedder Knud"};

        //act
        IEnumerable<string> arrayOfWords = RegExpr.SplitLine(arrayOfLines);
        
        //Assert
        Assert.Equal(arrayOfWords ,new []{"Hej", "med","dig","hvad","hedder","du","jeg","hedder","Knud"});
    }
    
    [Fact]
    public void Resolution_return_resolutions_as_tuples()
    {
        //Arrange
        string resolutionString = "1435x432, 345x2345, 12345x3455, 12x12";

        //act
        IEnumerable<(int,int)> resolutiontuples = RegExpr.Resolution(resolutionString);
        
        //Assert
        Assert.Equal(resolutiontuples ,new []{(1435,432), (345,2345), (12345,3455),(12,12)});
    }
    
   
    [Fact]
    public void InnerText_return_text_from_p_and_p_tag()
    {
        var text1 = RegExpr.InnerText("<div><p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p></div>", "p");
        var text2 = RegExpr.InnerText("<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>", "a");

        Assert.Equal("The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to.", string.Join("", text1));
        Assert.Equal("theoretical computer science, formal language, characters, pattern, string searching algorithms, strings", string.Join(", ", text2));
    }
    
    
    [Fact]
    public void InnerText_return_urls_and_titles()
    {
        //Arrange
        string html = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";

        //act
        IEnumerable<(Uri, string)> urls = RegExpr.Urls(html);
        
        //Assert
        Assert.Equal(
            new[]
            {
                (new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"),
                (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language"),
                (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"),
                (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching"),
                (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"), "String searching algorithm"),
                (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"), "String (computer science)"),
            }, urls);
    }
    
    [Fact]
    public void InnerText_return_urls_and_innerText()
    {
        //Arrange
        string html = "<div><a href=\"https://github.com/itu-bdsa/assignment-01\">assignment-01</a> <a href=\"https://github.com/itu-bdsa/assignment-00/blob/main/README.md\">assignment-00</a></div>";

        //act
        IEnumerable<(Uri, string)> urls = RegExpr.Urls(html);
        
        //Assert
        Assert.Equal(
            new[]
            {
                (new Uri("https://github.com/itu-bdsa/assignment-01"), "assignment-01"),
                (new Uri("https://github.com/itu-bdsa/assignment-00/blob/main/README.md"), "assignment-00"),
            }, urls);
    }
}