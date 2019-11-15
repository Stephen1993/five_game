using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace wuziqi
{
    public partial class wuziqi : CCSkinMain
    {
        //定义全局变量
        private PictureBox[,] QipanPictureBox=new PictureBox[15,15];//棋子
        int r=16,X=0, Y=0;//X,Y表示鼠标所在区域为第X行第Y列
        bool stone=true,play = true,Begin=false;
        int[,] mark = new int[15, 15], pos = new int[2, 2], stack = new int[15 * 15, 2];//stack储存下棋位置,方便悔棋
        int[] val=new int[2];
        int lastx=-1,lasty=-1,lastX=-1,lastY=-1,len=26,L = 5;//len表示棋子的width,L表示红线的长度
        
         public wuziqi()
         {
            InitializeComponent();
         }

         private void wuziqi_Load(object sender, EventArgs e)
         {
             for (int i = 0; i < 15; ++i) {
                 for (int j = 0; j < 15; ++j) mark[i, j] = 2;
             }
             stack[0, 0] = 0;//已走0步
             QiZiPos();
         }

        //确定棋子的位置
        private void QiZiPos(){
            for (int i = 0; i < 15; ++i)
             {//确定棋子的位置
                 for (int j = 0; j < 15; ++j)
                 {
                     QipanPictureBox[i, j] = new PictureBox();
                     QipanPictureBox[i, j].Size = new Size(30, 30);//棋子的大小
                     QipanPictureBox[i, j].Location = new Point(r + j * 36 - 15, r + i * 36 - 15);//棋子的位置,棋子中心在点上
                     QipanPictureBox[i, j].BackColor = Color.Transparent;
                     QipanPictureBox[i, j].SizeMode = PictureBoxSizeMode.Zoom;
                     QipanPictureBox[i, j].Cursor = Cursors.No;
                     QipanPictureBox[i, j].Visible = false;
                     Groap.Controls.Add(QipanPictureBox[i, j]);
                 }
             }
        }

         private void Groap_Paint(object sender, PaintEventArgs e)//初始化棋盘
         {
             Graphics drawline = e.Graphics;
             Pen MyPen=new Pen(Color.Black,1);
             for (int i = 0; i < 15; ++i) {//画棋盘
                 drawline.DrawLine(MyPen, r, r + i * 36, r + 14 * 36, r + i * 36);//画横线
                 drawline.DrawLine(MyPen, r + i * 36, r, r + i * 36, r + 14 * 36);//画竖线
             }
             //画5个点
             MyPen.Width = 6;
             drawline.DrawLine(MyPen,r+3*36, r+3*36-2, r+3*36,r+3*36+4);
             drawline.DrawLine(MyPen, r + 11 * 36, r + 3 * 36-2, r + 11 * 36, r + 3 * 36+4);
             drawline.DrawLine(MyPen, r + 3 * 36, r + 11 * 36-2, r + 3 * 36, r + 11 * 36+4);
             drawline.DrawLine(MyPen, r + 11 * 36, r + 11 * 36-2, r + 11 * 36, r + 11 * 36+4);
             drawline.DrawLine(MyPen, r + 7 * 36, r + 7 * 36 - 2, r + 7 * 36, r + 7 * 36 + 4);
         }

         //画选中点上的红框和消除上一个红框
         private void Draw_And_Clear_Line(int x,int y,Color color) {
             Graphics drawline = Groap.CreateGraphics();
             Pen MyPen = new Pen(color, 2);
             drawline.DrawLine(MyPen, x, y, x + L, y);//左上横
             drawline.DrawLine(MyPen, x, y, x, y + L);//左上竖
             drawline.DrawLine(MyPen, x + len, y, x + len - L, y);//右上横
             drawline.DrawLine(MyPen, x + len, y, x + len, y + L);//右上竖
             drawline.DrawLine(MyPen, x, y + len, x + L, y + len);//左下横
             drawline.DrawLine(MyPen, x, y + len, x, y + len - L);//左下竖
             drawline.DrawLine(MyPen, x + len, y + len, x + len - L, y + len);//右下横
             drawline.DrawLine(MyPen, x + len, y + len, x + len, y + len - L);//右下竖
             lastx = x; lasty = y;
         }

        //鼠标悬浮位置
         private void Groap_MouseMove(object sender, MouseEventArgs e)//鼠标所在行列
         {
             X = (e.Y - r + 18) / 36;//鼠标所在行
             Y = (e.X - r + 18) / 36;//鼠标所在列
             if (QipanPictureBox[X, Y].Left + 2 == lastx && QipanPictureBox[X, Y].Top + 2 == lasty) return;
             shubiaoX.Text = "X：" + (X+1).ToString();
             shubiaoY.Text = "Y：" + (Y+1).ToString();
             //画选中点上的红框和消除上一个红框
             if (lastx != -1) Draw_And_Clear_Line(lastx, lasty, Color.Tan);
             Draw_And_Clear_Line(QipanPictureBox[X, Y].Left+2, QipanPictureBox[X, Y].Top+2, Color.Red);
         }

        //判断玩家是否赢
         private bool CheckPlay(int x, int y) {
             int i, j, flag = (stone ? 1 : 0);
             //横连
             for (i = y; i - 1 >= 0 && mark[x, i - 1] == flag; --i) ;
             for (j = y; j + 1 < 15 && mark[x, j + 1] == flag; ++j) ;
             if (j - i + 1 == 5) return true;

             //竖连
             for (i = x; i - 1 >= 0 && mark[i - 1, y] == flag; --i) ;
             for (j = x; j + 1 < 15 && mark[j + 1, y] == flag; ++j) ;
             if (j - i + 1 == 5) return true;

             //左斜
             for (i = 1; x - i >= 0 && y - i >= 0 && mark[x - i, y - i] == flag; ++i) ;
             for (j = 1; x + j < 15 && y + j < 15 && mark[x + j, y + j] == flag; ++j) ;
             if (j + i - 1 == 5) return true;

             //右斜
             for (i = 1; x - i >= 0 && y + i < 15 && mark[x - i, y + i] == flag; ++i) ;
             for (j = 1; x + j < 15 && y - j >= 0 && mark[x + j, y - j] == flag; ++j) ;
             if (j + i - 1 == 5) return true;

             return false;
         }

        //鼠标按下的操作
         private void Groap_MouseDown(object sender, MouseEventArgs e)
         {
             if (Begin == false) return;
             if(stone) QipanPictureBox[X, Y].Image = global::wuziqi.Properties.Resources.heizi;
             else QipanPictureBox[X, Y].Image = global::wuziqi.Properties.Resources.beizi;
             QipanPictureBox[X, Y].Visible = true;
             mark[X, Y] = stone ? 1 : 0;
             listBox1.Items.Add("玩家：X-"+X.ToString()+"，Y-"+Y.ToString());
             ++stack[0, 0];
             stack[stack[0, 0], 0] = X; stack[stack[0, 0], 1] = Y;
             if (CheckPlay(X, Y)) { MessageBox.Show("玩家赢!", "提示"); ClearGroap(); return; }
             stone = !stone;
             ComputerDown();
         }

        //清空棋盘
         private void ClearGroap() {//清空棋盘
             Begin = false;
             skinButtom1.Text = "开 始";
             skinButtom2.Visible = false;
             skinButtom3.Visible = false;
             listBox1.Items.Clear();
             stack[0, 0] = 0;
             for (int i = 0; i < 15; ++i) {
                 for (int j = 0; j < 15; ++j) {
                     QipanPictureBox[i, j].Visible = false;
                     mark[i, j] = 2;
                 }
             }
         }

         private void radioButton1_CheckedChanged(object sender, EventArgs e)//切换第一玩家
         {
             play = true;
             ClearGroap();//清空棋盘
             heiziplayLabel.Text = ":玩家";
             baiziplayLabel.Text = ":电脑";
             radioButton1.ForeColor = heiziplayLabel.ForeColor;
             radioButton2.ForeColor = baiziplayLabel.ForeColor;
         }

        //切换第一玩家
         private void radioButton2_CheckedChanged(object sender, EventArgs e)//切换第一玩家
         {
             play = false;
             ClearGroap();//清空棋盘
             heiziplayLabel.Text = ":电脑";
             baiziplayLabel.Text = ":玩家";
             radioButton2.ForeColor = heiziplayLabel.ForeColor;
             radioButton1.ForeColor = baiziplayLabel.ForeColor;
         }

        //开始
         private void skinButtom1_Click(object sender, EventArgs e)
         {
             if (Begin == true) return;
             Begin =stone= true;
             skinButtom1.Text = "进行中...";
             skinButtom2.Visible = true;
             skinButtom3.Visible = true;
             if (play == false) DownQi(7, 7);//电脑首先下的位置
         }
        #region 电脑下棋

        //计算每个位置的权值
         private bool CalculateVal(int x,int y,int Id) {
             int i=0, j=0, flag = (stone ? 1 : 0);
             int numfour = 0, numthree = 0, numtwo = 0, tempval = 0;
             if (Id == 1) flag = (stone?0:1);
             //横连
             for (i = y; i - 1 >= 0 && mark[x, i - 1] == flag;--i);
             for (j = y; j + 1 < 15 && mark[x, j + 1] == flag;++j);
             if (j - i + 1 == 5) return true;
             else if (j - i + 1 == 4) {
                 if (i - 1 >= 0 && mark[x, i - 1] == 2) ++numfour;
                 if (j + 1 < 15 && mark[x, j + 1] == 2) ++numfour;
             }
             else if (j - i + 1 == 3) {
                 if (i - 1 >= 0 && mark[x, i - 1] == 2 && i - 2 >= 0 && mark[x, i - 2] == 2) ++numthree;
                 if (i - 1 >= 0 && mark[x, i - 1] == 2 && j + 1 < 15 && mark[x, j + 1] == 2) ++numthree;
                 if (j + 1 < 15 && mark[x, j + 1] == 2 && j + 2 < 15 && mark[x, j + 2] == 2) ++numthree;
                 if (j + 1 < 15 && mark[x, j + 1] == 2 && i - 1 >= 0 && mark[x, i - 1] == 2) ++numthree;
             }
             else if (j - i + 1 == 2) {
                 int a = 1, b = 1;
                 while (i - a >= 0 && mark[x, i - a] == 2) ++a;
                 while (j + b < 15 && mark[x, j + b] == 2) ++b;
                 if (a + b - 2 >= 3 && i-1>=0 && mark[x,i-1] == 2)++numtwo;
                 if (a + b - 2 >= 3 && j+1<15 && mark[x,j+1] == 2)++numtwo;
             }

             //竖连
             for (i = x; i - 1 >= 0 && mark[i - 1,y] == flag;--i);
             for (j = x; j + 1 < 15 && mark[j + 1,y] == flag;++j);
             if (j - i + 1 == 5) return true;
             else if (j - i + 1 == 4) {
                 if (i - 1 >= 0 && mark[i - 1,y] == 2) ++numfour;
                 if (j + 1 < 15 && mark[j + 1,y] == 2) ++numfour;
             }
             else if (j - i + 1 == 3) {
                 if (i - 1 >= 0 && mark[i - 1,y] == 2 && i - 2 >= 0 && mark[i - 2,y] == 2) ++numthree;
                 if (i - 1 >= 0 && mark[i - 1,y] == 2 && j + 1 < 15 && mark[j + 1,y] == 2) ++numthree;
                 if (j + 1 < 15 && mark[j + 1,y] == 2 && j + 2 < 15 && mark[j + 2,y] == 2) ++numthree;
                 if (j + 1 < 15 && mark[j + 1,y] == 2 && i - 1 >= 0 && mark[i - 1,y] == 2) ++numthree;
             }
             else if(j - i + 1 == 2) {
                 int a = 1, b = 1;
                 while (i - a >= 0 && mark[i - a,y] == 2) ++a;
                 while (j + b < 15 && mark[j + b,y] == 2) ++b;
                 if (a + b - 2 >= 3 && i-1>=0 && mark[i-1,y] == 2)++numtwo;
                 if (a + b - 2 >= 3 && j+1<15 && mark[j+1,y] == 2)++numtwo;
             }

             //左斜
             for (i = 1; x - i >= 0 && y - i >= 0 && mark[x - i, y - i] == flag; ++i) ;
             for (j = 1; x + j < 15 && y + j < 15 && mark[x + j, y + j] == flag; ++j) ;
             if (j + i - 1 == 5) return true;
             else if (j + i - 1 == 4) {
                 if (x-i >= 0  && y-i>=0 && mark[x - i, y-i] == 2) ++numfour;
                 if (x+j < 15 && y+j<15 && mark[x+j, y+j] == 2) ++numfour;
             }
             else if (j + i - 1 == 3) {
                 if (x - i >= 0 && y - i >= 0 && mark[x - i, y - i] == 2 && x-i-1 >= 0 && y-i-1>=0 && mark[x-i-1, y-i-1] == 2) ++numthree;
                 if (x - i >= 0 && y - i >= 0 && mark[x - i, y - i] == 2 && x + j < 15  && y+j<15 && mark[x+j, y+j] == 2) ++numthree;
                 if (x+j < 15  && y + j <15 && mark[x+j, y+j] == 2 && x+j+1 < 15 && y+j+1<15 && mark[x+j+1, y+j+1] == 2) ++numthree;
                 if (x + j < 15 && y + j < 15 && mark[x + j, y + j] == 2 && x-i >= 0  && y-i>=0 && mark[x-i, y-i] == 2) ++numthree;
             }
             else if (j + i - 1 == 2) {
                 int a=i,b=j;
                 while (x - i >= 0 && y - i >= 0 && mark[x - i, y - i] == 2) ++i;
                 while (x + j < 15 && y + j < 15 && mark[x + j, y + j] == 2) ++j;
                 if (j + i - 1 >= 5 && x - a >= 0 && y - a >= 0 && mark[x - a, y - a] == 2) ++numtwo;
                 if (j + i - 1 >= 5 && x + b < 15 && y + b < 15 && mark[x + b, y + b] == 2) ++numtwo;
             }

             //右斜
             for (i = 1; x - i >= 0 && y + i < 15 && mark[x - i, y + i] == flag; ++i) ;
             for (j = 1; x + j < 15 && y - j >= 0 && mark[x + j, y - j] == flag; ++j) ;
             if (j + i - 1 == 5) return true;
             else if (j + i - 1 == 4) {
                 if (x - i >= 0 && y + i < 15 && mark[x - i, y + i] == 2) ++numfour;
                 if (x + j < 15 && y - j >= 0 && mark[x + j, y - j] == 2) ++numfour;
             }
             else if (j + i - 1 == 3) {
                 if (x - i >= 0 && y + i < 15 && mark[x - i, y + i] == 2 && x - i - 1 >= 0 && y + i + 1 < 15 && mark[x - i - 1, y + i + 1] == 2) ++numthree;
                 if (x - i >= 0 && y + i < 15 && mark[x - i, y + i] == 2 && x + j < 15 && y - j >= 0 && mark[x + j, y - j] == 2) ++numthree;
                 if (x + j < 15 && y - j >= 0 && mark[x + j, y - j] == 2 && x + j + 1 < 15 && y - j - 1 >= 0 && mark[x + j + 1, y - j - 1] == 2) ++numthree;
                 if (x + j < 15 && y - j >= 0 && mark[x + j, y - j] == 2 && x - i >= 0 && y + i < 15 && mark[x - i, y + i] == 2) ++numthree;
             }
             else if (j + i - 1 == 2) {
                 int a = i, b = j;
                 while (x - i >= 0 && y + i < 15 && mark[x - i, y + i] == 2) ++i;
                 while (x + j < 15 && y - j >= 0 && mark[x + j, y - j] == 2) ++j;
                 if (j + i - 1 >= 5 && x - a >= 0 && y + a < 15 && mark[x - a, y + a] == 2) ++numtwo;
                 if (j + i - 1 >= 5 && x + b < 15 && y - b >= 0 && mark[x + b, y - b] == 2) ++numtwo;
             }
             if (numfour >= 2 || (numfour >= 1 && numthree >= 3)) tempval = 10000000+numtwo*10+numthree*100+numfour*1000;//活4
             else if (numfour > 0 && Id == 0) tempval = 1000000 + numtwo * 10 + numthree * 100 + numfour * 1000;//连4
             else if (numthree >= 6 && Id == 1) tempval = 1000000 + numtwo * 10 + numthree * 100 + numfour * 1000;//活3
             else if (numfour > 0) tempval = 100000 + numtwo * 10 + numthree * 100 + numfour * 1000;//连4
             else if (numthree >= 6) tempval = 100000 + numtwo * 10 + numthree * 100 + numfour * 1000;//活3
             else if (numthree >= 3) tempval = 10000 + numtwo * 10 + numthree * 100 + numfour * 1000;//可能的活连3
             else if (numtwo >= 6) tempval = 1000 + numtwo * 10 + numthree * 100 + numfour * 1000;//活2
             else if (numthree > 0) tempval = 100 + numtwo * 10 + numthree * 100 + numfour * 1000;//连3
             else if (numtwo > 0) tempval = 10 + numtwo * 10 + numthree * 100 + numfour * 1000;
             else tempval = 1;
             if (tempval > val[Id]) { val[Id] = tempval; pos[Id, 0] = x; pos[Id, 1] = y; }
             return false;
         }

         private void CalculateJuShi(int Id) { //计算局势
             for (int i = 0; i < 15; ++i) {
                 for (int j = 0; j < 15; ++j) {
                     if (mark[i,j] != 2) continue;
                     if(CalculateVal(i,j,Id)){ X = i; Y = j; return; };
                 }
             }
         }

        //电脑在该点放下棋子
         private void DownQi(int x, int y) {//电脑在该位置放下棋子
             QipanPictureBox[x, y].Visible = true;
             if (stone){
                 if(lastX != -1)QipanPictureBox[lastX, lastY].Image = global::wuziqi.Properties.Resources.heizi;
                 QipanPictureBox[x, y].Image = global::wuziqi.Properties.Resources.heizi2;
             }
             else {
                 if(lastX != -1)QipanPictureBox[lastX, lastY].Image = global::wuziqi.Properties.Resources.beizi;
                 QipanPictureBox[x, y].Image = global::wuziqi.Properties.Resources.beizi2;
             } 
             mark[x, y] = stone ? 1 : 0;
             stone = !stone;
             listBox1.Items.Add("电脑：X-" + x.ToString() + "，Y-" + y.ToString());
             ++stack[0, 0];
             stack[stack[0, 0], 0] = x; stack[stack[0, 0], 1] = y;
             lastX = x; lastY = y;
         }

        //电脑下棋
         private void ComputerDown() {
             val[0] = val[1] = 0;
              X = Y = -1;
              CalculateJuShi(0);
              if (X != -1) {
                  DownQi(X,Y);//电脑连5子
                  MessageBox.Show("电脑赢!", "提示");
                  ClearGroap();
                  return;
              }
              X = Y = -1;
              CalculateJuShi(1);
              if (X != -1) DownQi(X, Y);
              else if (val[0] >= 10000000) DownQi(pos[0, 0], pos[0, 1]);
              else if (val[1] >= 10000000) DownQi(pos[1, 0], pos[1, 1]);
              else if (val[0] >= 1000000) DownQi(pos[0, 0], pos[0, 1]);
              else if (val[1] >= 1000000) DownQi(pos[1, 0], pos[1, 1]);
              else if (val[0] >= 100000) DownQi(pos[0, 0], pos[0, 1]);
              else if (val[1] >= 100000) DownQi(pos[1, 0], pos[1, 1]);
              else if (val[0] >= 10000) DownQi(pos[0, 0], pos[0, 1]);
              else if (val[1] >= 10000) DownQi(pos[1, 0], pos[1, 1]);
              else if (val[0] >= 1000) DownQi(pos[0, 0], pos[0, 1]);
              else if (val[0] >= val[1]) DownQi(pos[0, 0], pos[0, 1]);
              else DownQi(pos[1, 0], pos[1, 1]);
              //shubiaoX.Text = val[0].ToString();
              //shubiaoY.Text = val[1].ToString();
         }

        #endregion

        //重新开始
         private void skinButtom2_Click(object sender, EventArgs e)
         {
             ClearGroap();
         }

        //悔棋
         private void skinButtom3_Click(object sender, EventArgs e)
         {
             if (stack[0, 0] > 1) {
                 int x = stack[stack[0, 0], 0], y = stack[stack[0, 0], 1];
                 --stack[0, 0];
                 listBox1.Items.RemoveAt(stack[0, 0]);
                 mark[x, y] = 2;
                 QipanPictureBox[x,y].Visible=false;

                 x = stack[stack[0, 0], 0]; y = stack[stack[0, 0], 1];
                 --stack[0, 0];
                 listBox1.Items.RemoveAt(stack[0, 0]);
                 mark[x, y] = 2;
                 QipanPictureBox[x, y].Visible = false;
                 lastX = -1; lastY = -1;
             }
         }
    }
}
