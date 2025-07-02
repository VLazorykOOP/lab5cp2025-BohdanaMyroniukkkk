
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D; 
using System.Collections.Generic; 

namespace FractalsAndHermite
{
    public partial class Form1 : Form
    {
        // ====== Для Кривої Ерміта ======
        private PointF P1 = new PointF(100, 400); 
        private PointF P2 = new PointF(600, 200); 
        private PointF V1 = new PointF(200, -300); 
        private PointF V2 = new PointF(200, 300);  
        private float t = 0f; 
        private Timer hermiteTimer;
        private Bitmap hermiteBuffer; 

        // ====== Для Фрактала Папороть ======
        private Bitmap fernBuffer; 
        private int fernA = 3;     
        private int fernK = 50000; 
        private Random random = new Random(); 

        public Form1()
        {
            InitializeComponent(); 

            // Ініціалізація таймера для анімації Ерміта
            hermiteTimer = new Timer();
            hermiteTimer.Interval = 30; 
            hermiteTimer.Tick += HermiteTimer_Tick;

            // Ініціалізація буферів зображень для PictureBox
            if (pictureBoxHermite.Width > 0 && pictureBoxHermite.Height > 0)
            {
                hermiteBuffer = new Bitmap(pictureBoxHermite.Width, pictureBoxHermite.Height);
                using (Graphics g = Graphics.FromImage(hermiteBuffer)) g.Clear(Color.White);
            }
            // Перевіряємо, що pictureBoxFern існує і має розміри
            if (pictureBoxFern.Width > 0 && pictureBoxFern.Height > 0)
            {
                fernBuffer = new Bitmap(pictureBoxFern.Width, pictureBoxFern.Height);
                using (Graphics g = Graphics.FromImage(fernBuffer)) g.Clear(Color.White);
            }

            // Встановлюємо початкові значення в текстові поля для фрактала Папороть
            txtA.Text = fernA.ToString();
            txtK.Text = fernK.ToString();
        }

        // ====== Логіка Кривої Ерміта ======

        private void btnHermiteStart_Click(object sender, EventArgs e)
        {
            if (hermiteBuffer != null)
            {
                using (Graphics g = Graphics.FromImage(hermiteBuffer))
                {
                    g.Clear(Color.White); // Фон для кривої
                }
            }
            t = 0f; 
            hermiteTimer.Start(); 
        }

        private void HermiteTimer_Tick(object sender, EventArgs e)
        {
            if (hermiteBuffer == null) return;

            using (Graphics g = Graphics.FromImage(hermiteBuffer))
            {
                Pen curvePen = new Pen(Color.Blue, 2);
                PointF pCurrent = Hermite(P1, P2, V1, V2, t);
                PointF pNext = Hermite(P1, P2, V1, V2, t + 0.01f);

                // Захист від малювання за межами буфера
                if (t + 0.01f <= 1.0f) 
                {
                    g.DrawLine(curvePen, pCurrent, pNext);
                }
            }

            t += 0.01f;
            if (t >= 1f)
            {
                hermiteTimer.Stop();
            }
            pictureBoxHermite.Invalidate();
        }

        private PointF Hermite(PointF p1, PointF p2, PointF v1, PointF v2, float t)
        {
            float t2 = t * t;
            float t3 = t2 * t;

            float h1 = 2 * t3 - 3 * t2 + 1;
            float h2 = -2 * t3 + 3 * t2;
            float h3 = t3 - 2 * t2 + t;
            float h4 = t3 - t2;

            float x = h1 * p1.X + h2 * p2.X + h3 * v1.X + h4 * v2.X;
            float y = h1 * p1.Y + h2 * p2.Y + h3 * v1.Y + h4 * v2.Y;
            return new PointF(x, y);
        }

        private void pictureBoxHermite_Paint(object sender, PaintEventArgs e)
        {
            if (hermiteBuffer != null)
            {
                e.Graphics.DrawImage(hermiteBuffer, 0, 0);
            }

            e.Graphics.FillEllipse(Brushes.Red, P1.X - 4, P1.Y - 4, 8, 8);
            e.Graphics.FillEllipse(Brushes.Red, P2.X - 4, P2.Y - 4, 8, 8);
            DrawVector(e.Graphics, P1, V1, Color.Green);
            DrawVector(e.Graphics, P2, V2, Color.Orange);
        }

