Shader "JIN/WaterReflection" {
    Properties {
        _Speed ("Speed", Float ) = 0.5
        _Tint ("Tint", Color) = (1,1,1,1)
        _Noise ("Noise", 2D) = "white" {}
        _Main ("Main", 2D) = "white" {}
        _Additive ("Additive", Float ) = 1
        _void ("void", 2D) = "black" {}
        _Mask ("Mask", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform float _Speed;
            uniform sampler2D _void; uniform float4 _void_ST;
            uniform float4 _Tint;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform sampler2D _Main; uniform float4 _Main_ST;
            uniform float _Additive;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float3 node_5822 = (_Noise_var.rgb*float3(float2(i.uv0.r,i.uv0.g),0.0)).rgb;
                float3 node_9023 = lerp(float3(i.uv0,0.0),node_5822,i.uv0.g);
                float4 _void_var = tex2D(_void,TRANSFORM_TEX(node_9023, _void));
                float4 node_572 = _Time;
                float node_4356 = frac((node_572.g*_Speed));
                float3 node_3396 = lerp(float3(i.uv0.g,i.uv0.g,i.uv0.g),node_5822,frac((node_4356+0.5)));
                float4 node_4390 = tex2D(_Main,TRANSFORM_TEX(node_3396, _Main));
                float node_3570 = abs((node_4356*2.0+-1.0));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 emissive = (lerp(_void_var.rgb,node_4390.rgb,node_3570)*_Tint.rgb*_Additive*_Mask_var.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,lerp(_void_var.a,node_4390.a,node_3570));
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    Fallback "Sprites/Default"
    //CustomEditor "ShaderForgeMaterialInspector"
}
