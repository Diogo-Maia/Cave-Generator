public class GeneratorController
{   
    private System.Random rdn;
    private int width;
    private int height;
    private int[,] map;
    private float maxFloat;

    public GeneratorController(int width, int height)
    {
        this.width = width;
        this.height = height;

        map = new int[width, height];
        
    }

    public int[,] GenerateMap(float toMax)
    {
        rdn = new System.Random();
        
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                map[x, y] = rdn.Next(0, 100) < toMax ? 1 : 0;
            }
        }

        return map;
    }

    public int[,] FormMap(int[,] m)
    {
        map = m;
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                map[x, y] = CheckNeightboors(x, y) > 4 ? 1 : 0;
                if(x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    map[x, y] = 1;
            }
        }
        return m;
    }

    private int CheckNeightboors(int x, int y)
    {
        int walls = 0;
        
        if(x - 1 >= 0) if(map[x - 1, y] == 1) walls++;
        if(x + 1 < width) if(map[x + 1, y] == 1) walls++;
        if(y - 1 >= 0) if(map[x, y - 1] == 1) walls++;
        if(y + 1 < height) if(map[x, y + 1] == 1) walls++;

        if(x - 1 >= 0 && y - 1 >= 0) if(map[x - 1, y - 1] == 1) walls++;
        if(x - 1 >= 0 && y + 1 < height) if(map[x - 1, y + 1] == 1) walls++;
        if(x + 1 < width && y - 1 >= 0) if(map[x + 1, y - 1] == 1) walls++;
        if(x + 1 < width && y + 1 < height) if(map[x + 1, y + 1] == 1) walls++;
        
        return walls;
    }
}