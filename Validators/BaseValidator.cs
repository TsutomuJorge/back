using System.Linq.Expressions;

namespace Validators
{
    public static class BaseValidator
    {
        public static string ObterNomePropriedade<T>(Expression<Func<T>> expressao)
        {
            MemberExpression memberExpression = (MemberExpression)expressao.Body;
            return memberExpression.Member.Name;
        }
    }
}
