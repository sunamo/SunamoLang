using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoLang;
public class XlfDocument
{
    public IEnumerable<XlfFile> Files;

    public void LoadXml(string content)
    {
        ThrowEx.NotImplementedMethod();
    }
}

public class XlfFile
{
    public IEnumerable<XlfTransUnit> TransUnits;
    public string Original;
}

public class XlfTransUnit
{
    public readonly string Id;
    public string Target;
}