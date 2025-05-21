Shader "JIN/AlphaBlendedWithMask"
{
    Properties
    {
        _MainTex("Sprite Texture", 2D) = "white" {}
        _Color("Tint", Color) = (1, 1, 1, 1)
		
		_StencilComp("Stencil Comparison", Float) = 8
		_Stencil("Stencil ID", Float) = 0
		_StencilOp("Stencil Operation", Float) = 0
		_StencilWriteMask("Stencil Write Mask", Float) = 255
		_StencilReadMask("Stencil Read Mask", Float) = 255

		_ColorMask("Color Mask", Float) = 15
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
            "RenderType" = "Transparent"
            "PreviewType" = "Plane"
        }
        LOD 100

        Stencil
		{
			Ref[_Stencil]
			Comp[_StencilComp]
			Pass[_StencilOp]
			ReadMask[_StencilReadMask]
			WriteMask[_StencilWriteMask]
		}

        Cull Off
        Lighting Off
        ZWrite Off
		ColorMask[_ColorMask]
        Blend SrcAlpha OneMinusSrcAlpha

        Offset -1, -1

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f_t
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _Color;

            v2f_t vert(appdata_t v)
            {
                v2f_t o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f_t i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;
                //col.a *= (1.0 - col.r);
                return col;
            }
            ENDCG
        }
    }
}
