Shader "JIN/Distorsion"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Strength("Strength", float) = 0
    }

	SubShader
	{
		Cull Off ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		Tags 
		{
			"Queue" = "Transparent"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
		}

		GrabPass
		{
			"_BackgroundTexture"
		}

		// Render the object with the texture generated above, and invert the colors
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
            	float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
                float4 color    : COLOR;
            };

            struct v2f
            {
            	float2 uv : TEXCOORD0;
                float4 grabPos : TEXCOORD1;
                float4 pos : SV_POSITION;
                fixed4 color : COLOR;
            };

            v2f vert(appdata v) {
                v2f o;
                // use UnityObjectToClipPos from UnityCG.cginc to calculate 
                // the clip-space of the vertex
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                // use ComputeGrabScreenPos function from UnityCG.cginc
                // to get the correct texture coordinate
                o.grabPos = ComputeGrabScreenPos(o.pos);
                o.color = v.color;

                return o;
            }

            sampler2D _BackgroundTexture;
            float4 _BackgroundTexture_TexelSize;
            sampler2D _MainTex;
            float _Strength;

            fixed4 frag(v2f i) : SV_Target
            {
            	half4 normal = tex2D(_MainTex, i.uv);
            	half2 convertedUV = half2((normal.r - 0.5) * 2, (normal.g - 0.5) * 2) * _Strength * i.color.a / unity_OrthoParams.xy;
                // resolve about fliped y coordinate
                if (_BackgroundTexture_TexelSize.y < 0)
                {
                    convertedUV.y *= -1;
                }
                convertedUV.y *= -_ProjectionParams.x;
            	i.grabPos.xy = i.grabPos.xy + convertedUV;
                half4 result = tex2Dproj(_BackgroundTexture, i.grabPos);

                //result.a = i.color.a;

                return result;
            }
            ENDCG
		}
	}
}
