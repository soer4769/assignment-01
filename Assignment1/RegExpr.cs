using System.Text.RegularExpressions;

namespace Assignment1;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        var regex =new Regex(@"[\w+$]+");
        foreach (var line in lines)
        {
            foreach (Match word in regex.Matches(line))
            {
                yield return word.ToString();
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions)
    {
        var regex = new Regex(@"([\d]+)x([\d]+)+");
        foreach (Match match in regex.Matches(resolutions))
        {
            yield return (int.Parse(match.Groups[1].ToString()),int.Parse(match.Groups[2].ToString()));
        }
        
    }

    public static IEnumerable<string> InnerText(string html, string tag)
    {
        foreach(Match match in Regex.Matches(html, $@"(?<tag><{tag}[\w\s\d_()\-:\/"":,.=]*>)(?<inner>.*?)(<\/{tag}>)")){
            yield return Regex.Replace(match.Groups["inner"].Value,"<.*?>","").ToString();
        }
    }
    
    public static IEnumerable<(Uri url, string title)> Urls(string html)
    {
        var regex = new Regex("<a.*?href=\"(?<url>.*?)\".*?(title=\"(?<title>.*?)\")?>(?<inner>.*?)</a>");
        foreach (Match match in regex.Matches(html))
        {
            if (match.Groups["title"].ToString() != "")
            {
                yield return (new Uri(match.Groups["url"].ToString()) ,match.Groups["title"].ToString());
            }
            else
            {
                yield return (new Uri(match.Groups["url"].ToString()) ,match.Groups["inner"].ToString());
            }
            
        }
        
    }
}