using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikikuruAmagumoViewer
{
    public class Converter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks><see href="https://wiki.openstreetmap.org/wiki/Slippy_map_tilenames"/>の例を改変</remarks>
        public class Tile
        {
            public static int Lon2TileX(double lon, int z)
            {
                return (int)Math.Floor((lon + 180d) / 360d * (1 << z));
            }

            public static int Lat2TileY(double lat, int z)
            {
                var latRad = lat / 180 * Math.PI;
                return (int)Math.Floor((1 - Math.Log(Math.Tan(latRad) + 1 / Math.Cos(latRad)) / Math.PI) / 2d * (1 << z));
            }

            public static double TileX2Lon(int x, int z)
            {
                return x / (double)(1 << z) * 360d - 180;
            }

            public static double TileY2Lat(int y, int z)
            {
                var n = Math.PI - 2d * Math.PI * y / (1 << z);
                return 180d / Math.PI * Math.Atan(0.5 * (Math.Exp(n) - Math.Exp(-n)));
            }
        }
    }
}