        private void DrawVector(Graphics g, PointF basePoint, PointF vector, Color color)
        {
            using (Pen pen = new Pen(color, 1))
            {
                pen.CustomEndCap = new AdjustableArrowCap(5, 5);
                PointF end = new PointF(basePoint.X + vector.X / 3, basePoint.Y + vector.Y / 3);
                g.DrawLine(pen, basePoint, end);
            }
        }

        // ====== Логіка Фрактала Папороть ======

        private void btnDrawFern_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtA.Text, out fernA)) fernA = 3;
            if (!int.TryParse(txtK.Text, out fernK)) fernK = 50000;

            if (fernBuffer == null) return; 

            using (Graphics g = Graphics.FromImage(fernBuffer))
            {
                g.Clear(Color.White); // Фон для Папороті 
                DrawFernFractal(g); 
            }
            pictureBoxFern.Invalidate(); 
        }

        private void pictureBoxFern_Paint(object sender, PaintEventArgs e)
        {
            if (fernBuffer != null)
            {
                e.Graphics.DrawImage(fernBuffer, 0, 0);
            }
        }

        private void DrawFernFractal(Graphics g)
        {
            // Координати центру для "пучка"
            float picWidth = pictureBoxFern.Width;
            float picHeight = pictureBoxFern.Height;
            float centerX = picWidth / 2;
            float centerY = picHeight / 2;

            // Масштабування для відображення фрактала Барнслі
            float scale = Math.Min(picWidth / 10f, picHeight / 20f);

            // Зсув для центрування папороті відносно її внутрішніх координат
            float offsetX = centerX - 0.23f * scale; // центр по x 
            float offsetY = centerY - 2.5f * scale;    // центр по y 

            // Генеруємо випадкові кольори для кожного "листка"
            List<Color> colors = new List<Color>();
            for (int i = 0; i < fernA; i++)
            {
                colors.Add(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
            }

            for (int fernIndex = 0; fernIndex < fernA; fernIndex++)
            {
                float x = 0.0f; // Початкова точка для генерації
                float y = 0.0f;

                Color currentColor = colors[fernIndex];
                using (SolidBrush brush = new SolidBrush(currentColor))
                {
                    // Для кожної папороті застосовуємо початкове обертання, щоб створити "пучок"
                    double initialAngle = fernIndex * (2 * Math.PI / fernA); // Кут для кожного "листка"

                    for (int i = 0; i < fernK; i++)
                    {
                        int r = random.Next(100); 

                        float newX, newY;

                        // Афінні перетворення для фрактала Барнслі
                        if (r < 1) 
                        {
                            newX = 0;
                            newY = 0.16f * y;
                        }
                        else if (r < 86) 
                        {
                            newX = 0.85f * x + 0.04f * y;
                            newY = -0.04f * x + 0.85f * y + 1.6f;
                        }
                        else if (r < 93) 
                        {
                            newX = 0.2f * x - 0.26f * y;
                            newY = 0.23f * x + 0.22f * y + 1.6f;
                        }
                        else 
                        {
                            newX = -0.15f * x + 0.28f * y;
                            newY = 0.26f * x + 0.24f * y + 0.44f;
                        }

                        x = newX;
                        y = newY;

                        // Застосовуємо обертання до координат фрактала, щоб створити "пучок"
                        float rotatedX = (float)(x * Math.Cos(initialAngle) - y * Math.Sin(initialAngle));
                        float rotatedY = (float)(x * Math.Sin(initialAngle) + y * Math.Cos(initialAngle));

                        // Перетворення координат для відображення 
                        int drawX = (int)(rotatedX * scale + offsetX);
                        int drawY = (int)(rotatedY * scale + offsetY);

                        // Малюємо піксель. Перевіряємо, чи точка знаходиться в межах
                        if (drawX >= 0 && drawX < picWidth && drawY >= 0 && drawY < picHeight)
                        {
                            g.FillRectangle(brush, drawX, drawY, 1, 1); // Малюємо піксель
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (pictureBoxHermite.Width > 0 && pictureBoxHermite.Height > 0 && hermiteBuffer == null)
            {
                hermiteBuffer = new Bitmap(pictureBoxHermite.Width, pictureBoxHermite.Height);
                using (Graphics g = Graphics.FromImage(hermiteBuffer))
                {
                    g.Clear(Color.White);
                }
            }
            if (pictureBoxFern.Width > 0 && pictureBoxFern.Height > 0 && fernBuffer == null)
            {
                fernBuffer = new Bitmap(pictureBoxFern.Width, pictureBoxFern.Height);
                using (Graphics g = Graphics.FromImage(fernBuffer))
                {
                    g.Clear(Color.White);
                }
            }
        }
    }
}
