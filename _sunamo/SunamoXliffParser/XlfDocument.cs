using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoLang._sunamo.SunamoXliffParser;
internal class XlfDocument
{
    internal IEnumerable<XlfFile> Files;

    internal void LoadXml(string content)
    {
        ThrowEx.NotImplementedMethod();
    }
}
