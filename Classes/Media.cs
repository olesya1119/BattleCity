using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BattleCity.Classes
{
    enum Texture
    {
        PlayerTank1, PlayerTank2, EnemyTank1, EnemyTank2, Wall
    }

    enum AnimationFrames
    {
        DrivePlayerTank1
    }

    /// <summary>
    /// Определение методов для работы с ресурсами
    /// </summary>
    class Media
    {
        public static void Boom()//Анимация взрыва
        { }

        public static void Bang()//Анимация попадания пули по любому объекту
        { }

        public static void Birth()//Анимация "рождения танка"
        { }


        
        public static ImageBrush getTexture(Texture texture)
        {
            Uri uri;
            switch (texture)
            {
                case Texture.PlayerTank1:
                    uri = new Uri(@"../../Res/mainTank.png", UriKind.RelativeOrAbsolute);
                    break;
                default:
                    uri = new Uri(@"../../Res/mainTank.png", UriKind.RelativeOrAbsolute);
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

        public static ImageBrush[] getAnimationFrames(AnimationFrames animationFrames)
        {
            int frames = 0, height, width;
            Uri uri;
            switch (animationFrames)
            {
                case AnimationFrames.DrivePlayerTank1:
                    uri = new Uri(@"../../Res/Images/playerTank1.png", UriKind.RelativeOrAbsolute);
                    break;
                default:
                    uri = new Uri(@"../../Res/Images/playerTank1.png", UriKind.RelativeOrAbsolute);
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
                
                /*
                tb.BeginInit();
                tb.Source = croppedImage;
                tb.Transform = new RotateTransform(180);
                tb.EndInit();
                imageBrushes[i + frames * 2] = new ImageBrush(croppedImage);

                tb.BeginInit();
                tb.Source = croppedImage;
                tb.Transform = new RotateTransform(270);
                tb.EndInit();
                imageBrushes[i + frames * 3] = new ImageBrush(croppedImage);*/
            }

            return imageBrushes;
        }

        

    }
}
