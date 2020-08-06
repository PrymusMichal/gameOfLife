using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace gameOfLife.engine
{
    public class GameOfLife
    {
        private bool[,] gameState= new bool[128,128];
        public string gameStateToJSON()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(gameState);
        }
        private bool inBounds(int X,int Y)
        {
            return (X >= 0 && X <= gameState.GetUpperBound(0) && Y >= 0 && Y <= gameState.GetUpperBound(1));
        }
        public void evaluateGameState()
        {
            for (int i=0;i<gameState.GetLength(0);i++)
            {
                for (int j=0;j<gameState.GetLength(1);j++)
                {
                    int neighbours = 0;
                    neighbours += gameState?[i-1,j-1] == true && inBounds(i-1,j-1) ? 1 : 0;
                    neighbours += gameState?[i - 1, j] == true && inBounds(i - 1, j ) ? 1 : 0;
                    neighbours += gameState?[i - 1, j +1] == true && inBounds(i - 1, j + 1) ? 1 : 0;
                    neighbours += gameState?[i, j - 1] == true && inBounds(i, j - 1) ? 1 : 0;
                    neighbours += gameState?[i, j ] == true && inBounds(i, j) ? 1 : 0;
                    neighbours += gameState?[i, j + 1] == true && inBounds(i, j + 1) ? 1 : 0;
                    neighbours += gameState?[i+1, j - 1] == true && inBounds(i+1, j - 1) ? 1 : 0;
                    neighbours += gameState?[i + 1, j ] == true && inBounds(i + 1, j ) ? 1 : 0;
                    neighbours += gameState?[i + 1, j + 1] == true && inBounds(i + 1, j + 1) ? 1 : 0;

                    if (neighbours < 2 || neighbours > 3)
                        gameState[i, j] = false;
                    if (neighbours == 3)
                        gameState[i, j] = true;
                    
                }
            }

        }

        public GameOfLife()
        {
            gameState[5, 5] = true;
            gameState[5, 6] = true;
            gameState[6, 6] = true;
            gameState[7, 6] = true;
        }
    }
}
