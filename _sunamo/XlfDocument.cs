using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoLang;
public class XlfDocument
{
    public IEnumerable<XlfFile> Files;

    internal void LoadXml(string content)
    {
        throw new NotImplementedException();
    }
}

public class XlfFile
{
    public IEnumerable<XlfTransUnit> TransUnits;
    internal string Original;
}

public class XlfTransUnit
{
    internal readonly string Id;
    internal string Target;
}