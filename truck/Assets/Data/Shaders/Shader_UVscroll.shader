Shader "JIN/UVscroll" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (1,1,1,1)
        _X_speed ("X_speed", Float ) = 1
        _Y_speed ("Y_speed", Float ) = 0
        _Mask_Texture ("Mask_Texture", 2D) = "white" {}
        _Mask_Frame ("Mask_Frame", 2D) = "white" {}
        _Add ("Add", Range(0, 8)) = 2
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            //#define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            //#pragma multi_compile_fwdbase
            //#pragma multi_compile_fog
            //#pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform float _X_speed;
            uniform float _Y_speed;
            uniform sampler2D _Mask_Frame; uniform float4 _Mask_Frame_ST;
            uniform sampler2D _Mask_Texture; uniform float4 _Mask_Texture_ST;
            uniform float _Add;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_8813 = _Time;
                float2 node_3450 = (i.uv0+(node_8813.g*float2(_X_speed,_Y_speed)));
                float4 _Mask_Texture_var = tex2D(_Mask_Texture,TRANSFORM_TEX(node_3450, _Mask_Texture));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_3450, _MainTex));
                float4 _Mask_Frame_var = tex2D(_Mask_Frame,TRANSFORM_TEX(i.uv0, _Mask_Frame));
                float3 emissive = ((_Mask_Texture_var.rgb*_MainTex_var.rgb*_Mask_Frame_var.rgb)*i.vertexColor.rgb*_TintColor.rgb*_Add);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    //CustomEditor "ShaderForgeMaterialInspector"
}
