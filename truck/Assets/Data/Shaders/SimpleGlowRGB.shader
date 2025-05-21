// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "JIN/SimpleGlowRGB"
{
    Properties
    {
        _MainTex("Sprite Texture", 2D) = "white" {}
		_AlphaTex("External Alpha", 2D) = "white" { }
        _Color("Tint", Color) = (1, 1, 1, 1)
        _FlashColor("Flash Color", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap("Pixel snap", Float) = 0
    }
    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
            "IgnoreProjector" = "true"
            "RenderType" = "Transparent"
            "PreviewType" = "Plane"
            "CanUseSpriteAtlas" = "true"
        }
        Cull Off
        Lighting Off
        ZWrite Off

        Blend SrcAlpha One

        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ PIXELSNAP_ON
            #pragma shader_feature ETC1_EXTERNAL_ALPHA
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                half2 texcoord  : TEXCOORD0;
            };

            sampler2D _MainTex;
			sampler2D _AlphaTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            fixed4 _FlashColor;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.color = v.color * _Color;
                #ifdef PIXELSNAP_ON
                o.vertex = UnityPixelSnap(o.vertex);
                #endif

                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // // sample the texture
                // fixed4 col = tex2D(_MainTex, i.texcoord) * i.color;
				// col.a *= tex2D(_AlphaTex, i.texcoord).r;
                // if (i.color.r < 1)
                // {
                //     col.rgb = lerp(col.rgb, _FlashColor.rgb, 1 - i.color.r);
                //     //col = Lighten(col, _FlashColor);
                // }


                // sample the texture
                fixed4 col = tex2D(_MainTex, i.texcoord) * i.color;
                col.a *= tex2D(_AlphaTex, i.texcoord).r;
                // col.a *= max(tex2D(_AlphaTex, i.texcoord).r, max(tex2D(_AlphaTex, i.texcoord).g, tex2D(_AlphaTex, i.texcoord).b));
                float rgbmax = max(i.color.r, max(i.color.g, i.color.b));
                if (rgbmax < 1)
                {
                    col.rgb = lerp(col.rgb, _FlashColor.rgb, 1 - rgbmax);
                    //col = Lighten(col, _FlashColor);
                }

                return col;
            }
            ENDCG
        }
    }
    Fallback "Sprites/Default"
}
