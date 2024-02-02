using HtmlAgilityPack;

namespace Smile.Parser;

public class CheckForSubject
{
    public static bool Check(HtmlNodeCollection htmlNodes, string subject)
    {
        if(htmlNodes is not null)
            foreach (var node in htmlNodes)
                if(subject == node.InnerText)
                    return true;
        return false; 
        
    }
}
