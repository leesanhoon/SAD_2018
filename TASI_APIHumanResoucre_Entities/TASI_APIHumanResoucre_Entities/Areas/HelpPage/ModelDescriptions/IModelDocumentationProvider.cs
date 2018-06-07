using System;
using System.Reflection;

namespace TASI_APIHumanResoucre_Entities.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}