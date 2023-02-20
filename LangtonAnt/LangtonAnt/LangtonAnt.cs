namespace LangtonAnt
{
    public class LangtonAnt
    {
        public readonly bool[,] IsBlack;
        private Square _origin;
        private Square _antPosition = new Square(0,0);
        public bool OutOfBounds { get; set; }

        private Direction _antDirection = Direction.Right;

        private readonly Direction[] _counterClockwise = new[] { Direction.Left, Direction.Up, Direction.Down, Direction.Right };
        private readonly Direction[] _clockwise = new[] { Direction.Right, Direction.Down, Direction.Up, Direction.Left };
        
        private readonly int[] _xInc = new[] { 0, 1, -1, 0 };
        private readonly int[] _yInc = new[] { -1, 0, 0, 1 };

        public LangtonAnt(int width, int height, Square origin)
        {
            _origin = origin;
            IsBlack = new bool[width, height];
            OutOfBounds = false;
        }

        public LangtonAnt(int width, int height) 
            : this(width, height, new Square(width / 2, height / 2)) 
        { 
        }

        public Square Step()
        {
            if (OutOfBounds)
            {
                throw new InvalidOperationException("The ant is out of the boundaries of the canvas!");
            }

            // Change the move direction of the ant according to the color of the square
            Square currentSquare = new Square(_antPosition._x + _origin._x, _antPosition._y + _origin._y);
            
            bool isBlackSquare = IsBlack[currentSquare._x, currentSquare._y];
            
            int direction = (int)_antDirection;
            
            _antDirection = isBlackSquare ? _counterClockwise[direction] : _clockwise[direction];
            
            // Fliping the color
            IsBlack[currentSquare._x, currentSquare._y] = !IsBlack[currentSquare._x, currentSquare._y];

            // Moving the ant
            _antPosition._x += _xInc[(int)_antDirection];
            _antPosition._y += _yInc[(int)_antDirection];

            currentSquare = new Square(_antPosition._x + _origin._x, _antPosition._y + _origin._y);
            
            // Check if the ant went out of boundaries
            OutOfBounds =
                currentSquare._x < 0 ||
                currentSquare._x >= IsBlack.GetUpperBound(0) ||
                currentSquare._y < 0 ||
                currentSquare._y >= IsBlack.GetUpperBound(1);
            
            return _antPosition;
        }
    }

}
