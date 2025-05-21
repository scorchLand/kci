// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "JIN/FocusFx"
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

		Blend One OneMinusSrcAlpha

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

            v2f vert(appdata IN)
            {
				v2f OUT;
				fixed4 c = _Color;

				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * c;

#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap(OUT.vertex);
#endif
				return OUT;
            }

			fixed4 SampleSpriteTexture(float2 uv)
			{
				fixed4 color = tex2D(_MainTex, uv);

#if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
				if (_AlphaSplitEnabled)
					color.a = tex2D(_AlphaTex, uv).r;
#endif
				return color;
			}

            fixed4 frag(v2f IN) : SV_Target
            {
				fixed4 c = SampleSpriteTexture(IN.texcoord) * IN.color;
				c.rgb *= c.a;
				return c;
            }
            ENDCG
        }
    }
    Fallback "Sprites/Default"
}
