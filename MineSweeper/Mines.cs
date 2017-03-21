using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    public enum Cell 
    {
        Empty,
        Cell01,
        Cell02,
        Cell03,
        Cell04,
        Cell05,
        Cell06,
        Cell07,
        Cell08,
        Mine,
    }

    public enum Oper
    { 
        Open=100,
        Close,
        Flag,
        Ques,
        NotRet =-1

    }

    public enum GameOver { play, yourWin, yourLost }

    public class Mines
    {
        private int cols;
        private int rows;
        private int total;
        private int flagcnt = 0;
        //Генератор случайных чисел
        static Random rnd = new Random();

        Cell[,] map;
        Oper[,] top;
        deShowBox ShowBox;

        public GameOver gameover { get; private set; }
        public int Cols { get { return cols; } }
        public int Rows { get { return rows; } }
        public int Total { get { return total; } }
        public int FlagCnt { get { return flagcnt; } }


        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Mines( int cols, int rows, int total, deShowBox ShowBox) 
        {
            this.rows = rows;
            this.cols = cols;
            this.total = total;
            this.ShowBox = ShowBox;
            map = new Cell[cols, rows];
            top = new Oper[cols, rows];
            gameover = GameOver.play;
        }

        public void ShowAll() {
            for (int x = 0; x < cols; x++)
            for (int y = 0; y < rows; y++)
                ShowBox(x, y, (int) Oper.Close);
        }

        /// <summary>
        /// Установка начальных значений
        /// </summary>
        public void Init()
        {
            for (int x = 0; x < cols; x++)
            for (int y = 0; y < rows; y++)
            {
                map[x, y] = Cell.Empty;
                top[x, y] = Oper.Close;
            }
        }

        public void MyPlacedMine()
        {
            Letter_B(0,0);
            Letter_O();
            Letter_B(0, 7);
            Letter_A();

        }

        void Letter_O()
        {
            for (int x = 6; x <= 9; x++)
            {
                SetMine(x, 0);
                SetMine(x, 5);
            }

            for (int y = 0; y <=5 ; y++)
            {
                SetMine(6, y);
                SetMine(9, y);
            }

        }

        void Letter_A()
        {
            SetMine(8, 7);
            for (int dy = 0; dy <=1; dy++)
            {
                SetMine(7, 8 + dy);
                SetMine(9, 8 + dy);
                SetMine(6, 10 + dy);
                SetMine(10, 10 + dy);

            }
            SetMine(6, 10 + 2);
            SetMine(10, 10 + 2);

            for (int x = 6; x <= 10; x++)
                SetMine(x, 10);
        }

        private void Letter_B(int x, int y)
        {
            SetMine(x, y);
            SetMine(x+1, y);
            for (int i = 1; i <= 2; i++)
            {
                SetMine(x  ,y + i);
                SetMine(x+2,y + i);
            }
            SetMine(x, y+ 4); SetMine(x+3, y+ 4);
            for (int i = 0; i <= 3; i++)
            {
                SetMine(x + i,y + 3);
                SetMine(x + i,y + 5);
            }
        }

        /// <summary>
        /// Начальное размещение мин на карте
        /// </summary>
        public void PlacedMines() 
        {
            int placed = 0; //Количество размещенных мин
            int loop = 400; //Предохранительный клапан

            while (placed < total && --loop > 0) 
            {
                //Выбираем случайные значения координаты x и y
                int x = rnd.Next(0, cols-1);
                int y = rnd.Next(0, rows-1);
                //Если мина, то продоложаем дальше
                if (map[x, y] == Cell.Mine) continue;
                SetMine(x, y);
                placed++;
            }
        }

        /// <summary>
        /// Установить мину
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void SetMine(int x, int y)
        {
            if (map[x, y] == Cell.Mine) return;
            map[x, y] = Cell.Mine;
            //Отмечаем количество мин в пустых ячейках вокруг ячейки с миной
            for (int sx = -1; sx <= 1; sx++)
                for (int sy = -1; sy <= 1; sy++)
                    PlaceMine(x + sx, y + sy);
        }

        /// <summary>
        /// Пометка цифрами полей вокруг мин
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void PlaceMine(int x, int y)
        {
            //Восклицательный знак - это отрицание
            /*   111
             *   1M1
             *   111 
             * !     выход
             * ложь   истина
             * истина  ложь
             * 
             * ||       выход
             * ложь ложь     0
             * 
             */
            if (!OnMap(x, y)) return;
            if (map[x, y] == Cell.Mine) return;
            map[x, y]++;
        }

        /// <summary>
        /// Проверяем находятся ли координаты x и y на карте
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool OnMap(int x, int y)
        {
            if (x < 0 || x >= cols) return false;
            if (y < 0 || y >= rows) return false;
            return true;
        }


        public void OpenMap(int x, int y)
        {
            if (top[x, y] == Oper.Flag) return;
            if (top[x, y] == Oper.Open) return;

            if (map[x, y] == Cell.Mine) {
                gameover = GameOver.yourLost;
                OpenAllMines();
                return;
            }

            if (top[x, y] == Oper.Close && map[x, y] != Cell.Empty)
            {
                top[x, y] = Oper.Open;
                ShowBox(x, y, (int)map[x, y]);
                if (AllBoxOpen())
                {
                    MarkAllMines();
                    gameover = GameOver.yourWin;
                }

                return;
            }

            if (top[x, y] == Oper.Close) {
                OpenAroundCell(x, y);
            }
        }

        private void OpenAroundCell(int x, int y)
        {
            OpenEmptyCell(x, y);
            if (AllBoxOpen())
            {
                MarkAllMines();
                gameover = GameOver.yourWin;
            }
            
        }

        private bool AllBoxOpen()
        {
            for (int i = 0; i < cols; i++)
            for (int j = 0; j < rows; j++)
                if (map[i, j] != Cell.Mine && 
                    (top[i, j] == Oper.Close  || top[i,j] == Oper.Flag)
                    ) 
                    return false;
            return true;
        }

        private void MarkAllMines()
        {
            for (int i = 0; i < cols; i++)
                for (int j = 0; j < rows; j++)
                    if (map[i, j] == Cell.Mine)
                    {
                        top[i, j] = Oper.Flag;
                        ShowBox(i, j, (int)top[i, j]);
                    }
        }

        private void OpenEmptyCell(int x, int y) 
        {
            if (!OnMap(x, y)) return;

            for (int sx = -1; sx<=1; sx++)
            for (int sy = -1; sy <= 1; sy++)
            {
                int new_x = x + sx;
                int new_y = y + sy;
                if (!OnMap(new_x, new_y)) continue;
                if (top[new_x, new_y] == Oper.Close && map[new_x,new_y] == Cell.Empty ) {
                    top[new_x, new_y] = Oper.Open;
                    ShowBox(new_x, new_y, (int)map[new_x,new_y]);                    
                    OpenEmptyCell(new_x, new_y);
                }
                   
                else if (top[new_x, new_y] == Oper.Close && map[new_x, new_y] != Cell.Mine) 
                {
                    top[new_x, new_y] = Oper.Open;
                    ShowBox(new_x, new_y, (int)map[new_x, new_y]);
                }
                
            }
        }

        private void OpenAllMines()
        {
            for (int x = 0; x < cols; x++)
            for (int y = 0; y < rows; y++)            
                if (map[x, y] == Cell.Mine)
                    ShowBox(x, y, (int)Cell.Mine);            
        }

        public void MarkMines(int x, int y)
        {
            if (top[x, y] == Oper.Flag)
            {
                flagcnt--;
                top[x, y] = Oper.Close;
                ShowBox(x, y, (int)top[x, y]);
            }
            else {
                flagcnt++;
                top[x, y] = Oper.Flag;
                ShowBox(x, y, (int)top[x, y]);
            }
        }
    }

}
