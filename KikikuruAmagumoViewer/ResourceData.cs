namespace KikikuruAmagumoViewer
{
    internal class ResourceData
    {

        internal enum Tile_Map
        {
            /// <summary>
            /// null
            /// </summary>
            Null,
            /// <summary>
            /// 標準地図
            /// </summary>
            GSI_std = 1101,
            /// <summary>
            /// 淡色地図
            /// </summary>

            GSI_pale,

            /// <summary>
            /// 白地図
            /// </summary>
            GSI_blank,

            /// <summary>
            /// 写真
            /// </summary>
            /// <remarks>権利表示: 地理院地図 + [2~8(世界衛星モザイク画像)]Images on 世界衛星モザイク画像 obtained from site https://lpdaac.usgs.gov/data_access maintained by the NASA Land Processes Distributed Active Archive Center (LP DAAC), USGS/Earth Resources Observation and Science (EROS) Center, Sioux Falls, South Dakota, (Year). Source of image data product. [9~13(全国ランドサットモザイク画像)]データソース：Landsat8画像（GSI,TSIC,GEO Grid/AIST）, Landsat8画像（courtesy of the U.S. Geological Survey）, 海底地形（GEBCO） [14~18(全国最新写真（シームレス）)]GRUS画像（(c) Axelspace）</remarks>
            GSI_seamlessphoto,

            /// <summary>
            /// 色別標高図
            /// </summary>
            /// <remarks?>権利表示: 国土地理院 + 海域部は海上保安庁海洋情報部の資料を使用して作成</remarks>
            GSI_relief,

            /// <summary>
            /// 治水地形分類図
            /// </summary>
            GSI_lcmfc2,



            GSI_std_Web = 1201,
            GSI_pale_Web,
            GSI_blank_Web,
            GSI_seamlessphoto_Web,
            GSI_relief_Web,
            GSI_lcmfc2_Web,



            JMA_base = 2101,//警報注意報など//国内黒線のみ海外黒線グレー塗

            JMA_green_class20s,//台風//緑
            JMA_green_cities,//アメダス
            JMA_gray_cities,//津波

            JMA_GSI_pale = 2201,
            JMA_GSI_pale2,//地震

            JMA_GSI_hillshademap,//震央など//起伏
            JMA_GSI_transparent_cities,//震央//日本黒線のみ




        }
        internal static Dictionary<Tile_Map, string> MapURL = new()
        {
            { Tile_Map.Null, "" },
            { Tile_Map.GSI_std, "https://cyberjapandata.gsi.go.jp/xyz/std/{z}/{x}/{y}.png" },
            { Tile_Map.GSI_pale, "https://cyberjapandata.gsi.go.jp/xyz/pale/{z}/{x}/{y}.png" },
            { Tile_Map.GSI_blank, "https://cyberjapandata.gsi.go.jp/xyz/blank/{z}/{x}/{y}.png" },
            { Tile_Map.GSI_seamlessphoto, "https://cyberjapandata.gsi.go.jp/xyz/seamlessphoto/{z}/{x}/{y}.jpg" },
            { Tile_Map.GSI_relief, "https://cyberjapandata.gsi.go.jp/xyz/relief/{z}/{x}/{y}.png" },
            { Tile_Map.GSI_lcmfc2, "https://cyberjapandata.gsi.go.jp/xyz/lcmfc2/{z}/{x}/{y}.png" },
            { Tile_Map.GSI_std_Web, "https://maps.gsi.go.jp/xyz/std/{z}/{x}/{y}.png" },
            { Tile_Map.GSI_pale_Web, "https://maps.gsi.go.jp/xyz/pale/{z}/{x}/{y}.png" },
            { Tile_Map.GSI_blank_Web, "https://maps.gsi.go.jp/xyz/blank/{z}/{x}/{y}.png" },
            { Tile_Map.GSI_seamlessphoto_Web, "https://maps.gsi.go.jp/xyz/seamlessphoto/{z}/{x}/{y}.jpg" },
            { Tile_Map.GSI_relief_Web, "https://maps.gsi.go.jp/xyz/relief/{z}/{x}/{y}.png" },
            { Tile_Map.GSI_lcmfc2_Web, "https://maps.gsi.go.jp/xyz/lcmfc2/{z}/{x}/{y}.png" },

            { Tile_Map.JMA_base, "https://www.jma.go.jp/tile/jma/base/{z}/{x}/{y}.png" },
            { Tile_Map.JMA_green_class20s, "https://www.jma.go.jp/tile/jma/green-class20s/{z}/{x}/{y}.png" },
            { Tile_Map.JMA_green_cities, "https://www.jma.go.jp/tile/jma/green-cities/{z}/{x}/{y}.png" },
            { Tile_Map.JMA_gray_cities, "https://www.jma.go.jp/tile/jma/gray-cities/{z}/{x}/{y}.png" },
            { Tile_Map.JMA_GSI_pale, "https://www.jma.go.jp/tile/gsi/pale/{z}/{x}/{y}.png" },
            { Tile_Map.JMA_GSI_pale2, "https://www.jma.go.jp/tile/gsi/pale2/{z}/{x}/{y}.png" },
            { Tile_Map.JMA_GSI_hillshademap, "https://www.jma.go.jp/tile/gsi/hillshademap/{z}/{x}/{y}.png" },
            { Tile_Map.JMA_GSI_transparent_cities, "https://www.jma.go.jp/tile/gsi/transparent-cities/{z}/{x}/{y}.png" },
        };

        internal static Dictionary<Tile_Map, string> MapRights = new()
        {
            {Tile_Map.JMA_base,"気象庁" },
            {Tile_Map.JMA_green_class20s,"気象庁" },
            {Tile_Map.JMA_green_cities,"気象庁" },
            {Tile_Map.JMA_gray_cities,"気象庁" },
        };



        internal enum Tile_Data
        {
            JMA_nowc_hrpns
        }

        internal static Dictionary<Tile_Data, string> DataURL = new()
        {
            { Tile_Data.JMA_nowc_hrpns, "https://www.jma.go.jp/bosai/jmatile/data/nowc/{dateTime}/none/{dateTime}/surf/hrpns/{z}/{x}/{y}.png" },

        };



        /*
         
dosyakiki         
         https://www.jma.go.jp/bosai/jmatile/data/risk/20250907111000/immed0/20250907111000/surf/land/10/908/393.png

        sinsuikiki
        https://www.jma.go.jp/bosai/jmatile/data/risk/20250907111000/immed0/20250907111000/surf/inund/10/909/393.png

        kouzuikiki
        https://www.jma.go.jp/bosai/jmatile/data/map/none/none/none/surf/flood/12/3637/1573.png

        rain
        https://www.jma.go.jp/bosai/jmatile/data/nowc/20250907115500/none/20250907115500/surf/hrpns/4/14/6.png

        kaminari
        https://www.jma.go.jp/bosai/jmatile/data/nowc/20250907115000/none/20250907115000/surf/thns/4/13/6.png

        tatumaki
        https://www.jma.go.jp/bosai/jmatile/data/nowc/20250907115000/none/20250907115000/surf/trns/4/14/7.png

        **amagumo_keiryou
        https://www.jma.go.jp/bosai/rain/data/rain/20250907115500/rain_20250907115500_f00_a00.png
        ->map:
        https://www.jma.go.jp/bosai/rain/const/map/border_a00.png
https://www.jma.go.jp/bosai/rain/const/map/map_a00.png

        kongo ame 1
        https://www.jma.go.jp/bosai/jmatile/data/rasrf/20250907115000/immed/20250907115000/surf/rasrf/4/14/6.png

        kongo ame 3
        https://www.jma.go.jp/bosai/jmatile/data/rasrf/20250907115000/immed/20250907115000/surf/rasrf03h/4/13/6.png

        kopngoame 24h
        https://www.jma.go.jp/bosai/jmatile/data/rasrf/20250907115000/immed/20250907115000/surf/rasrf24h/4/14/5.png


        **keiryou kongo ame 1
        https://www.jma.go.jp/bosai/rain/data/ra/20250907115000/rain01_20250907115000_f00_a00.png

        3
        https://www.jma.go.jp/bosai/rain/data/ra/20250907115000/rain03_20250907115000_f00_a00.png

        24
        https://www.jma.go.jp/bosai/rain/data/ra/20250907115000/rain24_20250907115000_f00_a00.png



        yuki hukasa
        https://www.jma.go.jp/bosai/jmatile/data/snow/20250907110000/none/20250907110000/surf/snowd/4/15/6.png

        kongo yuki 3h
        https://www.jma.go.jp/bosai/jmatile/data/snow/20250907110000/none/20250907110000/surf/snowf03h/4/12/6.png


        ..6.12.24.48.72

        tenki bunpu
        https://www.jma.go.jp/bosai/jmatile/data/wdist/20250907080000/none/20250907120000/surf/wm/8/228/98.png

        kion bunpu 
        https://www.jma.go.jp/bosai/jmatile/data/wdist/20250907080000/none/20250907120000/surf/temp/8/227/100.png

        3h kousui 
        https://www.jma.go.jp/bosai/jmatile/data/wdist/20250907080000/none/20250907120000/surf/r3/8/228/97.png

        3h kousetu

        https://www.jma.go.jp/bosai/jmatile/data/wdist/20250907080000/none/20250907120000/surf/r3/8/228/97.png

        saiteikion
        https://www.jma.go.jp/bosai/jmatile/data/wdist/20250907080000/none/20250908000000/surf/min_temp/8/225/100.png

        saikoukion
        https://www.jma.go.jp/bosai/jmatile/data/wdist/20250907080000/none/20250908090000/surf/max_temp/8/227/100.png

        sigaisenn yosoku
        https://www.data.jma.go.jp/env/uvindex/tile/uv/uv_f/20250906120000/uvi_f/20250908030000/surf/uvi_f/6/57/23.png

        hare sigaisen yosoku
        https://www.data.jma.go.jp/env/uvindex/tile/uv/uv_f/20250906120000/uvic_f/20250908030000/surf/uvic_f/6/56/26.png

        sigaisen kaiseki
        https://www.data.jma.go.jp/env/uvindex/tile/uv/uv_a/20250907090000/uvi_anal/20250907090000/surf/uvi_anal/6/55/25.png

        himawari sekigai
        https://www.jma.go.jp/bosai/himawari/data/satimg/20250907120000/fd/20250907120000/B13/TBB/5/26/10.jpg

        ...iroiro


        amedasu 
        https://www.jma.go.jp/bosai/amedas/data/map/20250907210000.json


        suitei kisyou
        https://www.data.jma.go.jp/bunpu/img/wthr/000/wthr_000_202509072000.png
        ->map
        https://www.data.jma.go.jp/bunpu/img/bgmap/bg_000.jpg

        suitei kion
        https://www.data.jma.go.jp/bunpu/img/temp/000/temp_000_202509072000.png

        suitei nissyou
        https://www.data.jma.go.jp/bunpu/img/suns1h/000/suns1h_000_202509072000.png

        ->hokuriku w
        https://www.data.jma.go.jp/bunpu/img/wthr/305/wthr_305_202509072000.png

        harou
        https://www.data.jma.go.jp/waveinf/data/wavemesh/tile/wavemesh/20250907060000/none/20250907060000/surf/wavh/4/15/6.png

        kaisuion zikkyou
        https://www.data.jma.go.jp/kaikyou/data/kaikyou/tile/sst_anl/20250906000000/none/20250906000000/surf/sst/4/15/6.png

        50m suion
        https://www.data.jma.go.jp/kaikyou/data/kaikyou/tile/subs/20250906000000/none/20250906000000/50/temp/4/15/5.png
        ..100.200.400

        50m kairyuu
        https://www.data.jma.go.jp/kaikyou/data/kaikyou/tile/subs/20250906000000/none/20250906000000/50/temp/4/15/5.png

        kaihyou
        海氷解析図の発表は5月30日をもって終了しました。次回発表予定は12月2日です。

        suikei sindo
        https://www.jma.go.jp/bosai/estimated_intensity_map/data/202507070012_798/4429.png




         */

        /*
//sinssuisoitei
         https://disaportaldata.gsi.go.jp/raster/01_flood_l2_shinsuishin/12/3635/1576.png?_jmahp

         */
    }
}
