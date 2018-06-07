using System;
using System.Reflection;

namespace TASI_APIHumanResoucre_Hibernate.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}