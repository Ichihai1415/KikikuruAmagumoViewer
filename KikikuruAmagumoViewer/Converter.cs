using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KikikuruAmagumoViewer.Structure;

namespace KikikuruAmagumoViewer
{
    public class Converter
    {
        /// <summary>
        /// タイル座標を緯度経度相互変換
        /// </summary>
        /// <remarks><see href="https://wiki.openstreetmap.org/wiki/Slippy_map_tilenames"/>の例を改変</remarks>
        public class Tile
        {
            public static int Lon2TileX(double lon, int z)
            {
                return (int)Math.Floor((lon + 180d) / 360d * (1 << z));
            }

            public static int Lon2PixelX(double lon, int z, int tileSize = 256)
            {
                double x = (lon + 180d) / 360d * (1 << z) * tileSize;
                return (int)Math.Floor(x) % tileSize;
            }

            public static (int tileX, int pixelX) Lon2TileXPixelX(double lon, int z, int tileSize = 256)
            {
                var x = (lon + 180d) / 360d * (1 << z);
                var tileX = Math.Floor(x);
                var pixelX = (int)Math.Floor((x - tileX) * tileSize);
                return ((int)tileX, pixelX);
            }

            public static int Lat2TileY(double lat, int z)
            {
                var latRad = lat / 180 * Math.PI;
                return (int)Math.Floor((1 - Math.Log(Math.Tan(latRad) + 1 / Math.Cos(latRad)) / Math.PI) / 2d * (1 << z));
            }

            public static int Lat2PixelY(double lat, int z, int tileSize = 256)
            {
                var latRad = lat / 180 * Math.PI;
                var y = (1 - Math.Log(Math.Tan(latRad) + 1 / Math.Cos(latRad)) / Math.PI) / 2d * (1 << z) * tileSize;
                return (int)Math.Floor(y) % tileSize;
            }

            public static (int tileY, int pixelY) Lat2TileYPixelY(double lat, int z, int tileSize = 256)
            {
                var latRad = lat / 180 * Math.PI;
                var y = (1 - Math.Log(Math.Tan(latRad) + 1 / Math.Cos(latRad)) / Math.PI) / 2d * (1 << z);
                var tileY = Math.Floor(y);
                var pixelY = (int)Math.Floor((y - tileY) * tileSize);
                return ((int)tileY, pixelY);
            }

            public static (int x, int y) LatLon2TileXY(double lat, double lon, int z)
            {
                var x = Lon2TileX(lon, z);
                var y = Lat2TileY(lat, z);
                return (x, y);
            }

            public static TileCoordinate LatLon2TileXY_TC(double lat, double lon, int z)
            {
                var (x, y) = LatLon2TileXY(lat, lon, z);
                return new TileCoordinate(x, y, z);
            }

            public static (int x, int y) LatLon2PixelXY(double lat, double lon, int z, int tileSize = 256)
            {
                var x = Lon2PixelX(lon, z, tileSize);
                var y = Lat2PixelY(lat, z, tileSize);
                return (x, y);
            }

            public static TileCoordinate LatLon2TileXYPixelXY(double lat, double lon, int z, int tileSize = 256)
            {
                var (tileX, pixelX) = Lon2TileXPixelX(lon, z, tileSize);
                var (tileY, pixelY) = Lat2TileYPixelY(lat, z, tileSize);
                return new TileCoordinate(tileX, tileY, z, pixelX, pixelY);
            }

            public static double TileX2Lon(int x, int z)
            {
                return x / (1 << z) * 360d - 180d;
            }

            public static double TileY2Lat(int y, int z)
            {
                var n = Math.PI - 2d * Math.PI * y / (1 << z);
                return 180d / Math.PI * Math.Atan(0.5 * (Math.Exp(n) - Math.Exp(-n)));
            }

            public static (double lat, double lon) TileXY2LatLon(int x, int y, int z)
            {
                var lon = TileX2Lon(x, z);
                var lat = TileY2Lat(y, z);
                return (lat, lon);
            }

            public static double TilePixelX2Lon(int tileX, int pixelX, int z, int tileSize = 256)
            {
                double x = tileX * tileSize + pixelX;
                return x / ((1 << z) * tileSize) * 360d - 180d;
            }

            public static double TilePixelY2Lat(int tileY, int pixelY, int z, int tileSize = 256)
            {
                double y = tileY * tileSize + pixelY;
                double n = Math.PI - 2d * Math.PI * y / ((1 << z) * tileSize);
                return 180d / Math.PI * Math.Atan(0.5 * (Math.Exp(n) - Math.Exp(-n)));
            }

            public static (double lat, double lon) TilePixelXY2LatLon(int tileX, int tileY, int pixelX, int pixelY, int z, int tileSize = 256)
            {
                var lon = TilePixelX2Lon(tileX, pixelX, z, tileSize);
                var lat = TilePixelY2Lat(tileY, pixelY, z, tileSize);
                return (lat, lon);
            }




        }
    }
}
