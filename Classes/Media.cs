using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using BattleCity.Windows;

namespace BattleCity.Classes
{
    enum Texture
    {
        Bullet
    }

    enum AnimationFrames
    {
        DrivePlayerTank1, Boom, Bullet
    }

    /// <summary>
    /// Определение методов для работы с ресурсами
    /// </summary>
    class Media
    {
        private Rectangle rectangle;
        private ImageBrush[] frames;
        private double posX, posY, size;
        Canvas canvas;
        int timerStart, frame;
        

        public Media(double posX, double posY, double size, ref Canvas canvas)
        {
            this.posX = posX;
            this.posY = posY;
            this.size = size;
            this.canvas = canvas;
            rectangle = new Rectangle();
            frames = getAnimationFrames(AnimationFrames.Boom);
            rectangle.Width = size;
            rectangle.Height = size;
            rectangle.Fill = frames[0];

            frame = 1;
            Canvas.SetLeft(rectangle, posX);
            Canvas.SetBottom(rectangle, posY);
            canvas.Children.Add(rectangle);
            timerStart = GameWindow.timer;
        }

        public async Task Boom()//Анимация взрыва
        {     

            while (frame < frames.Length)
            {
                rectangle.Fill = frames[frame];
                frame++;

                //Thread.Sleep(20);
                //Console.WriteLine(frame.ToString() + " vvvvvv " + GameWindow.timer.ToString());
                await Task.Run(() => Thread.Sleep(20));
            }
            canvas.Children.Remove(rectangle);

        }

        public void Babah(Object source, ElapsedEventArgs e)
        {
            
        }


        public static void Bang()//Анимация попадания пули по любому объекту
        {
            

        }

        public static void Birth()//Анимация "рождения танка"
        { 
        
        }


        
        public static ImageBrush getTexture(Texture texture)
        {
            Uri uri;
            switch (texture)
            {
                case Texture.Bullet:
                    uri = new Uri(@"../../Res/Images/Bullet.png", UriKind.RelativeOrAbsolute);
                    break;
                default:
                    uri = new Uri(@"../../Res/Images/Error.png", UriKind.RelativeOrAbsolute);
                    break;
            }
            ImageBrush img = new ImageBrush();
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = uri;
            bmp.EndInit();
            img.ImageSource = bmp;
            return img;
        }

        public static ImageBrush[] getAnimationFramesWithRotate(AnimationFrames animationFrames)
        {
            int frames = 0, height, width;
            Uri uri;
            switch (animationFrames)
            {
                case AnimationFrames.DrivePlayerTank1:
                    uri = new Uri(@"../../Res/Images/PlayerTank1.png", UriKind.RelativeOrAbsolute);
                    break;
                case AnimationFrames.Bullet:
                    uri = new Uri(@"../../Res/Images/Bullet.png", UriKind.RelativeOrAbsolute);
                    break;
                default:
                    uri = new Uri(@"../../Res/Images/Error.png", UriKind.RelativeOrAbsolute);
                    break;
            }
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = uri;
            bmp.EndInit();
            
            height = (int) bmp.Height;
            width = (int) bmp.Width;
            frames = height/width;

            ImageBrush[] imageBrushes = new ImageBrush[frames * 4];
            for (int i = 0; i < frames; i++)
            {
                Int32Rect int32Rect = new Int32Rect(0, i * (height/ frames), width, (height / frames));
                CroppedBitmap croppedImage = new CroppedBitmap(bmp, int32Rect);
                imageBrushes[i] = new ImageBrush(croppedImage);

                TransformedBitmap tb1 = new TransformedBitmap();
                TransformedBitmap tb2 = new TransformedBitmap();
                TransformedBitmap tb3 = new TransformedBitmap();

                tb1.BeginInit();
                tb1.Source = croppedImage; 
                tb1.Transform = new RotateTransform(90);
                imageBrushes[i + frames] = new ImageBrush(tb1);
                tb1.EndInit();

                tb2.BeginInit();
                tb2.Source = croppedImage;
                tb2.Transform = new RotateTransform(180);
                imageBrushes[i + frames * 2] = new ImageBrush(tb2);
                tb2.EndInit();

                tb3.BeginInit();
                tb3.Source = croppedImage;
                tb3.Transform = new RotateTransform(270);
                imageBrushes[i + frames*3] = new ImageBrush(tb3);
                tb3.EndInit();
                  
            }

            return imageBrushes;
        }

        public static ImageBrush[] getAnimationFrames(AnimationFrames animationFrames)
        {
            int frames = 0, height, width;
            Uri uri;
            switch (animationFrames)
            {
                case AnimationFrames.Boom:
                    uri = new Uri(@"../../Res/Images/Boom.png", UriKind.RelativeOrAbsolute);
                    break;
                default:
                    uri = new Uri(@"../../Res/Images/Error.png", UriKind.RelativeOrAbsolute);
                    break;
            }
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = uri;
            bmp.EndInit();

            height = bmp.PixelHeight;
            width = bmp.PixelWidth;
            frames = height / width;

            ImageBrush[] imageBrushes = new ImageBrush[frames];
            for (int i = 0; i < frames; i++)
            {
                Int32Rect int32Rect = new Int32Rect(0, i * (height / frames), width, (height / frames));
                CroppedBitmap croppedImage = new CroppedBitmap(bmp, int32Rect);
                imageBrushes[i] = new ImageBrush(croppedImage);
            }
            return imageBrushes;
        }


    }
}
