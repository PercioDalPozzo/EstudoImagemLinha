using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace EstudoImagemLinha
{
    public class PrintImagem
    {
        private const int EspessuraLinha = 1;

        public void Print(Matriz matriz, double saturacao, int tamanhoPixel, int intercalar)
        {
            int margem = tamanhoPixel * 3;
            int height = (tamanhoPixel * matriz.Coordenadas.Max(p => p.Y)) + margem;
            int width = (tamanhoPixel * matriz.Coordenadas.Max(p => p.X)) + margem;
            var random = new Random();

            using (var bitmap = new Bitmap(width, height))
            using (var g = Graphics.FromImage(bitmap))
            using (var pen = new Pen(Color.Black, EspessuraLinha))
            {
                g.Clear(Color.White);

                foreach (var item in matriz.Coordenadas)
                {
                    int quantLinhas = (int)(item.Luminosidade * saturacao);
                    int extra = (int)(item.Luminosidade / 100 * intercalar);
                    int xInicio = (item.X * tamanhoPixel) + tamanhoPixel;
                    int yInicio = (item.Y * tamanhoPixel) + tamanhoPixel;

                    for (int i = 0; i < quantLinhas; i++)
                    {
                        int x1 = random.Next(xInicio - extra, xInicio + tamanhoPixel + extra);
                        int y1 = random.Next(yInicio - extra, yInicio + tamanhoPixel + extra);
                        int x2 = random.Next(xInicio - extra, xInicio + tamanhoPixel + (2 * extra));
                        int y2 = random.Next(yInicio - extra, yInicio + tamanhoPixel + (2 * extra));

                        g.DrawLine(pen, x1, y1, x2, y2);
                    }
                }

                // Salvar imagem
                string fileName = string.Format("Gerado resolucao {0} saturacao {1} tamanhoPixel {2} - {3}.jpg",
                    matriz.Resolution, saturacao, tamanhoPixel, DateTime.Now.ToString("HH_mm_ss"));
                string filePath = Path.Combine("../../../../", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
                bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            Console.WriteLine("Imagem criada com sucesso!");
        }
    }
}


// using System.Drawing;
//
// namespace EstudoImagemLinha;
//
// public class PrintImagem
// {
//     private const int espessuraLinha = 1;
//     
//     public void Print(Matriz matriz, double saturacao, int tamanhoPixel, int intercalar)
//     {
//         var margem = tamanhoPixel * 3; 
//         
//         var height = (tamanhoPixel * matriz.Coordenadas.Max(p => p.Y)) + margem;
//         var width= (tamanhoPixel * matriz.Coordenadas.Max(p => p.X)) + margem;
//         var random = new Random();
//         
//         // Cria um novo bitmap com a largura e altura especificadas
//         using (Bitmap bitmap = new Bitmap(width, height))
//         {
//             var g = Graphics.FromImage(bitmap);
//             g.Clear(Color.White);
//
//             foreach (var item in matriz.Coordenadas)
//             {
//                 var quantLinhas = item.Luminosidade * saturacao;
//                 for (int i = 0; i < quantLinhas; i++)
//                 {
//                     using (Pen pen = new Pen(Color.Black, espessuraLinha))
//                     {
//                         var extra = (int)Math.Truncate(item.Luminosidade / 100 * intercalar);
//                         
//                         var xInicio = (item.X * tamanhoPixel)+tamanhoPixel;
//                         var yInicio = (item.Y * tamanhoPixel)+tamanhoPixel;
//                         
//                         var x1 = random.Next(xInicio - extra, xInicio + tamanhoPixel + extra);
//                         var y1 = random.Next(yInicio - extra, yInicio + tamanhoPixel + extra);
//
//                         var x2 = random.Next(xInicio - extra, xInicio + tamanhoPixel + (2*extra));
//                         var y2 = random.Next(yInicio - extra, yInicio + tamanhoPixel + (2*extra));
//
//                         g.DrawLine(pen, x1, y1, x2, y2);
//                     }                        
//                 }
//             }
//             
//             // Salva a imagem em formato JPEG
//             var filePath = $"../../../../Gerado resolucao {matriz.Resolution} saturacao {saturacao} tamanhoPixel{tamanhoPixel} - {DateTime.Now.ToString("hh_mm_ss")}.jpg";
//             var directoryPath = Path.GetDirectoryName(filePath);
//             if (!Directory.Exists(directoryPath))
//                 Directory.CreateDirectory(directoryPath);
//             
//             bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
//         }
//
//         Console.WriteLine("Imagem criada com sucesso!");
//     }  
// }