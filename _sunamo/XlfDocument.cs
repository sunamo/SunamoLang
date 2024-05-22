using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoLang;
internal class XlfDocument
{
    internal IEnumerable<XlfFile> Files;

    internal void LoadXml(string content)
    {
        ThrowEx.NotImplementedMethod();
    }
}

internal class XlfFile
{
    internal IEnumerable<XlfTransUnit> TransUnits;
    internal string Original;
}

internal class XlfTransUnit
{
    internal readonly string Id;
    internal string Target;
}