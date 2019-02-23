namespace api.RomanCalculator
{
    public interface Expression
    {
        // TODO: Implement
    }

    public class LiteralExpression : Expression
    {
        private Token _token;

        public LiteralExpression(Token token)
        {
            _token = token;
        }
    }

    public class UnaryExpression : Expression
    {
        private Token _oper;
        private Expression _expression;

        public UnaryExpression(Token oper, Expression expression)
        {
            _oper = oper;
            _expression = expression;
        }
    }
    
    public class BinaryExpression : Expression
    {
        private Expression _left;
        private Token _oper;
        private Expression _right;
        
        public BinaryExpression(Expression left, Token oper, Expression right)
        {
            _left = left;
            _oper = oper;
            _right = right;
        }
    }

    public class GroupingExpression : Expression
    {
        private Expression _expression;

        public GroupingExpression(Expression expression)
        {
            _expression = expression;
        }
    }
}