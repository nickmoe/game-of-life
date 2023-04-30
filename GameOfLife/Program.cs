const int GridMax = 10;
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
            var x = -1;
            var y = -1;
            var count = 0;

            for (int k = 1; k < 9; k++)
            {
                if (i + y > -1 && i + y < GridMax && j + x > -1 && j + x < GridMax && grid[i + y][j + x])
                {
                    count++;
                }

                if (k % 3 == 0)
                {
                    x = -1;
                    y++;
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
