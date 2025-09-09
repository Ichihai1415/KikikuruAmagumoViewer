using static KikikuruAmagumoViewer.ResourceData;

namespace KikikuruAmagumoViewer
{
    internal class Utilities
    {
        internal static async Task<Bitmap> GetMapImage(Tile_Map mapTile, int x, int y, int z)
        {
            var cachePath = $"cache\\{mapTile}\\{z}\\{x}\\{y}.png";
            if (File.Exists(cachePath))
                return new Bitmap(cachePath);
            var url_map = MapURL[mapTile].Replace("{x}", x.ToString()).Replace("{y}", y.ToString()).Replace("{z}", z.ToString());
            var sr_map = await ControlForm.client.GetStreamAsync(url_map);
            // たまにIndexed画像？で直接Graphicsに渡せないのでコピー
            using var srcImg = new Bitmap(sr_map);
            var img = new Bitmap(srcImg.Width, srcImg.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using var gTemp = Graphics.FromImage(img);
            gTemp.DrawImage(srcImg, 0, 0, srcImg.Width, srcImg.Height);
            Directory.CreateDirectory(Path.GetDirectoryName(cachePath)!);
            img.Save(cachePath);
            return img;
        }
    }


}
