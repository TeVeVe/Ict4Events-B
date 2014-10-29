using System.Linq.Expressions;
using System.Text;

namespace SharedClasses.Data.LINQ
{
    public class QueryBuilder<T> where T : DataModel, new()
    {
        public enum QueryBuildMethod
        {
            SELECT,
            INSERT,
            UPDATE,
            DELETE
        }

        public QueryBuilder(LinqToSqlParser parser, T dataModel)
        {
            Parser = parser;
        }

        public LinqToSqlParser Parser { get; set; }


        public string Build(Expression expression, QueryBuildMethod method)
        {
            switch (method)
            {
                case QueryBuildMethod.INSERT:
                    return BuildInsert(expression);
                case QueryBuildMethod.UPDATE:
                    return BuildUpdate(expression);
                case QueryBuildMethod.DELETE:
                    return BuildDelete(expression);
                default:
                    return BuildSelect(expression);
            }
        }

        protected string BuildSelect(Expression expression)
        {
            var builder = new StringBuilder();



            return builder.ToString();
        }

        protected string BuildInsert(Expression expression)
        {
            var builder = new StringBuilder();


            return builder.ToString();
        }

        protected string BuildUpdate(Expression expression)
        {
            var builder = new StringBuilder();


            return builder.ToString();
        }

        protected string BuildDelete(Expression expression)
        {
            var builder = new StringBuilder();


            return builder.ToString();
        }
    }
}