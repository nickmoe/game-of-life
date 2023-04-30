const int GridMaxHeight = 25;
const int GridMaxWidth = 50;
var grid = new bool[GridMaxHeight][];
var next = new bool[GridMaxHeight][];


for (int i = 0; i < grid.Length; i++)
{
    grid[i] = new bool[GridMaxWidth];
    next[i] = new bool[GridMaxWidth];
}

InitializeRandomGrid(grid);

var frames = 100;

while (frames >= 0)
{
    Console.Clear();
    
    PrintGrid(grid);

    Thread.Sleep(250);

    grid = CalculateNext(grid);

    frames--;
}

void InitializeRandomGrid(bool[][] grid)
{
    var rand = new Random();
    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[i].Length; j++)
        {
            grid[i][j] = rand.Next() % 5 == 0;
        }
    }
}

void PrintGrid(bool[][] grid)
{
    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[i].Length; j++)
        {
            if (grid[i][j])
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}

static bool[][] CalculateNext(bool[][] grid)
{
    var maxWidth = grid[0].Length;
    var maxHeight = grid.Length;
    var next = (bool[][])grid.Clone();
    for (int i = 0; i < maxHeight; i++)
    {
        for (int j = 0; j < maxWidth; j++)
        {
            var startX = j - 1 > -1 ? j - 1 : maxWidth - 1;
            var x = startX;
            var y = i - 1 > -1 ? i - 1 : maxHeight - 1;
            var count = 0;

            for (int k = 1; k < 9; k++)
            {
                if (x == j && y == i) //k == 5
                {
                    //skip
                }
                else if (grid[y][x])
                {
                    count++;
                }

                x++;
                if (x == maxWidth)
                {
                    x = 0;
                }

                if (k % 3 == 0)
                {
                    x = startX;
                    y++;
                }
                if (y == maxHeight)
                {
                    y = 0;
                }
            }

            if (grid[i][j] && (count == 0 || count == 1))
            {
                next[i][j] = false;
            }
            else if (grid[i][j] && (count == 2 || count == 3))
            {
                next[i][j] = true;
            }
            else if (grid[i][j] && count > 3)
            {
                next[i][j] = false;
            }
            else if (!grid[i][j] && count == 3)
            {
                next[i][j] = true;
            }
        }
    }

    return next;
}