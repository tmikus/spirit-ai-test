using System;

namespace api.RomanCalculator
{
    public interface Expression
    {
        int Execute();
    }

    public class LiteralExpression : Expression
    {
        private readonly Token _token;

        public LiteralExpression(Token token)
        {
            _token = token;
        }

        protected bool Equals(LiteralExpression other)
        {
            return _token.Equals(other._token);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LiteralExpression) obj);
        }

        public override int GetHashCode()
        {
            return _token.GetHashCode();
        }

        public int Execute()
        {
            if (_token.Type != TokenType.Number)
            {
                throw new InvalidOperationException("Invalid token in a literal expression");
            }

            if (!_token.Value.HasValue)
            {
                throw new InvalidOperationException("Number token is missing a value.");
            }

            return _token.Value.Value;
        }
    }

    public class UnaryExpression : Expression
    {
        private readonly Token _oper;
        private readonly Expression _expression;

        public UnaryExpression(Token oper, Expression expression)
        {
            _oper = oper;
            _expression = expression;
        }

        protected bool Equals(UnaryExpression other)
        {
            return _oper.Equals(other._oper) && _expression.Equals(other._expression);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UnaryExpression) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_oper.GetHashCode() * 397) ^ _expression.GetHashCode();
            }
        }

        public int Execute()
        {
            var value = _expression.Execute();
            switch (_oper.Type)
            {
                case TokenType.Plus: return value;
                case TokenType.Minus: return -value;
                default: throw new InvalidOperationException("Invalid unary operator.");
            }
        }
    }
    
    public class BinaryExpression : Expression
    {
        private readonly Expression _left;
        private readonly Token _oper;
        private readonly Expression _right;
        
        public BinaryExpression(Expression left, Token oper, Expression right)
        {
            _left = left;
            _oper = oper;
            _right = right;
        }

        protected bool Equals(BinaryExpression other)
        {
            return _left.Equals(other._left) && _oper.Equals(other._oper) && _right.Equals(other._right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BinaryExpression) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _left.GetHashCode();
                hashCode = (hashCode * 397) ^ _oper.GetHashCode();
                hashCode = (hashCode * 397) ^ _right.GetHashCode();
                return hashCode;
            }
        }

        public int Execute()
        {
            var leftVal = _left.Execute();
            var rightVal = _right.Execute();
            switch (_oper.Type)
            {
                case TokenType.Plus: return leftVal + rightVal;
                case TokenType.Minus: return leftVal - rightVal;
                case TokenType.Star: return leftVal * rightVal;
                case TokenType.Slash: return leftVal / rightVal;
                case TokenType.Hat: return (int)Math.Pow(leftVal, rightVal);
                default: throw new InvalidOperationException("Invalid binary operator.");
            }
        }
    }

    public class GroupingExpression : Expression
    {
        private readonly Expression _expression;

        public GroupingExpression(Expression expression)
        {
            _expression = expression;
        }

        protected bool Equals(GroupingExpression other)
        {
            return _expression.Equals(other._expression);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GroupingExpression) obj);
        }

        public override int GetHashCode()
        {
            return _expression.GetHashCode();
        }

        public int Execute()
        {
            return _expression.Execute();
        }
    }
}