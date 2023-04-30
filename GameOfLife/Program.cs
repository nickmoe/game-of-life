const int GridMax = 25;
var grid = new bool[GridMax][];
var next = new bool[GridMax][];

var rand = new Random();
for (int i = 0; i < grid.Length; i++)
{
    grid[i] = new bool[GridMax];
    next[i] = new bool[GridMax];
}

for (int i = 0; i < grid.Length; i++)
{
    for(int j = 0; j < grid[i].Length; j++)
    {
        grid[i][j] = rand.Next() % 2 == 0;
    }
}

var frames = 1000;

while (frames >= 0)
{
    Console.Clear();
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

    Thread.Sleep(500);

    for (int i = 0; i < next.Length; i++)
    {
        for (int j = 0; j < next[i].Length; j++)
        {
            var startX = j - 1 > -1 ? j - 1 : GridMax - 1;
            //var startY = i - 1 > -1 ? i - 1 : GridMax - 1;
            var x = j-1 > -1 ? j-1 : GridMax -1;
            var y = i-1 > -1 ? i-1 : GridMax -1;
            var count = 0;

            for (int k = 1; k < 9; k++)
            {
                if (x == j && y == i)
                {
                    //skip
                }
                else if (grid[y][x])
                {
                    count++;
                }

                x++;
                if (x == GridMax)
                {
                    x = 0;
                }

                if (k % 3 == 0)
                {
                    x = startX;
                    y++;
                }
                if (y == GridMax)
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
    grid = next;

    frames--;
}
